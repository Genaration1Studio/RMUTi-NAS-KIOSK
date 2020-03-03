using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ProfileUser : Form
    {
        private int sec = 0;
        private Thread thr;
        public ProfileUser()
        {
            InitializeComponent();
            int height = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 1366) / 2;
            int width = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - 768) / 2;
            panel_main.Location = new Point(width, height);
            if (Controller.member_type.Equals("student"))
             {
                 lbl_nameTH.Text = "ชื่อ-สกุล :  "+ Controller.cardFName_th + " " + Controller.cardLName_th;
                 lbl_nameEN.Text = "ชื่อ-สกุล (อังกฤษ) :  "+ Controller.cardFName_en + " " + Controller.cardLName_en;
                 lbl_fac.Text = "หลักสูตร :  " + Controller.register.result.curriculum;
                 lbl_dept.Text = "สาขาวิชา :  " + Controller.register.result.program.Substring(8, (Controller.register.result.program.Length)-8);
             }
             else
             {
                 lbl_nameTH.Text = "ชื่อ-สกุล :  " + Controller.cardFName_th + " " + Controller.cardLName_th;
                 lbl_nameEN.Text = "ชื่อ-สกุล (อังกฤษ) :  " + Controller.cardFName_en + " " + Controller.cardLName_en;
                 lbl_fac.Text = "หน่วยงาน :  " + Controller.register.result.department;
                 lbl_dept.Text = "วิทยาเขต :  " + Controller.register.result.campus;
             }
            timer_removeC.Start();
        }

        private void Timer_removeC_Tick(object sender, EventArgs e)
        {
            if (sec == 30)
            {
                timer_removeC.Stop();
                Controller.writeLog("confirm_request _register", "fail", "time out, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login);
                thr = new Thread(openHone);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            if (Controller.checkRemoveCard())
            {
                timer_removeC.Stop();
                Controller.writeLog("confirm_request _register", "fail", "time out, " + "citizen = " + Controller.cardCitizen + ", login = " + Controller.register.result.login);
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
            if (Controller.member_type.Equals("student"))
            {
                Controller.cearEssStd();
            }
            else
            {
                Controller.cearEssSff();
            }
            thr = new Thread(openIDSearch);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            this.Close();
        }

        private void Btn_submit_Click(object sender, EventArgs e)
        {
            timer_removeC.Stop();
            thr = new Thread(openSetpass);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            this.Close();
        }

        private void openIDSearch(object obj)
        {
            Application.Run(new ID_Search());
        }

        private void openSetpass(object obj)
        {
            Application.Run(new Set_Password());
        }

        private void openHone(object obj)
        {
            Application.Run(new Home());
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
