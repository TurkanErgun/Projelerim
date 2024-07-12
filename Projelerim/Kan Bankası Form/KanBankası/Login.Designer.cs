namespace KanBankası
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KullaniciTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SifreTb = new System.Windows.Forms.TextBox();
            this.girisbtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(83, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kan Bankası Yönetim Sistemi";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(95, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // KullaniciTb
            // 
            this.KullaniciTb.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KullaniciTb.Location = new System.Drawing.Point(237, 186);
            this.KullaniciTb.Name = "KullaniciTb";
            this.KullaniciTb.Size = new System.Drawing.Size(215, 32);
            this.KullaniciTb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(169, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // SifreTb
            // 
            this.SifreTb.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SifreTb.Location = new System.Drawing.Point(237, 236);
            this.SifreTb.Name = "SifreTb";
            this.SifreTb.PasswordChar = '*';
            this.SifreTb.Size = new System.Drawing.Size(215, 32);
            this.SifreTb.TabIndex = 3;
            this.SifreTb.TextChanged += new System.EventHandler(this.SifreTb_TextChanged);
            // 
            // girisbtn
            // 
            this.girisbtn.ActiveBorderThickness = 1;
            this.girisbtn.ActiveCornerRadius = 20;
            this.girisbtn.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.girisbtn.ActiveForecolor = System.Drawing.Color.White;
            this.girisbtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.girisbtn.BackColor = System.Drawing.Color.White;
            this.girisbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("girisbtn.BackgroundImage")));
            this.girisbtn.ButtonText = "Giriş";
            this.girisbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.girisbtn.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girisbtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.girisbtn.IdleBorderThickness = 1;
            this.girisbtn.IdleCornerRadius = 20;
            this.girisbtn.IdleFillColor = System.Drawing.Color.Red;
            this.girisbtn.IdleForecolor = System.Drawing.Color.White;
            this.girisbtn.IdleLineColor = System.Drawing.Color.Red;
            this.girisbtn.Location = new System.Drawing.Point(180, 292);
            this.girisbtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.girisbtn.Name = "girisbtn";
            this.girisbtn.Size = new System.Drawing.Size(272, 59);
            this.girisbtn.TabIndex = 4;
            this.girisbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.girisbtn.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(283, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(203, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Admin olarak devam et";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(585, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(611, 396);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.girisbtn);
            this.Controls.Add(this.SifreTb);
            this.Controls.Add(this.KullaniciTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KullaniciTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SifreTb;
        private Bunifu.Framework.UI.BunifuThinButton2 girisbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}