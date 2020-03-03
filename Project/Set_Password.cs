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
    public partial class Set_Password : Form
    {
        private int sec = 0;
        private Thread thr;
        private string patternPassword = @"^[\w-]{8,}$";
        private string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private string patternPhoneNumber = @"^((\(?[0]{1,1},*-?[9,8,6]{1,1}\)?-?,*([0-9]{4}-?),*-?[0-9]{4})-?,*$)";
        private string keyboardPath = Path.Combine(@"C:\Program Files\Common Files\Microsoft Shared\ink", "TabTip.exe");
        private Process keyboardProc;
        public Set_Password()
        {
            InitializeComponent();
            int height = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 1366) / 2;
            int width = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - 768) / 2;
            panel_main.Location = new Point(width, height);
            if (Controller.mode.Equals("register"))
            {
                lbl_name.Text = "ชื่อ-สกุล :  " + Controller.cardFName_th + " " + Controller.cardLName_th;
                lbl_account.Text = "ชื่อบัญชี :  " + Controller.register.result.login;
                lbl_head.Text = "กำหนดรหัสผ่าน (ขั้นตอนที่ 4/4)";
                //txb_tel.Text = Controller.DecryptString(Controller.register.result.phoneNumber);
                txb_tel.Text = Controller.register.result.phoneNumber;
            }
            else
            {
                lbl_name.Text = "ชื่อ-สกุล :  " + Controller.cardFName_th + " " + Controller.cardLName_th;
                lbl_account.Text = "ชื่อบัญชี :  " + Controller.member.result.login;
                lbl_head.Text = "กำหนดรหัสผ่าน (ขั้นตอนที่ 1/1)";
                //txb_tel.Text = Controller.DecryptString(Controller.member.result.phoneNumber);
                txb_tel.Text = Controller.member.result.phoneNumber;
            }
            
            label5.Visible = false;
            txb_email.Visible = false;
            txtb_passcon.isPassword = true;
            //texb_ConPass.PasswordChar = '●';
            txtb_pass.Focus();
            showOnScreenKey();           
            timer_removeC.Start();
        }

        private void Timer_removeC_Tick(object sender, EventArgs e)
        {
            if (sec == 300)
            {
                timer_removeC.Stop();
                if (Controller.mode.Equals("register"))
                {
                    Controller.writeLog("put_password", "fail", "register, time out, " + "citizen = " + Controller.cardCitizen);
                }
                else
                {
                    Controller.writeLog("put_password", "fail", "edit_password, time out, " + "citizen = " + Controller.cardCitizen);
                }
                thr = new Thread(openHone);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            if (Controller.checkRemoveCard())
            {
                timer_removeC.Stop();
                if (Controller.mode.Equals("register"))
                {
                    Controller.writeLog("put_password", "fail", "register, time out, " + "citizen = " + Controller.cardCitizen);
                }
                else
                {
                    Controller.writeLog("put_password", "fail", "edit_password, time out, " + "citizen = " + Controller.cardCitizen);
                }
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
            if (Controller.mode.Equals("edit_password"))
            {
                thr = new Thread(openHome);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            else
            {
                thr = new Thread(openProfilesUser);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
          
        }

        private void openProfilesUser(object obj)
        {
            Application.Run(new ProfileUser());
        }

        private void openHone(object obj)
        {
            Application.Run(new Home());
        }

        private void Btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_pass.Text) == true)
            {
                txtb_pass.Focus();
                txtb_pass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_pass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_pass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));             
            }
            else if (txtb_pass.Text != texb_ConPass.Text)
            {
                texb_ConPass.Focus();
                txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            /*else if (string.IsNullOrEmpty(txb_email.Text) == true)
            {
                txb_email.Focus();
                errorProvider3.SetError(this.txb_email, "กรุณากรอกอีเมล์สำรอง");
            }*/
            else if (string.IsNullOrEmpty(txb_tel.Text) == true)
            {
                txb_tel.Focus();
                txb_tel.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else if (Regex.IsMatch(txb_tel.Text, patternPhoneNumber, RegexOptions.IgnoreCase) == false)
            {
                txb_tel.Focus();
                txb_tel.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else 
            {
                Alert_Loading alert_Loading = new Alert_Loading();
                alert_Loading.Show();
                Controller.errMeg = "";
                if (Controller.putEdit(txtb_pass.Text,"password"))
                {
                    //แก้ไขรหัสผ่านได้
                    if(Controller.putEdit(txb_tel.Text, "phoneNumber"))
                    {
                        //แก้ไขเบอร์โทรได้                       
                        timer_removeC.Stop();                       
                        if (Controller.mode.Equals("register"))
                        {
                            Controller.capImages("3");
                            Controller.writeLog("put_password", "success", "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        else
                        {
                            Controller.capImages("2");
                            Controller.writeLog("put_password", "success", "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }                                                 
                        Alert_EditSuccess alert_EditSuccess = new Alert_EditSuccess();
                        Alert_RegisSuccess alert_Regis = new Alert_RegisSuccess();
                        thr = new Thread(openHome);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                        this.Hide();
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        lbl_head.Visible = false;
                        btn_submit.Visible = false;
                        btn_back.Visible = false;
                        label7.Visible = false;
                        label6.Visible = false;
                        alert_Loading.Close();
                        if (Controller.mode.Equals("register"))
                        {
                            alert_Regis.ShowDialog();
                        }
                        else
                        {
                            alert_EditSuccess.ShowDialog();
                        }              
                        Controller.cearController();
                        this.Close();
                    }
                    else if (Controller.errMeg.Equals("Server Error"))
                    {                       
                        Controller.errMeg = "";
                        if (Controller.mode.Equals("register"))
                        {
                            Controller.capImages("3");
                            Controller.writeLog("put_phonenumber", "fail", "not connect api Error 500, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        else
                        {
                            Controller.capImages("2");
                            Controller.writeLog("put_phonenumber", "fail", "not connect api Error 500, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        alert_Loading.Close();
                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                        alert_APINotConnect.ShowDialog();
                    }
                    else if (Controller.edit.message.Substring(0, 16).Equals("Modify failstaff"))
                    {
                        //พบบุคคลที่ร้องขอแต่ดำเนินการไม่สำเร็จ                        
                        if (Controller.mode.Equals("register"))
                        {
                            Controller.capImages("3");
                            Controller.writeLog("put_phonenumber", "fail", "not modify, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        else
                        {
                            Controller.capImages("2");
                            Controller.writeLog("put_phonenumber", "fail", "not modify, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        Alert_NotModify alert_NotModify = new Alert_NotModify();
                        thr = new Thread(openHome);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                        this.Hide();
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        lbl_head.Visible = false;
                        btn_submit.Visible = false;
                        btn_back.Visible = false;
                        label7.Visible = false;
                        label6.Visible = false;
                        alert_Loading.Close();
                        alert_NotModify.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //ไม่สามารถติดต่อระบบได้                              
                        if (Controller.mode.Equals("register"))
                        {
                            Controller.capImages("3");
                            Controller.writeLog("put_phonenumber", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        else
                        {
                            Controller.capImages("2");
                            Controller.writeLog("put_phonenumber", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                        }
                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                        thr = new Thread(openHome);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                        this.Hide();
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        lbl_head.Visible = false;
                        btn_submit.Visible = false;
                        btn_back.Visible = false;
                        label7.Visible = false;
                        label6.Visible = false;
                        alert_Loading.Close();
                        alert_APINotConnect.ShowDialog();
                        this.Close();
                    }
                }
                else if (Controller.errMeg.Equals("Server Error"))
                {                  
                    Controller.errMeg = "";
                    if (Controller.mode.Equals("register"))
                    {
                        Controller.capImages("3");
                        Controller.writeLog("put_password", "fail", "not connect api Error 500, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                    }
                    else
                    {
                        Controller.capImages("2");
                        Controller.writeLog("put_password", "fail", "not connect api Error 500, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                    }
                    alert_Loading.Close();
                    Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                    alert_APINotConnect.ShowDialog();
                }
                else if (Controller.edit.message.Substring(0, 16).Equals("Modify failstaff"))
                {
                    //พบบุคคลที่ร้องขอแต่ดำเนินการไม่สำเร็จ                     
                    if (Controller.mode.Equals("register"))
                    {
                        Controller.capImages("3");
                        Controller.writeLog("put_password", "fail", "not modify, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                    }
                    else
                    {
                        Controller.capImages("2");
                        Controller.writeLog("put_password", "fail", "not modify, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                    }
                    Alert_NotModify alert_NotModify = new Alert_NotModify();
                    thr = new Thread(openHome);
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                    this.Hide();
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    lbl_head.Visible = false;
                    btn_submit.Visible = false;
                    btn_back.Visible = false;
                    label7.Visible = false;
                    label6.Visible = false;
                    alert_Loading.Close();
                    alert_NotModify.ShowDialog();
                    this.Close();
                }
                else
                {
                    //ไม่สามารถติดต่อระบบได้                             
                    if (Controller.mode.Equals("register"))
                    {
                        Controller.capImages("3");
                        Controller.writeLog("put_password", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                    }
                    else
                    {
                        Controller.capImages("2");
                        Controller.writeLog("put_password", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.member.result.login + ", email = " + txb_email.Text + ", phonenumber = " + txb_tel.Text);
                    }
                    Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                    thr = new Thread(openHome);
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                    this.Hide();
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    lbl_head.Visible = false;
                    btn_submit.Visible = false;
                    btn_back.Visible = false;
                    label7.Visible = false;
                    label6.Visible = false;
                    alert_Loading.Close();
                    alert_APINotConnect.ShowDialog();
                    this.Close();
                }
                                  
            }
        }

        private void openHome(object obj)
        {
            Application.Run(new Home());
        }

        public void showOnScreenKey()
        {
            this.keyboardProc = Process.Start(keyboardPath);
        }

        public void hideOnScreenKey()
        {
           // Process[] oskProcessArray = Process.GetProcessesByName("WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe");
            //this.keyboardProc.Kill();
        }

        private void Txtb_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtb_pass.Text.Length < 8)
            {
                txtb_pass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_pass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_pass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                if (Regex.IsMatch(txtb_pass.Text, patternPassword, RegexOptions.IgnoreCase) == true)
                {
                    txtb_pass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_pass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_pass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(192)))), ((int)(((byte)(189)))));
                }
            }
            
        }

        private void Txtb_pass_Leave(object sender, EventArgs e)
        {
            if (txtb_pass.Text.Length < 8)
            {
                txtb_pass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_pass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_pass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                if (Regex.IsMatch(txtb_pass.Text, patternPassword, RegexOptions.IgnoreCase) == true)
                {
                    txtb_pass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_pass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_pass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(192)))), ((int)(((byte)(189)))));
                }
            }
        }

        private void Txtb_pass_MouseEnter(object sender, EventArgs e)
        {
            showOnScreenKey();
        }


        private void Texb_ConPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (texb_ConPass.Text.Length < 8)
            {
                txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                if (texb_ConPass.Text.Equals(txtb_pass.Text))
                {
                    txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(192)))), ((int)(((byte)(189)))));
                }
                else
                {
                    txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                }
            }
        }

        private void Txtb_ConPass_Leave(object sender, EventArgs e)
        {
            if (texb_ConPass.Text.Length < 8)
            {
                txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                if (texb_ConPass.Text.Equals(txtb_pass.Text))
                {
                    txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(192)))), ((int)(((byte)(189)))));
                }
                else
                {
                    txtb_passcon.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    txtb_passcon.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    txtb_passcon.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                }
            }
        }

        private void Texb_ConPass_MouseEnter(object sender, EventArgs e)
        {
            showOnScreenKey();
        }


        private void Txb_email_KeyUp(object sender, KeyEventArgs e)
        {
           /* if (Regex.IsMatch(txb_email.Text, patternEmail, RegexOptions.IgnoreCase) == false)
            {
                //txb_email.Focus();
                errorProvider3.SetError(this.txb_email, "กรุณากรอกอีเมล์สำรอง");
            }
            else
            {
                errorProvider3.Clear();
            }*/
        }

        private void Txb_email_Leave(object sender, EventArgs e)
        {

           /* if (Regex.IsMatch(txb_email.Text, patternEmail, RegexOptions.IgnoreCase) == false)
            {
                //txb_email.Focus();
                errorProvider3.SetError(this.txb_email, "กรุณากรอกอีเมล์สำรอง");
            }
            else
            {
                errorProvider3.Clear();
            }*/
        }

        private void Txb_email_MouseEnter(object sender, EventArgs e)
        {
            showOnScreenKey();
        }

        private void Txb_tel_KeyUp(object sender, KeyEventArgs e)
        {
            if (txb_tel.Text.Length < 10 || txb_tel.Text.Length > 10)
            {
                txb_tel.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                if (Regex.IsMatch(txb_tel.Text, patternPhoneNumber, RegexOptions.IgnoreCase) == true)
                {
                    txb_tel.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txb_tel.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txb_tel.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(192)))), ((int)(((byte)(189)))));
                }
            }
        }

        private void Txb_tel_Leave(object sender, EventArgs e)
        {
            if (txb_tel.Text.Length < 10 || txb_tel.Text.Length > 10)
            {
                txb_tel.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txb_tel.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                if (Regex.IsMatch(txb_tel.Text, patternPhoneNumber, RegexOptions.IgnoreCase) == true)
                {
                    txb_tel.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txb_tel.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
                    txb_tel.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(192)))), ((int)(((byte)(189)))));
                }
            }
        }

        private void Txb_tel_MouseEnter(object sender, EventArgs e)
        {
            showOnScreenKey();
        }     

        private void Pic_SHPass1_MouseDown(object sender, MouseEventArgs e)
        {
            pic_SHPass1.BackgroundImage = Properties.Resources.visible_filled_500px;
            txtb_pass.isPassword = false;
        }

        private void Pic_SHPass1_MouseUp(object sender, MouseEventArgs e)
        {
            pic_SHPass1.BackgroundImage = Properties.Resources.hide_filled_500px;
            txtb_pass.isPassword = true;
        }

        private void Pic_SHPass2_MouseDown(object sender, MouseEventArgs e)
        {
            pic_SHPass2.BackgroundImage = Properties.Resources.visible_filled_500px;
            texb_ConPass.UseSystemPasswordChar = false;
        }

        private void Pic_SHPass2_MouseUp(object sender, MouseEventArgs e)
        {
            pic_SHPass2.BackgroundImage = Properties.Resources.hide_filled_500px;
            texb_ConPass.UseSystemPasswordChar = true;
        }

        private void Btn_submit_MouseDown(object sender, EventArgs e)
        {
            btn_submit.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            btn_submit.ActiveForecolor = System.Drawing.SystemColors.Control;
        }

        private void Btn_submit_MouseUp(object sender, MouseEventArgs e)
        {
            btn_submit.ActiveForecolor = System.Drawing.Color.Empty;
            btn_submit.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_submit_MouseHover(object sender, EventArgs e)
        {
            btn_submit.ActiveForecolor = System.Drawing.Color.Empty;
            btn_submit.ActiveFillColor = System.Drawing.Color.Empty;
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
