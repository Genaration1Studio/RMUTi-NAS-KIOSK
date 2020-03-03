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
    public partial class Select_UserType : Form
    {
        private int sec = 0;
        private Thread thr;
        private string policy = "               นโยบายและข้อตกลงการใช้บริการ \n" +
            "บัญชีสมาชิกอินเทอร์เน็ต มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน \n" +
                "\n" +
            "      เพื่อให้เกิดประโยชน์สูงสุด กับบริการใดๆ ของมหาวิทยาลัยฯ \n" +
            "ที่นำบัญชีสมาชิกนี้ไปใช้ มหาวิทยาลัยฯ จึงขอแจ้งให้ผู้ใช้บริการทุก\n" +
            "ท่านทราบว่า มหาวิทยาลัยฯ จำเป็นต้องกำหนดเป็นโยบาย และข้อ\n" +
            "ตกลงขึ้นมา และท่านจะขอใช้บริการ บัญชีสมาชิกอินเทอร์เน็ตได้ \n" +
            "ก็ต่อเมื่อ ท่านยอมรับเงื่อนไขการใช้บริการ บัญชีสมาชิกอินเทอร์\n" +
            "เน็ต ขอให้ท่านอ่านและทำความเข้าใจโดยละเอียด เพื่อรักษาสิทธิ\n" +
            "ประโยชน์ ในการใช้บริการของส่วนรวมและตัวท่านเอง\n" +
            " \n" +

            "1.บัญชีสมาชิกอินเทอร์เน็ต มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน\n" +
            "เป็นระบบบัญชีสมาชิกที่มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน จัด\n" +
            "ทำขึ้นเพื่อให้บริการกับ อาจารย์, เจ้าหน้าที่ และ นักศึกษาของ \n" +
            "มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน เท่านั้น\n" +
            "2.ท่านต้องข้อมูลหรือรายละเอียดส่วนบุคคลที่กรอกในแบบฟอร์มใบ\n" +
            "สมัครสมาชิกที่เป็นจริง ไม่ว่าจะเป็น สังกัดของท่าน, ชื่อ-นามสกุล,\n" +
            "หมายเลขบัตรประจำตัวประชาชน รวมทั้งข้อมูลอื่นเกี่ยวกับตัวท่านที่\n" +
            "ระบบต้องการ\n" +
            "3.บัญชีสมาชิกอินเทอร์เน็ต มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน\n" +
            "เป็นข้อมูลบัญชีสมาชิกที่นำไปใช้กับบริการทางด้านระบบเครือข่ายที่\n" +
            "มหาวิทยาลัยฯ เปิดให้บริการประกอบด้วย บริการอิเล็กทรอนิกส์เมล์\n" +
            "(e-mail), โอมเพจส่วนบุคคล(personal homepage), ระบบประชาสัม\n" +
            "พันธ์ข่าว, เครือข่ายไร้สาย(wireless network) และบริการอื่น \n" +
            "ที่มหาวิทยาลัยฯจะเปิดให้บริการในอนาคต\n" +
            "4.บัญชีสมาชิกอินเทอร์เน็ต มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน\n" +
            "เป็นข้อมูลเฉพาะบุคคล เพื่อความเป็นส่วนตัว จึงเป็นหน้าที่ของท่าน\n" +
            "ในการเก็บรักษาความลับของชื่อบัญชี และรหัสผ่านโดยไม่บอกให้\n" +
            "ผู้อื่นทราบ\n" +
            "5.ห้ามสมาชิกนำบัญชีสมาชิกและบริการของมหาวิทยาลัยที่เกิดจาก\n" +
            "ระบบบัญชีสมาชิกอินเทอร์เน็ต มหาวิทยาลัยเทคโนโลยีราชมงคล\n" +
            "อีสาน ไปใช้ในทางที่ผิด เช่น \n" +
            "       ◉ กิจกรรมที่ผิดกฎหมาย \n" +
            "       ◉ กิจกรรมที่ผิดต่อศีลธรรม จริยธรรม ของสังคม \n" +
            "       ◉ ละเมิดสิทธิ์ต่อบุคคลหรือหน่วยงาน \n" +
            "ทั้งนี้ มหาวิทยาลัยฯ จะไม่รับผิดชอบต่อสิ่งที่ท่านกระทำในทุกกรณี\n" +
            "6.มหาวิทยาลัยฯ ไม่ขอรับประกันความเสียหายของบัญชีสมาชิก\n" +
            "ที่อยู่ในระบบบัญชีสมาชิกอินเทอร์เน็ต มหาวิทยาลัยเทคโนโลยี\n" +
            "ราชมงคลอีสาน ซึ่งอาจไม่สามารถให้บริการได้ตลอด 24 ชั่วโมง\n" +
            "อันเกิดจากเครื่องคอมพิวเตอร์เซิร์ฟเวอร์ที่จัดเก็บ บัญชีสมาชิก \n" +
            "เกิดการเสียหายขึ้นโดยอุบัติเหตุที่ไม่คาดคิด\n" +
            "7.หากมีการเปลี่ยนแปลงข้อตกลงในการให้บริการ มหาวิทยาลัยฯ\n" +
            "จะแจ้งให้ท่านทราบ โดยขึ้นหน้าจอ ข้อตกลงใหม่ เพื่อให้ท่านรับ\n" +
            "ทราบและท่านจะใช้บริการของ ระบบบัญชีสมาชิกอินเทอร์เน็ต\n" +
            "มหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน ต่อไปได้\n" +
            "8.หากมหาวิทยาลัยฯ ตรวจสอบพบว่าสมาชิก ละเมิดข้อตกลงที่\n" +
            "ได้กำหนดไว้ มหาวิทยาลัยฯ ขอสงวนสิทธิ์ในการระงับการให้\n" +
            "บริการกับสมาชิกท่านนั้นโดยมิต้องบอกกล่าวล่วงหน้า";

        public Select_UserType()
        {           
            InitializeComponent();
            int height = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 1366) / 2;
            int width = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - 768) / 2;
            panel_main.Location = new Point(width, height);
            lbl_policy.Text = policy;
            /*if (Controller.mode.Equals("register"))
            {
                lbl_head.Text = "เลือกประเภทบัญชีสมาชิก (ขั้นตอนที่ 1/4) ";
            }
            else
            {
                lbl_head.Text = "เลือกประเภทบัญชีสมาชิก (ขั้นตอนที่ 1/2) ";
            }*/
            timer_removeC.Start();
        }

        private void Timer_removeC_Tick(object sender, EventArgs e)
        {
            if (sec == 30)
            {
                timer_removeC.Stop();
                Controller.writeLog("select_membertype", "fail", "time out, " + "citizen = " + Controller.cardCitizen);
                thr = new Thread(openHone);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            if (Controller.checkRemoveCard())
            {
                timer_removeC.Stop();
                Controller.writeLog("select_membertype", "fail", "time out, " + "citizen = " + Controller.cardCitizen);
                thr = new Thread(openHone);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
            sec++;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            timer_removeC.Stop();
            thr = new Thread(openHone);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            this.Close();
        }

        private void openHone(object obj)
        {
            Application.Run(new Home());
        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            if (checkbox_cf.Checked == true)
            {
                timer_removeC.Stop();
                Controller.member_type = "student";   
                Controller.writeLog("select_membertype", "success", "student, " + "citizen = " + Controller.cardCitizen);
                thr = new Thread(openIDSearch);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }       
        }

        private void Btn_personnel_Click(object sender, EventArgs e)
        {
            if (checkbox_cf.Checked == true)
            {
                timer_removeC.Stop();
                Controller.member_type = "staff";
                Controller.writeLog("select_membertype", "success", "staff, " + "citizen = " + Controller.cardCitizen);
                thr = new Thread(openIDSearch);
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
                this.Close();
            }
        }

        private void openIDSearch(object obj)
        {
            Application.Run(new ID_Search());
        }

        private void openHome(object obj)
        {
            Application.Run(new Home());
        }

        private void Btn_personnel_MouseDown(object sender, EventArgs e)
        {
            btn_personnel.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            btn_personnel.ActiveForecolor = System.Drawing.SystemColors.Control;
        }

        private void Btn_personnel_MouseUp(object sender, MouseEventArgs e)
        {
            btn_personnel.ActiveForecolor = System.Drawing.Color.Empty;
            btn_personnel.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_personnel_MouseHover(object sender, EventArgs e)
        {
            btn_personnel.ActiveForecolor = System.Drawing.Color.Empty;
            btn_personnel.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_student_MouseDown(object sender, EventArgs e)
        {
            btn_student.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            btn_student.ActiveForecolor = System.Drawing.SystemColors.Control;
        }

        private void Btn_student_MouseUp(object sender, MouseEventArgs e)
        {
            btn_student.ActiveForecolor = System.Drawing.Color.Empty;
            btn_student.ActiveFillColor = System.Drawing.Color.Empty;
        }

        private void Btn_student_MouseHover(object sender, EventArgs e)
        {
            btn_student.ActiveForecolor = System.Drawing.Color.Empty;
            btn_student.ActiveFillColor = System.Drawing.Color.Empty;
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
