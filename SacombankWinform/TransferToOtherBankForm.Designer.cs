namespace SacombankWinform
{
    partial class TransferToOtherBankForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferToOtherBankForm));
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label11 = new Label();
            panel8 = new Panel();
            label10 = new Label();
            button1 = new Button();
            lblBalance = new Label();
            panel7 = new Panel();
            cbTaiKhoan = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            panel6 = new Panel();
            panel5 = new Panel();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1122, 1055);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(68, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(982, 932);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(radioButton3);
            panel4.Controls.Add(radioButton2);
            panel4.Controls.Add(radioButton1);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(lblBalance);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(cbTaiKhoan);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(dateTimePicker1);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(982, 842);
            panel4.TabIndex = 1;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(624, 473);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(124, 24);
            radioButton3.TabIndex = 23;
            radioButton3.TabStop = true;
            radioButton3.Text = "Nhận tiền mặt";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(411, 473);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(195, 24);
            radioButton2.TabIndex = 22;
            radioButton2.TabStop = true;
            radioButton2.Text = "Nhận bằng tài khoản/thẻ";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(198, 473);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(190, 24);
            radioButton1.TabIndex = 21;
            radioButton1.TabStop = true;
            radioButton1.Text = "Người thụ hưởng đã lưu";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(29, 538);
            label11.Name = "label11";
            label11.Size = new Size(178, 23);
            label11.TabIndex = 20;
            label11.Text = "Nội dung thanh toán";
            // 
            // panel8
            // 
            panel8.BackColor = Color.Black;
            panel8.Location = new Point(2, 519);
            panel8.Name = "panel8";
            panel8.Size = new Size(978, 1);
            panel8.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(29, 422);
            label10.Name = "label10";
            label10.Size = new Size(233, 23);
            label10.TabIndex = 18;
            label10.Text = "Thông tin người thụ hưởng";
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(737, 304);
            button1.Name = "button1";
            button1.Size = new Size(209, 48);
            button1.TabIndex = 17;
            button1.Text = "THÔNG TIN TÀI KHOẢN";
            button1.UseVisualStyleBackColor = false;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(473, 356);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(116, 20);
            lblBalance.TabIndex = 16;
            lblBalance.Text = "Số dư khả dụng:";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Black;
            panel7.Location = new Point(2, 397);
            panel7.Name = "panel7";
            panel7.Size = new Size(978, 1);
            panel7.TabIndex = 15;
            // 
            // cbTaiKhoan
            // 
            cbTaiKhoan.ForeColor = SystemColors.HotTrack;
            cbTaiKhoan.FormattingEnabled = true;
            cbTaiKhoan.Items.AddRange(new object[] { "Chọn" });
            cbTaiKhoan.Location = new Point(473, 315);
            cbTaiKhoan.Name = "cbTaiKhoan";
            cbTaiKhoan.Size = new Size(242, 28);
            cbTaiKhoan.TabIndex = 14;
            cbTaiKhoan.Text = "Chọn";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(334, 324);
            label9.Name = "label9";
            label9.Size = new Size(96, 19);
            label9.TabIndex = 13;
            label9.Text = "Tài khoản:*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(29, 292);
            label8.Name = "label8";
            label8.Size = new Size(204, 23);
            label8.TabIndex = 12;
            label8.Text = "Cá nhân/Đơn vị chuyển";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Black;
            panel6.Location = new Point(2, 271);
            panel6.Name = "panel6";
            panel6.Size = new Size(978, 1);
            panel6.TabIndex = 11;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Location = new Point(2, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(978, 1);
            panel5.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.ForeColor = SystemColors.HotTrack;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Một lần", "Định kỳ" });
            comboBox1.Location = new Point(473, 116);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 28);
            comboBox1.TabIndex = 10;
            comboBox1.Text = "Một lần";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(473, 164);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(242, 27);
            dateTimePicker1.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(473, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 27);
            textBox1.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(473, 226);
            label7.Name = "label7";
            label7.Size = new Size(40, 20);
            label7.TabIndex = 5;
            label7.Text = "VND";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(372, 124);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 4;
            label6.Text = "Tần suất";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(327, 169);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 3;
            label5.Text = "Ngày giao dịch*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(367, 226);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 2;
            label4.Text = "Loại tiền:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(327, 82);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 1;
            label3.Text = "Tên tham chiếu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 25);
            label2.Name = "label2";
            label2.Size = new Size(152, 23);
            label2.TabIndex = 0;
            label2.Text = "Chi tiết giao dịch";
            // 
            // panel3
            // 
            panel3.BackColor = Color.RoyalBlue;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(982, 90);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(68, 50);
            label1.Name = "label1";
            label1.Size = new Size(413, 32);
            label1.TabIndex = 0;
            label1.Text = "Chuyển tiền đến Ngân hàng khác";
            // 
            // TransferToOtherBankForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 1055);
            Controls.Add(panel1);
            Name = "TransferToOtherBankForm";
            Text = "Chuyển tiền đến ngân hàng khác";
            Load += TransferToOtherBankForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Panel panel4;
        private TextBox textBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private Panel panel7;
        private ComboBox cbTaiKhoan;
        private Label label9;
        private Label label8;
        private Panel panel6;
        private Panel panel5;
        private Label lblBalance;
        private Label label11;
        private Panel panel8;
        private Label label10;
        private Button button1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}