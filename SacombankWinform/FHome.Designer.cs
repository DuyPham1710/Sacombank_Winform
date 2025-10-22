namespace SacombankWinform
{
    partial class FHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHome));
            label1 = new Label();
            panel1 = new Panel();
            panelChildHost = new Panel();
            panel2 = new Panel();
            btnLogout = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            lblUserName = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            tÀIKHOẢNToolStripMenuItem = new ToolStripMenuItem();
            tÀIKHOẢNVÀTHẺToolStripMenuItem = new ToolStripMenuItem();
            tIỀNGỬITRỰCTUYẾNToolStripMenuItem = new ToolStripMenuItem();
            gIAODỊCHToolStripMenuItem = new ToolStripMenuItem();
            cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem = new ToolStripMenuItem();
            transferWithinSacombankToolStripMenuItem = new ToolStripMenuItem();
            transferToOtherBankToolStripMenuItem = new ToolStripMenuItem();
            tHANHTOÁNToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(456, 257);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 0;
            label1.Text = "Home Page";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panelChildHost);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1886, 1004);
            panel1.TabIndex = 1;
            // 
            // panelChildHost
            // 
            panelChildHost.AutoScroll = true;
            panelChildHost.BackgroundImage = (Image)resources.GetObject("panelChildHost.BackgroundImage");
            panelChildHost.Dock = DockStyle.Fill;
            panelChildHost.Location = new Point(0, 94);
            panelChildHost.Name = "panelChildHost";
            panelChildHost.Size = new Size(1886, 910);
            panelChildHost.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(lblUserName);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(menuStrip1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1886, 94);
            panel2.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.Transparent;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            btnLogout.IconColor = Color.Black;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.Location = new Point(1808, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(54, 54);
            btnLogout.TabIndex = 3;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // iconButton1
            // 
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = Color.Transparent;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(1255, 20);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(54, 54);
            iconButton1.TabIndex = 2;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(1327, 33);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(50, 20);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "label2";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(93, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tÀIKHOẢNToolStripMenuItem, gIAODỊCHToolStripMenuItem });
            menuStrip1.Location = new Point(362, 66);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(205, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // tÀIKHOẢNToolStripMenuItem
            // 
            tÀIKHOẢNToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tÀIKHOẢNVÀTHẺToolStripMenuItem, tIỀNGỬITRỰCTUYẾNToolStripMenuItem });
            tÀIKHOẢNToolStripMenuItem.Name = "tÀIKHOẢNToolStripMenuItem";
            tÀIKHOẢNToolStripMenuItem.Size = new Size(100, 24);
            tÀIKHOẢNToolStripMenuItem.Text = "TÀI KHOẢN";
            // 
            // tÀIKHOẢNVÀTHẺToolStripMenuItem
            // 
            tÀIKHOẢNVÀTHẺToolStripMenuItem.Name = "tÀIKHOẢNVÀTHẺToolStripMenuItem";
            tÀIKHOẢNVÀTHẺToolStripMenuItem.Size = new Size(242, 26);
            tÀIKHOẢNVÀTHẺToolStripMenuItem.Text = "TÀI KHOẢN VÀ THẺ";
            // 
            // tIỀNGỬITRỰCTUYẾNToolStripMenuItem
            // 
            tIỀNGỬITRỰCTUYẾNToolStripMenuItem.Name = "tIỀNGỬITRỰCTUYẾNToolStripMenuItem";
            tIỀNGỬITRỰCTUYẾNToolStripMenuItem.Size = new Size(242, 26);
            tIỀNGỬITRỰCTUYẾNToolStripMenuItem.Text = "TIỀN GỬI TRỰC TUYẾN";
            // 
            // gIAODỊCHToolStripMenuItem
            // 
            gIAODỊCHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem, tHANHTOÁNToolStripMenuItem });
            gIAODỊCHToolStripMenuItem.Name = "gIAODỊCHToolStripMenuItem";
            gIAODỊCHToolStripMenuItem.Size = new Size(97, 24);
            gIAODỊCHToolStripMenuItem.Text = "GIAO DỊCH";
            // 
            // cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem
            // 
            cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { transferWithinSacombankToolStripMenuItem, transferToOtherBankToolStripMenuItem });
            cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem.Name = "cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem";
            cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem.Size = new Size(283, 26);
            cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem.Text = "CHUYỂN TIỀN TRONG NƯỚC";
            // 
            // transferWithinSacombankToolStripMenuItem
            // 
            transferWithinSacombankToolStripMenuItem.Name = "transferWithinSacombankToolStripMenuItem";
            transferWithinSacombankToolStripMenuItem.Size = new Size(306, 26);
            transferWithinSacombankToolStripMenuItem.Text = "Chuyển tiền trong sacombank";
            transferWithinSacombankToolStripMenuItem.Click += transferWithinSacombankToolStripMenuItem_Click;
            // 
            // transferToOtherBankToolStripMenuItem
            // 
            transferToOtherBankToolStripMenuItem.Name = "transferToOtherBankToolStripMenuItem";
            transferToOtherBankToolStripMenuItem.Size = new Size(306, 26);
            transferToOtherBankToolStripMenuItem.Text = "Chuyển tiền đến ngân hàng khác";
            transferToOtherBankToolStripMenuItem.Click += transferToOtherBankToolStripMenuItem_Click;
            // 
            // tHANHTOÁNToolStripMenuItem
            // 
            tHANHTOÁNToolStripMenuItem.Name = "tHANHTOÁNToolStripMenuItem";
            tHANHTOÁNToolStripMenuItem.Size = new Size(283, 26);
            tHANHTOÁNToolStripMenuItem.Text = "THANH TOÁN ";
            // 
            // FHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 1004);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "FHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FHome";
            WindowState = FormWindowState.Maximized;
            Load += FHome_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panelChildHost;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label lblUserName;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnLogout;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tÀIKHOẢNToolStripMenuItem;
        private ToolStripMenuItem tÀIKHOẢNVÀTHẺToolStripMenuItem;
        private ToolStripMenuItem tIỀNGỬITRỰCTUYẾNToolStripMenuItem;
        private ToolStripMenuItem gIAODỊCHToolStripMenuItem;
        private ToolStripMenuItem cHUYỂNTIỀNTRONGNƯỚCToolStripMenuItem;
        private ToolStripMenuItem transferWithinSacombankToolStripMenuItem;
        private ToolStripMenuItem transferToOtherBankToolStripMenuItem;
        private ToolStripMenuItem tHANHTOÁNToolStripMenuItem;
    }
}