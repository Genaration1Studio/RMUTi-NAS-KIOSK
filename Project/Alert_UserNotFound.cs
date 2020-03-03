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
    public partial class Alert_UserNotFound : Form
    {
        private int sec = 0;
        private Thread thr;
        public Alert_UserNotFound()
        {
            InitializeComponent();
            if (Controller.member_type.Equals("student"))
            {
                lbl_comment1.Text = "ไม่พบข้อมูลนักศึกษา ตามรหัสนักศึกษาที่ป้อน !";
            }
            else
            {
                lbl_comment1.Location = new Point(34, 243);
                lbl_comment1.Text = "ไม่พบข้อมูลบุคลากร ตามเลขบัตรประจำตัวที่ป้อน !";
            }
            timer_removeC.Start();
        }

        private void Btn_subbmit_Click(object sender, EventArgs e)
        {
            Controller.cearController();
            thr = new Thread(openHome);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            this.Hide();
            Alert_EjectCard ejectCard = new Alert_EjectCard();
            ejectCard.ShowDialog();
            this.Close();
        }

        private void Timer_removeC_Tick(object sender, EventArgs e)
        {
            if (Controller.checkRemoveCard())
            {
                timer_removeC.Stop();
                this.Close();
            }
            sec++;
        }

        private void openHome(object obj)
        {
            Application.Run(new Home());
        }

        private void Btn_subbmit_MouseDown(object sender, EventArgs e)
        {
            btn_subbmit.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(139)))), ((int)(((byte)(213)))));
            btn_subbmit.ActiveForecolor = System.Drawing.SystemColors.Window;
        }

        private void Btn_subbmit_MouseUp(object sender, MouseEventArgs e)
        {
            btn_subbmit.ActiveForecolor = System.Drawing.Color.Empty;
            btn_subbmit.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_subbmit_MouseHover(object sender, EventArgs e)
        {
            btn_subbmit.ActiveForecolor = System.Drawing.Color.Empty;
            btn_subbmit.ActiveFillColor = System.Drawing.Color.Empty;
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                return true;  // The key is manually processed
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }     
    }
}
