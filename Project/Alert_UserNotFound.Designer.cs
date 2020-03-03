namespace Project
{
    partial class Alert_UserNotFound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert_UserNotFound));
            this.bunifuElipse_UsernotFound = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_comment1 = new System.Windows.Forms.Label();
            this.lbl_comment2 = new System.Windows.Forms.Label();
            this.btn_subbmit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.timer_removeC = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_UsernotFound
            // 
            this.bunifuElipse_UsernotFound.ElipseRadius = 50;
            this.bunifuElipse_UsernotFound.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Project.Properties.Resources.cancel_500px;
            this.pictureBox1.Location = new System.Drawing.Point(184, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_comment1
            // 
            this.lbl_comment1.AutoSize = true;
            this.lbl_comment1.Font = new System.Drawing.Font("RSU", 24.23762F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comment1.ForeColor = System.Drawing.Color.Red;
            this.lbl_comment1.Location = new System.Drawing.Point(57, 243);
            this.lbl_comment1.Name = "lbl_comment1";
            this.lbl_comment1.Size = new System.Drawing.Size(566, 50);
            this.lbl_comment1.TabIndex = 2;
            this.lbl_comment1.Text = "ไม่พบข้อมูลนักศึกษา ตามรหัสนักศึกษาที่ป้อน !";
            this.lbl_comment1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_comment2
            // 
            this.lbl_comment2.AutoSize = true;
            this.lbl_comment2.Font = new System.Drawing.Font("Ekkamai Standard", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comment2.ForeColor = System.Drawing.Color.Black;
            this.lbl_comment2.Location = new System.Drawing.Point(111, 308);
            this.lbl_comment2.Name = "lbl_comment2";
            this.lbl_comment2.Size = new System.Drawing.Size(472, 70);
            this.lbl_comment2.TabIndex = 3;
            this.lbl_comment2.Text = "ระบบจะให้บริการเฉพาะบุคลากรหรือนักศึกษา\r\nของมหาวิทยาลัยเทคโนโลยีราชมงคลอีสาน เท่า" +
    "นั้น";
            this.lbl_comment2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_subbmit.Location = new System.Drawing.Point(218, 397);
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
            // timer_removeC
            // 
            this.timer_removeC.Interval = 1000;
            // 
            // Alert_UserNotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(671, 500);
            this.Controls.Add(this.btn_subbmit);
            this.Controls.Add(this.lbl_comment2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_comment1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alert_UserNotFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert_UserNotFound";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_UsernotFound;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_comment1;
        private System.Windows.Forms.Label lbl_comment2;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_subbmit;
        private System.Windows.Forms.Timer timer_removeC;
    }
}