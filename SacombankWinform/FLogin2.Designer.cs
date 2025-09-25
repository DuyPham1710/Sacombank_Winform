namespace SacombankWinform
{
    partial class FLogin2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin2));
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            txtPassword = new TextBox();
            btnBack = new Button();
            button1 = new Button();
            cbVerify = new CheckBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            txtUsername = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1398, 766);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(btnBack);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(cbVerify);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(txtUsername);
            panel2.Location = new Point(877, 48);
            panel2.Name = "panel2";
            panel2.Size = new Size(466, 673);
            panel2.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(57, 414);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "MẬT KHẨU";
            txtPassword.Size = new Size(353, 27);
            txtPassword.TabIndex = 12;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DodgerBlue;
            btnBack.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(237, 553);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(173, 61);
            btnBack.TabIndex = 11;
            btnBack.Text = "QUAY LẠI";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(57, 553);
            button1.Name = "button1";
            button1.Size = new Size(174, 61);
            button1.TabIndex = 10;
            button1.Text = "NHẬP LẠI";
            button1.UseVisualStyleBackColor = false;
            // 
            // cbVerify
            // 
            cbVerify.Location = new Point(77, 276);
            cbVerify.Name = "cbVerify";
            cbVerify.Size = new Size(314, 55);
            cbVerify.TabIndex = 9;
            cbVerify.Text = "Tôi xác nhận Hình ảnh và Ghi chú hiển thị như trên đúng với sự lựa chọn của tôi";
            cbVerify.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(129, 104);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(195, 157);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(129, 79);
            label2.Name = "label2";
            label2.Size = new Size(195, 22);
            label2.TabIndex = 7;
            label2.Text = "Ghi chú: Chợ bến thành";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 35);
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
            btnLogin.Location = new Point(57, 486);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(353, 61);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Enabled = false;
            txtUsername.Location = new Point(57, 359);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "TÊN ĐĂNG NHẬP";
            txtUsername.Size = new Size(353, 27);
            txtUsername.TabIndex = 0;
            // 
            // FLogin2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 766);
            Controls.Add(panel2);
            Controls.Add(pictureBox1);
            Name = "FLogin2";
            Text = "FLogin2";
            Load += FLogin2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private PictureBox pictureBoxCaptcha;
        private Label label1;
        private Button btnLogin;
        private CheckBox checkBox1;
        private TextBox txtCaptcha;
        private TextBox txtUsername;
        private CheckBox cbVerify;
        private Button btnBack;
        private Button button1;
        private TextBox txtPassword;
    }
}