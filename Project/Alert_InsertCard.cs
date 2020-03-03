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
    public partial class Alert_InsertCard : Form
    {
        private SoundPlayer sound;
        private int sec = 0;
        public Alert_InsertCard()
        {
            InitializeComponent();
            timer_insertC.Start();
            try
            {
                sound = new SoundPlayer(Project.Properties.Resources.Insert);
                sound.Play();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Messeage" + ex.Message);
            }
        }

        private void Timer_insertC_Tick(object sender, EventArgs e)
        {
            if (sec == 50)
            {
                sound.Stop();
                timer_insertC.Stop();
                this.Close();
            }
            if(Controller.checkInsertCard())
            {
                sound.Stop();
                timer_insertC.Stop();
                this.Close();
            }
            sec++;
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
