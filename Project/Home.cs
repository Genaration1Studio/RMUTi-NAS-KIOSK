using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Home : Form
    {
        private Thread thr;
        public Home()
        {          
            InitializeComponent();
            int height = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 1366) / 2;
            int width = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - 768) / 2;
            panel_main.Location = new Point(width, height);
            slidePic.ImageLocation = Controller.pathImg_Slide + @"1.jpg";          
        }

        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if(imageNumber == Controller.countImgSlide())
            {
                imageNumber = 1;
            }
            slidePic.ImageLocation = string.Format( Controller.pathImg_Slide + @"{0}.jpg",imageNumber);
            imageNumber++;
        }

        private void slideTime_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Alert_Loading alert_Loading = new Alert_Loading();
            Controller.app_token = File.ReadAllText(Controller.path + @"\Token.txt", Encoding.UTF8);
            Controller.createDir();
            Controller.mode = "register";
            Controller.errMeg = "";
            //if (Controller.checkInsertCard())
            //{
                //บัตรเสียบอยู่
                if (Controller.readCard())
                {
                    alert_Loading.Show();
                    if (Controller.getMember())
                    {
                    //เจอบัญชีผู้ใช้งาน
                        alert_Loading.Close();
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "success", "found, " + "citizen = " + Controller.cardCitizen);
                        Alert_UserRegister userRegister = new Alert_UserRegister();
                        userRegister.ShowDialog();
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
                    else if (Controller.member.message.Equals("Unauthorized access to this API"))
                    {
                    //ไม่สามารถติดต่อระบบได้
                        alert_Loading.Close();
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen);
                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                        alert_APINotConnect.ShowDialog();
                    }
                    else
                    {
                    //ไม่เจอบัญชีผู้ใช้งาน
                        alert_Loading.Close();
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "fail", "not found, " + "citizen = " + Controller.cardCitizen);
                        thr = new Thread(openSelectUserType);
                        thr.SetApartmentState(ApartmentState.STA);
                        thr.Start();
                        this.Close();
                    }
                }
                else
                {
                /*Controller.writeLog(Controller.mode, "fail", "card not read");
                Alert_CardNotRead cardNotRead = new Alert_CardNotRead();
                cardNotRead.ShowDialog();*/
                    //alert_Loading.Close();
                    Controller.writeLog(Controller.mode, "fail", "card not mount");
                    Alert_InsertCard insertCard = new Alert_InsertCard();
                    insertCard.ShowDialog();
                }
            /*}
            else
            {
                //ไม่ได้เสียบบัตร
                Controller.writeLog(Controller.mode, "fail", "card not mount");
                Alert_InsertCard insertCard = new Alert_InsertCard();
                insertCard.ShowDialog();
            }*/           
        }

        private void Btn_setPass_Click(object sender, EventArgs e)
        {
            Alert_Loading alert_Loading = new Alert_Loading();        
            Controller.app_token = File.ReadAllText(Controller.path + @"\Token.txt", Encoding.UTF8);
            Controller.createDir();
            Controller.mode = "edit_password";
            Controller.errMeg = "";
            //if (Controller.checkInsertCard())
            //{
                //บัตรเสียบอยู่
                if (Controller.readCard())
                {
                    alert_Loading.Show();
                    if (Controller.getMember())
                    {
                        //เจอบัญชีผู้ใช้งานs
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "success", "found, " + "citizen = " + Controller.cardCitizen);
                        if (Controller.checkCitizen())
                        {
                            //เป็นเจ้าของบัตร -> แก้ไขรหัสผ่าน
                            if (Controller.getKey())
                            {
                                alert_Loading.Close();
                                Controller.mode = "edit_password";
                                Controller.writeLog("request_editpassword", "success", "citizen = " + Controller.cardCitizen);
                                thr = new Thread(openSetpass);
                                thr.SetApartmentState(ApartmentState.STA);
                                thr.Start();

                                this.Close();
                            }
                            else
                            {
                                //ไม่สามารถติดต่อระบบได้    
                                alert_Loading.Close();
                                Controller.writeLog("request_editpassword", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen);
                                Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                                alert_APINotConnect.ShowDialog();
                            }
                        }
                        else
                        {
                            //ไม่ใช่เจ้าของบัตร -> ติดต่อเจ้าของบัตร
                            alert_Loading.Close();
                            Controller.writeLog("request_editpassword", "fail", "citizen not mathc, " + "citizen = " + Controller.member.result.personalId + ", cardCitizen = " + Controller.cardCitizen);
                            Controller.cearController();
                            Alert_CitizenNotMathc citizenNotMathc = new Alert_CitizenNotMathc();
                            citizenNotMathc.ShowDialog();
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
                    else if (Controller.member.message.Equals("Unauthorized access to this API"))
                    {
                        //ไม่สามารถติดต่อระบบได้
                        alert_Loading.Close();
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen);
                        Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                        alert_APINotConnect.ShowDialog();
                    }
                    else
                    {
                        //ไม่เจอบัญชีผู้ใช้งาน
                        alert_Loading.Close();
                        Controller.capImages("1");
                        Controller.writeLog("verify_account", "fail", "not found, " + "citizen = " + Controller.cardCitizen);
                        Alert_UserNotRegister alert_UserNotRegister = new Alert_UserNotRegister();
                        alert_UserNotRegister.ShowDialog();
                    }
                }
                else
                {
                /*Controller.writeLog(Controller.mode, "fail", "card not read");
                Alert_CardNotRead cardNotRead = new Alert_CardNotRead();
                cardNotRead.ShowDialog();*/
                //alert_Loading.Close();
                Controller.writeLog(Controller.mode, "fail", "card not mount");
                Alert_InsertCard insertCard = new Alert_InsertCard();
                insertCard.ShowDialog();
                }
           /* }
            else
            {
                //ไม่ได้เสียบบัตร
                Controller.writeLog(Controller.mode, "fail", "card not mount");
                Alert_InsertCard insertCard = new Alert_InsertCard();
                insertCard.ShowDialog();
            }   */         
        }

        private void Btn_register_MouseDown(object sender, EventArgs e)
        {
            btn_register.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            btn_register.ActiveForecolor = System.Drawing.SystemColors.Control;
        }

        private void Btn_register_MouseUp(object sender, MouseEventArgs e)
        {
            btn_register.ActiveForecolor = System.Drawing.Color.Empty;
            btn_register.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_register_MouseHover(object sender, EventArgs e)
        {
            btn_register.ActiveForecolor = System.Drawing.Color.Empty;
            btn_register.ActiveFillColor = System.Drawing.Color.Empty;
        }
        private void Btn_setPass_MouseDown(object sender, EventArgs e)
        {
            btn_setPass.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            btn_setPass.ActiveForecolor = System.Drawing.SystemColors.Control;
        }

        private void Btn_setPass_MouseUp(object sender, MouseEventArgs e)
        {
            btn_setPass.ActiveForecolor = System.Drawing.Color.Empty;
            btn_setPass.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_setPass_MouseHover(object sender, EventArgs e)
        {
            btn_setPass.ActiveForecolor = System.Drawing.Color.Empty;
            btn_setPass.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void openSelectUserType(object obj)
        {
            Application.Run(new Select_UserType());
        }

        private void openSetpass(object obj)
        {
            Application.Run(new Set_Password());
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
