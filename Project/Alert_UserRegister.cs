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
    public partial class Alert_UserRegister : Form
    {
        private int sec = 0;
        private Thread thr;
        public Alert_UserRegister()
        {
            InitializeComponent();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (sec == 3)
            {
                timer.Stop();
                this.Close();
            }         
            sec++;
        }

        /*private void Btn_subbmit_Click(object sender, EventArgs e)
        {
            if (Controller.checkCitizen())
            {
                //เป็นเจ้าของบัตร -> แก้ไขรหัสผ่าน
                if (Controller.getKey())
                {
                    Controller.capImages("2");
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
                    Controller.capImages("2");
                    Controller.writeLog("request_editpassword", "fail", "not connect api, " + "citizen = " + Controller.cardCitizen);
                    Alert_APINotConnect alert_APINotConnect = new Alert_APINotConnect();
                    this.Hide();
                    thr = new Thread(openHome);
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                    alert_APINotConnect.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                //ไม่ใช่เจ้าของบัตร -> ติดต่อเจ้าของบัตร
                Controller.capImages("2");
                Controller.writeLog("request_editpassword", "fail", "citizen not mathc, " + "citizen = " + Controller.member.result.personalId + ", cardCitizen = " + Controller.cardCitizen);
                Controller.cearController();
                this.Hide();
                Alert_CitizenNotMathc citizenNotMathc = new Alert_CitizenNotMathc();
                citizenNotMathc.ShowDialog();
                this.Close();                  
            }         
        }*/

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
