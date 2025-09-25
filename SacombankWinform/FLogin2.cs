using SacombankWinform.dto;
using SacombankWinform.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SacombankWinform
{
    public partial class FLogin2 : Form
    {
        SacombankService _sacombankService;
        public FLogin2(string username)
        {
            InitializeComponent();
            _sacombankService = new SacombankService();
            txtUsername.Text = username;
        }
        private void FLogin2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string isChecked = "N";
            if (cbVerify.Checked)
            {
                isChecked = "Y";
            }

            var dto = new Login2RequestDto(isChecked, txtUsername.Text, "", "", "");

            
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Gọi khi form đóng để dispose client
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _sacombankService?.Dispose();
            base.OnFormClosed(e);
        }

    }
}
