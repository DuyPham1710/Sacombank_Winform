using SacombankWinform.Constants;
using SacombankWinform.models;
using SacombankWinform.services;
using System;
using System.Buffers.Text;
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
    public partial class FHome : Form
    {
        SacombankService _sacombankService;
        private string html;
        private Form activeChildForm = null;
        List<AccountInfo> accounts;
        public FHome(SacombankService sacombankService, string html)
        {
            InitializeComponent();
            _sacombankService = sacombankService;
            this.html = html;
            accounts = new List<AccountInfo>();
        }
        private async void FHome_Load(object sender, EventArgs e)
        {
            _sacombankService.updateHtml(html);

            string urlFinacleRiaRequest = _sacombankService.getUrlBalanceFromHtml(GlConstants.ORIGINAL_BASE_URL);

            try
            {
                string data = await _sacombankService.GetBalanceAsync(urlFinacleRiaRequest);
                if (!string.IsNullOrEmpty(data))
                {
                    accounts = _sacombankService.ExtractAccountInfo(data);
                }
            }
            catch (Exception ex)
            {
                // ignore and show empty dashboard
                System.Diagnostics.Debug.WriteLine($"GetBalance error: {ex.Message}");
            }

            var dashboard = new DashboardForm(accounts);
            OpenChildForm(dashboard);

            lblUserName.Text = loadFullName();
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
            }
            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildHost.Controls.Clear();
            panelChildHost.Controls.Add(childForm);
            childForm.Show();
        }

        //private void SetupDataGridView()
        //{
        //    // Xóa cột cũ nếu có
        //    dataGridViewBalance.Columns.Clear();

        //    // Thêm cột
        //    dataGridViewBalance.Columns.Add("TenGoiNho", "Tên gợi nhớ");
        //    dataGridViewBalance.Columns.Add("LoaiTaiKhoan", "Loại tài khoản");
        //    dataGridViewBalance.Columns.Add("SoDuKhaDung", "Số dư khả dụng");

        //    // Auto size mode fill để chiếm hết chiều rộng
        //    foreach (DataGridViewColumn col in dataGridViewBalance.Columns)
        //    {
        //        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    }

        //    // Nếu muốn các cột đều nhau
        //    int columnCount = dataGridViewBalance.Columns.Count;
        //    foreach (DataGridViewColumn col in dataGridViewBalance.Columns)
        //    {
        //        col.FillWeight = 100 / columnCount; // ví dụ 3 cột thì mỗi cột chiếm 33%
        //    }

        //    // Không cho user tự thêm row
        //    dataGridViewBalance.AllowUserToAddRows = false;
        //    dataGridViewBalance.RowHeadersVisible = false;
        //}

        private string loadFullName()
        {
            string name = _sacombankService.GetTextById("firstName_header");
            string midName = _sacombankService.GetTextById("midName_header");
            string lastName = _sacombankService.GetTextById("lastName_header");
            string corpName = _sacombankService.GetTextById("corpName");

            // Nối lại (bỏ null/empty)
            var parts = new List<string> { name, midName, lastName, corpName }
                .Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join(" ", parts);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transferWithinSacombankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var transferForm = new TransferWithinForm();
            OpenChildForm(transferForm);
        }

        private void transferToOtherBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var transferForm = new TransferToOtherBankForm(accounts);
            OpenChildForm(transferForm);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dashboard = new DashboardForm(accounts);
            OpenChildForm(dashboard);
        }
        //// Gọi khi form đóng để dispose client
        //protected override void OnFormClosed(FormClosedEventArgs e)
        //{
        //    _sacombankService?.Dispose();
        //    base.OnFormClosed(e);
        //}

    }
}
