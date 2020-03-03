namespace Project
{
    partial class Alert_CitizenNotMathc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert_CitizenNotMathc));
            this.bunifuElipse_AlertCitizenNotMathc = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_comment1 = new System.Windows.Forms.Label();
            this.lbl_comment_head = new System.Windows.Forms.Label();
            this.btn_subbmit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.timer_removeC = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_AlertCitizenNotMathc
            // 
            this.bunifuElipse_AlertCitizenNotMathc.ElipseRadius = 50;
            this.bunifuElipse_AlertCitizenNotMathc.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Project.Properties.Resources.security_block_500px;
            this.pictureBox1.Location = new System.Drawing.Point(174, 168);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_comment1
            // 
            this.lbl_comment1.AutoSize = true;
            this.lbl_comment1.Font = new System.Drawing.Font("Ekkamai Standard", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comment1.ForeColor = System.Drawing.Color.Black;
            this.lbl_comment1.Location = new System.Drawing.Point(188, 444);
            this.lbl_comment1.Name = "lbl_comment1";
            this.lbl_comment1.Size = new System.Drawing.Size(257, 35);
            this.lbl_comment1.TabIndex = 4;
            this.lbl_comment1.Text = "- กรุณาติดต่อเจ้าของบัตร";
            // 
            // lbl_comment_head
            // 
            this.lbl_comment_head.AutoSize = true;
            this.lbl_comment_head.Font = new System.Drawing.Font("RSU", 25.66336F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comment_head.ForeColor = System.Drawing.Color.Red;
            this.lbl_comment_head.Location = new System.Drawing.Point(36, 52);
            this.lbl_comment_head.Name = "lbl_comment_head";
            this.lbl_comment_head.Size = new System.Drawing.Size(597, 106);
            this.lbl_comment_head.TabIndex = 2;
            this.lbl_comment_head.Text = "รหัสบัตรประจำตัวประชาชนบนบัตร\r\nไม่ตรงกับรหัสบัตรประจำตัวประชาชนบนระบบ !";
            this.lbl_comment_head.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_subbmit
            // 
            this.btn_subbmit.ActiveBorderThickness = 1;
            this.btn_subbmit.ActiveCornerRadius = 70;
            this.btn_subbmit.ActiveFillColor = System.Drawing.Color.Empty;
            this.btn_subbmit.ActiveForecolor = System.Drawing.Color.Empty;
            this.btn_subbmit.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(139)))), ((int)(((byte)(213)))));
            this.btn_subbmit.BackColor = System.Drawing.SystemColors.Window;
            this.btn_subbmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_subbmit.BackgroundImage")));
            this.btn_subbmit.ButtonText = "ตกลง";
            this.btn_subbmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_subbmit.Font = new System.Drawing.Font("RSU", 24.23762F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_subbmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(139)))), ((int)(((byte)(213)))));
            this.btn_subbmit.IdleBorderThickness = 1;
            this.btn_subbmit.IdleCornerRadius = 70;
            this.btn_subbmit.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btn_subbmit.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(139)))), ((int)(((byte)(213)))));
            this.btn_subbmit.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(139)))), ((int)(((byte)(213)))));
            this.btn_subbmit.Location = new System.Drawing.Point(219, 495);
            this.btn_subbmit.Margin = new System.Windows.Forms.Padding(5);
            this.btn_subbmit.Name = "btn_subbmit";
            this.btn_subbmit.Size = new System.Drawing.Size(226, 82);
            this.btn_subbmit.TabIndex = 1;
            this.btn_subbmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_subbmit.Click += new System.EventHandler(this.Btn_subbmit_Click);
            this.btn_subbmit.MouseDown += new System.EventHandler(this.Btn_subbmit_MouseDown);
            this.btn_subbmit.MouseHover += new System.EventHandler(this.Btn_subbmit_MouseHover);
            this.btn_subbmit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_subbmit_MouseUp);
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Font = new System.Drawing.Font("Sukhumvit Set", 22.09901F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comment.ForeColor = System.Drawing.Color.Black;
            this.lbl_comment.Location = new System.Drawing.Point(86, 395);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(132, 35);
            this.lbl_comment.TabIndex = 3;
            this.lbl_comment.Text = "ข้อแนะนำ";
            // 
            // timer_removeC
            // 
            this.timer_removeC.Interval = 1000;
            this.timer_removeC.Tick += new System.EventHandler(this.Timer_removeC_Tick);
            // 
            // Alert_CitizenNotMathc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(671, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_comment1);
            this.Controls.Add(this.lbl_comment_head);
            this.Controls.Add(this.btn_subbmit);
            this.Controls.Add(this.lbl_comment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alert_CitizenNotMathc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert_CitizenNotMathc";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_AlertCitizenNotMathc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_comment1;
        private System.Windows.Forms.Label lbl_comment_head;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_subbmit;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.Timer timer_removeC;
    }
}