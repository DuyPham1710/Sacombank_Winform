using SacombankWinform.models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SacombankWinform
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        public DashboardForm(List<AccountInfo> accounts) : this()
        {
            SetupDataGridView();
            SetAccounts(accounts);
        }

        public void SetAccounts(List<AccountInfo> accounts)
        {
            dataGridViewAccounts.Rows.Clear();
            foreach (var acct in accounts)
            {
                dataGridViewAccounts.Rows.Add(acct.TenGoiNho, acct.LoaiTaiKhoan, acct.SoDuKhaDung);
            }
        }


        private void SetupDataGridView()
        {
            // Xóa cột cũ nếu có
            dataGridViewAccounts.Columns.Clear();

            // Thêm cột
            dataGridViewAccounts.Columns.Add("TenGoiNho", "Tên gợi nhớ");
            dataGridViewAccounts.Columns.Add("LoaiTaiKhoan", "Loại tài khoản");
            dataGridViewAccounts.Columns.Add("SoDuKhaDung", "Số dư khả dụng");

            // Auto size mode fill để chiếm hết chiều rộng
            foreach (DataGridViewColumn col in dataGridViewAccounts.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Nếu muốn các cột đều nhau
            int columnCount = dataGridViewAccounts.Columns.Count;
            foreach (DataGridViewColumn col in dataGridViewAccounts.Columns)
            {
                col.FillWeight = 100 / columnCount; // ví dụ 3 cột thì mỗi cột chiếm 33%
            }

            // Không cho user tự thêm row
            dataGridViewAccounts.AllowUserToAddRows = false;
            dataGridViewAccounts.RowHeadersVisible = false;
        }
    }
}