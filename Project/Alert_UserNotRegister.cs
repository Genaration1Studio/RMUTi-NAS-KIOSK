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
    public partial class Alert_UserNotRegister : Form
    {
        private int sec = 0;
        private Thread thr;
        public Alert_UserNotRegister()
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

        /*   private void Btn_subbmit_Click(object sender, EventArgs e)
           {
                Controller.mode = "register";
                Controller.writeLog("request_register", "success", Controller.member_type + ", citizen = " + Controller.cardCitizen);
                thr = new Thread(openIDSearch);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();          
           }

           private void Btn_cencel_Click(object sender, EventArgs e)
           {
               Controller.writeLog("request_register", "fail", "cancel, " + "citizen = " + Controller.cardCitizen);
               Controller.cearController();
               this.Hide();
               thr = new Thread(openHome);
               thr.SetApartmentState(ApartmentState.STA);
               thr.Start();
               Alert_EjectCard ejectCard = new Alert_EjectCard();
               ejectCard.ShowDialog();
               this.Close();
           }

           private void openHome(object obj)
           {
               Application.Run(new Home());
           }

           private void openIDSearch(object obj)
           {
               Application.Run(new ID_Search());
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
