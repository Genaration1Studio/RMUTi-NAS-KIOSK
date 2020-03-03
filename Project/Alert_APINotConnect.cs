using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Alert_APINotConnect : Form
    {
        private SoundPlayer sound;
        private int sec = 0;
        public Alert_APINotConnect()
        {
            InitializeComponent();
            timer_removeC.Start();
            try
            {
                sound = new SoundPlayer(Project.Properties.Resources.Remove);
                sound.Play();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Messeage" + ex.Message);
            }
        }

        private void Timer_removeC_Tick(object sender, EventArgs e)
        {
            if (sec == 3)
            {
                Controller.writeLog("", "card not eject", "");
            }
            if (Controller.checkRemoveCard())
            {
                sound.Stop();
                timer_removeC.Stop();
                this.Close();
            }
            sec++;
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
