namespace SacombankWinform
{
    partial class FLogin1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin1));
            panel1 = new Panel();
            panel2 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            pictureBoxCaptcha = new PictureBox();
            label1 = new Label();
            btnLogin = new Button();
            checkBox1 = new CheckBox();
            txtCaptcha = new TextBox();
            txtUsername = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1398, 766);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(pictureBoxCaptcha);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(txtCaptcha);
            panel2.Controls.Add(txtUsername);
            panel2.Location = new Point(809, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(466, 530);
            panel2.TabIndex = 1;
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            iconButton1.IconColor = Color.DodgerBlue;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(396, 192);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(43, 44);
            iconButton1.TabIndex = 6;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCaptcha
            // 
            pictureBoxCaptcha.Location = new Point(255, 181);
            pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            pictureBoxCaptcha.Size = new Size(125, 62);
            pictureBoxCaptcha.TabIndex = 5;
            pictureBoxCaptcha.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 48);
            label1.Name = "label1";
            label1.Size = new Size(353, 22);
            label1.TabIndex = 2;
            label1.Text = "Chào mừng Quý khách đến với iSacombank";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(57, 323);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(353, 61);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(57, 270);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(256, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Đăng nhập bằng ứng dụng mSign";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Location = new Point(57, 192);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.PlaceholderText = "MÃ XÁC NHẬN";
            txtCaptcha.Size = new Size(182, 27);
            txtCaptcha.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(57, 126);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "TÊN ĐĂNG NHẬP";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1398, 766);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FLogin1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 766);
            Controls.Add(panel1);
            Name = "FLogin1";
            Text = "FLogin1";
            Load += FSignup1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label1;
        private TextBox txtCaptcha;
        private TextBox txtUsername;
        private Button btnLogin;
        private CheckBox checkBox1;
        private PictureBox pictureBoxCaptcha;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
