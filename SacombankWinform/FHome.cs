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
        public FHome(SacombankService sacombankService, string html)
        {
            InitializeComponent();
            _sacombankService = sacombankService;
            this.html = html;
        }
        private async void FHome_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            _sacombankService.updateHtml(html);
            
            // Load số dư
            string urlFinacleRiaRequest =  _sacombankService.getUrlBalanceFromHtml(GlConstants.ORIGINAL_BASE_URL);
            //MessageBox.Show($"Balance URL: {urlFinacleRiaRequest}");
            
            // Debug headers trước khi gửi request
         //   _sacombankService.PrintRequestHeaders(urlFinacleRiaRequest);
            
            try
            {
                string data = await _sacombankService.GetBalanceAsync(urlFinacleRiaRequest);
                
                if (!string.IsNullOrEmpty(data))
                {
                  //  System.IO.File.WriteAllText("balance_response_debug.html", data);

                    var accounts = _sacombankService.ExtractAccountInfo(data);
                    dataGridViewBalance.Rows.Clear();
                    foreach (var acct in accounts)
                    {
                        dataGridViewBalance.Rows.Add(acct.TenGoiNho, acct.LoaiTaiKhoan, acct.SoDuKhaDung);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting balance: {ex.Message}");
            }

            lblUserName.Text = loadFullName();
        }

        private void SetupDataGridView()
        {
            // Xóa cột cũ nếu có
            dataGridViewBalance.Columns.Clear();

            // Thêm cột
            dataGridViewBalance.Columns.Add("TenGoiNho", "Tên gợi nhớ");
            dataGridViewBalance.Columns.Add("LoaiTaiKhoan", "Loại tài khoản");
            dataGridViewBalance.Columns.Add("SoDuKhaDung", "Số dư khả dụng");

            // Auto size mode fill để chiếm hết chiều rộng
            foreach (DataGridViewColumn col in dataGridViewBalance.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Nếu muốn các cột đều nhau
            int columnCount = dataGridViewBalance.Columns.Count;
            foreach (DataGridViewColumn col in dataGridViewBalance.Columns)
            {
                col.FillWeight = 100 / columnCount; // ví dụ 3 cột thì mỗi cột chiếm 33%
            }

            // Không cho user tự thêm row
            dataGridViewBalance.AllowUserToAddRows = false;
            dataGridViewBalance.RowHeadersVisible = false;
        }

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
        //// Gọi khi form đóng để dispose client
        //protected override void OnFormClosed(FormClosedEventArgs e)
        //{
        //    _sacombankService?.Dispose();
        //    base.OnFormClosed(e);
        //}

    }
}
