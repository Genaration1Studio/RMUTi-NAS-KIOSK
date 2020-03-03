using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ID_Search : Form
    {
        private int sec = 0;
        private Thread thr;
        private string campus;
        private string patternCitizen = @"^((\(?[0-9]{13}),?$)";
        private string patternCode = @"^((\(?[0-9]{11}),?-,?([0-9]{1}),?$)";
        private string keyboardPath = Path.Combine(@"C:\Program Files\Common Files\Microsoft Shared\ink", "TabTip.exe");
        private Process keyboardProc;
       
        //private Process process = new Process();
        public ID_Search()
        {
            InitializeComponent();
            int height = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 1366) / 2;
            int width = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - 768) / 2;
            panel_main.Location = new Point(width, height);
            if (Controller.member_type.Equals("student"))
            {
                txb_idSearch.MaxLength = 14;
                lbl_comment.Text = "ระบุรหัสประจำตัวนักศึกษา 12 หรือ 13 หลัก และเลือกวิทยาเขต";
                lbl_example.Text = "ตัวอย่าง : 5917211xxxx-x";
                lbl_staff1.Visible = false;
                lbl_staff2.Visible = false;
                txb_idSearch.Focus();
            }
            else
            {
                label1.Location = new Point(185, 400);
                lbl_Alert.Location = new Point(343, 403);
                cbb_campus.Location = new Point(296, 397);
                btn_search.Location = new Point(247, 655);
                pictureBox2.Location = new Point(309, 133);
                pictureBox2.Width = 215;
                pictureBox2.Height = 211;
                txb_idSearch.Hide();
                txtb_stdID.Visible = false;
                lbl_comment.Visible = false;
                lbl_example.Visible = false;
                lbl_example2.Visible = false;
                lbl_staff1.Visible = true;
                lbl_staff2.Visible = true;
            }
           
            showOnScreenKey();
            timer_removeC.Start();
        }
        private void Timer_removeC_Tick(object sender, EventArgs e)
        {
            if (sec == 180)
            {
                timer_removeC.Stop();
                Controller.writeLog("search_member", "fail", "time out, " + "citizen = " + Controller.cardCitizen);
                thr = new Thread(openHone);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            if (Controller.checkRemoveCard())
            {
                timer_removeC.Stop();
                Controller.writeLog("search_member", "fail", "time out, " + "citizen = " + Controller.cardCitizen);
                thr = new Thread(openHone);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            sec++;
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            timer_removeC.Stop();
            this.Close();
            thr = new Thread(openSelectUserType);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
        }

        private void openSelectUserType(object obj)
        {
            Application.Run(new Select_UserType());
        }

        private void openHone(object obj)
        {
            Application.Run(new Home());
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            Alert_Loading alert_Loading = new Alert_Loading();
            if (cbb_campus.SelectedIndex != -1)
            {
                Controller.errMeg = "";
                if (Controller.member_type.Equals("student"))
                {
                    if (string.IsNullOrEmpty(txb_idSearch.Text) == true)
                    {
                        txb_idSearch.Focus();
                        errorProvider1.SetError(this.txb_idSearch, "กรุณากรอกรหัสนักศึกษาตามรูปแบบ");
                    }
                    else
                    {
                        alert_Loading.Show();
                        Controller.capImages("2");
                        Controller.searchValue = txb_idSearch.Text.Trim();
                        if (Controller.getEss(campus, Controller.searchValue))
                        {
                            //เจอบุคคล
                            Controller.writeLog("search_member", "success", "found, " + "code = " + Controller.searchValue + ", campus = " + campus);
                            if (Controller.checkCitizenESS())
                            {
                                //เป็นเจ้าของบัตร -> สร้างบัญชีผู้ใช้งาน
                                if (Controller.getKey())
                                {
                                    if (Controller.postRegister(Controller.searchValue, campus))
                                    {
                                        //สมัครสมาชิกสำเร็จ
                                        alert_Loading.Close();
                                        timer_removeC.Stop();
                                        Controller.writeLog("post_register", "success", "student, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login);
                                        Controller.cearEssStd();
                                        thr = new Thread(openProfileUser);
                                        thr.SetApartmentState(ApartmentState.STA);
                                        thr.Start();
                                        this.Close();
                                    }
                                    else
                                    {
                                        //ไม่สามารถติดต่อระบบได้ 
                                        alert_Loading.Close();
                                        timer_removeC.Stop();
                                        Controller.writeLog("post_register", "fail", "not connect api, student, " + "code = " + Controller.searchValue + ", campus = " + campus);
                                        Controller.cearEssStd();
                                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                                        thr = new Thread(openHome);
                                        thr.SetApartmentState(ApartmentState.STA);
                                        thr.Start();
                                        this.Hide();
                                        alert_APINotConnect.ShowDialog();
                                        this.Close();
                                    }

                                }
                                else
                                {
                                    //ไม่สามารถติดต่อระบบได้    
                                    alert_Loading.Close();
                                    timer_removeC.Stop();
                                    Controller.writeLog("request_key", "fail", "not connect api, student, " + "code = " + Controller.searchValue + ", campus = " + campus);
                                    Controller.cearEssStd();
                                    Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                                    thr = new Thread(openHome);
                                    thr.SetApartmentState(ApartmentState.STA);
                                    thr.Start();
                                    this.Hide();
                                    alert_APINotConnect.ShowDialog();
                                    this.Close();
                                }
                            }
                            else
                            {
                                //ไม่ใช่เจ้าของบัตร -> ติดต่อเจ้าของบัตร
                                alert_Loading.Close();
                                timer_removeC.Stop();
                                Controller.writeLog("request_register", "fail", "citizen not mathc, student, " + "citizen = " + Controller.essStudent.result.personalId + ", cardCitizen = " + Controller.cardCitizen);
                                Controller.cearEssStd();
                                Alert_CitizenNotMathc citizenNotMathc = new Alert_CitizenNotMathc();
                                citizenNotMathc.ShowDialog();
                                this.Hide();
                                this.Close();
                                Controller.cearController();
                            }
                        }
                        else if (Controller.errMeg.Equals("Server Error"))
                        {
                            alert_Loading.Close();
                            Controller.errMeg = "";
                            Controller.capImages("1");
                            Controller.writeLog("verify_account", "fail", "nnot connect api Error 500, " + "citizen = " + Controller.cardCitizen);
                            Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                            alert_APINotConnect.ShowDialog();
                        }
                        else if (Controller.essStudent.message.Equals("Unauthorized access to this API"))
                        {
                            //ไม่สามารถติดต่อระบบได้
                            alert_Loading.Close();
                            timer_removeC.Stop();
                            Controller.writeLog("search_member", "fail", "not connect api, " + "code = " + Controller.searchValue + ", campus = " + campus);
                            Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                            thr = new Thread(openHome);
                            thr.SetApartmentState(ApartmentState.STA);
                            thr.Start();
                            this.Hide();
                            alert_APINotConnect.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            //ไม่เจอบุคคล -> คนนอก
                            alert_Loading.Close();
                            timer_removeC.Stop();
                            Controller.writeLog("search_member", "fail", "not found, " + "code = " + Controller.searchValue + ", campus = " + campus);
                            Alert_UserNotFound alert_UserNotFound = new Alert_UserNotFound();
                            alert_UserNotFound.ShowDialog();
                            this.Hide();
                            this.Close();
                            Controller.cearController();
                        }                        
                    }                   
                }            
                else
                {
                    alert_Loading.Show();
                    Controller.capImages("2");
                    Controller.searchValue = txb_idSearch.Text.Trim();
                    if (Controller.getEss(campus, Controller.searchValue))
                    {
                        //เจอบุคคล
                        Controller.writeLog("search_member", "success", "found, " + "citizen = " + Controller.searchValue + ", campus = " + campus);
                        if (Controller.checkCitizenESS())
                        {
                            //เป็นเจ้าของบัตร -> สร้างบัญชีผู้ใช้งาน
                            if (Controller.getKey())
                            {
                                if (Controller.postRegister(Controller.searchValue, campus))
                                {
                                    //สมัครสมาชิกสำเร็จ
                                    alert_Loading.Close();
                                    timer_removeC.Stop();
                                    Controller.writeLog("post_register", "success", "staff, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login);
                                    Controller.cearEssSff();
                                    thr = new Thread(openProfileUser);
                                    thr.SetApartmentState(ApartmentState.STA);
                                    thr.Start();
                                    this.Close();
                                }
                                else
                                {
                                    //ไม่สามารถติดต่อระบบได้ 
                                    alert_Loading.Close();
                                    timer_removeC.Stop();
                                    Controller.writeLog("post_register", "fail", "not connect api, staff, " + "citizen = " + Controller.searchValue + ", campus = " + campus);
                                    Controller.cearEssSff();
                                    Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                                    thr = new Thread(openHome);
                                    thr.SetApartmentState(ApartmentState.STA);
                                    thr.Start();
                                    this.Hide();
                                    alert_APINotConnect.ShowDialog();
                                    this.Close();
                                }

                            }
                            else
                            {
                                //ไม่สามารถติดต่อระบบได้   
                                alert_Loading.Close();
                                timer_removeC.Stop();
                                Controller.writeLog("request_key", "fail", "not connect api, staff, " + "citizen = " + Controller.searchValue + ", campus = " + campus);
                                Controller.cearEssSff();
                                Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                                thr = new Thread(openHome);
                                thr.SetApartmentState(ApartmentState.STA);
                                thr.Start();
                                this.Hide();
                                alert_APINotConnect.ShowDialog();
                                this.Close();
                            }
                        }
                        else
                        {
                            //ไม่ใช่เจ้าของบัตร -> ติดต่อเจ้าของบัตร
                            alert_Loading.Close();
                            timer_removeC.Stop();
                            Controller.writeLog("request_register", "fail", "citizen not mathc, staff, " + "citizen = " + Controller.essStaff.result.personalId + ", cardCitizen = " + Controller.cardCitizen);
                            Controller.cearEssSff();
                            Alert_CitizenNotMathc citizenNotMathc = new Alert_CitizenNotMathc();
                            citizenNotMathc.ShowDialog();
                            this.Hide();
                            this.Close();
                            Controller.cearController();
                        }
                    }
                    else if (Controller.errMeg.Equals("Server Error"))
                    {
                        alert_Loading.Close();
                        Controller.errMeg = "";
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "fail", "not connect api Error 500, " + "citizen = " + Controller.cardCitizen);
                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                        alert_APINotConnect.ShowDialog();
                    }
                    else if (Controller.essStaff.message.Equals("Unauthorized access to this API"))
                    {
                        //ไม่สามารถติดต่อระบบได้
                        alert_Loading.Close();
                        timer_removeC.Stop();
                        Controller.writeLog("search_member", "fail", "not connect api, " + "citizen = " + Controller.searchValue + ", campus = " + campus);
                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                        thr = new Thread(openHome);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                        this.Hide();
                        alert_APINotConnect.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //ไม่เจอบุคคล -> คนนอก
                        alert_Loading.Close();
                        timer_removeC.Stop();
                        Controller.writeLog("search_member", "fail", "not found, " + "citizen = " + Controller.searchValue + ", campus = " + campus);
                        Alert_UserNotFound alert_UserNotFound = new Alert_UserNotFound();
                        alert_UserNotFound.ShowDialog();
                        this.Hide();
                        this.Close();
                        Controller.cearController();
                    }
                }
            }
            else
            {
                lbl_Alert.Visible = true;
                cbb_campus.DroppedDown = true;
            }
        }

        private void openProfileUser(object obj)
        {
            Application.Run(new ProfileUser());
        }

        private void openHome(object obj)
        {
            Application.Run(new Home());
        }

        private void Cbb_campus_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Alert.Visible = false;
            if (cbb_campus.SelectedIndex == 0)
            {
                campus = "1";
            }
            else if (cbb_campus.SelectedIndex == 1)
            {
                campus = "2";
            }
            else if (cbb_campus.SelectedIndex == 2)
            {
                campus = "3";
            }
            else if (cbb_campus.SelectedIndex == 3)
            {
                campus = "5";
            }
        }

        public void showOnScreenKey()
        {
           this.keyboardProc = Process.Start(keyboardPath);
        }
      
        private void Txb_idSearch_Enter(object sender, EventArgs e)
        {
            showOnScreenKey();
        }

        private void Txb_idSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controller.member_type.Equals("student"))
            {
                if (Regex.IsMatch(txb_idSearch.Text, patternCode, RegexOptions.IgnoreCase) == false)
                {
                    txb_idSearch.Focus();
                    errorProvider1.SetError(this.txb_idSearch, "กรุณากรอกรหัสนักศึกษาตามรูปแบบ");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            else
            {
                if (Regex.IsMatch(txb_idSearch.Text, patternCitizen, RegexOptions.IgnoreCase) == false)
                {
                    txb_idSearch.Focus();
                    errorProvider1.SetError(this.txb_idSearch, "กรุณากรอกเลขบัตรประจำตัวประชาชนตามรูปแบบ");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void Txb_idSearch_Leave(object sender, EventArgs e)
        {
            if (Controller.member_type.Equals("student"))
            {
                if (Regex.IsMatch(txb_idSearch.Text, patternCode, RegexOptions.IgnoreCase) == false)
                {
                    txb_idSearch.Focus();
                    errorProvider1.SetError(this.txb_idSearch, "กรุณากรอกรหัสนักศึกษาตามรูปแบบ");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            else
            {
                if (Regex.IsMatch(txb_idSearch.Text, patternCitizen, RegexOptions.IgnoreCase) == false)
                {
                    txb_idSearch.Focus();
                    errorProvider1.SetError(this.txb_idSearch, "กรุณากรอกเลขบัตรประจำตัวประชาชนตามรูปแบบ");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void Btn_search_MouseDown(object sender, EventArgs e)
        {
            btn_search.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            btn_search.ActiveForecolor = System.Drawing.SystemColors.Control;
        }

        private void Btn_search_MouseUp(object sender, MouseEventArgs e)
        {
            btn_search.ActiveForecolor = System.Drawing.Color.Empty;
            btn_search.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_search_MouseHover(object sender, EventArgs e)
        {
            btn_search.ActiveForecolor = System.Drawing.Color.Empty;
            btn_search.ActiveFillColor = System.Drawing.Color.Empty;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

    }
}
