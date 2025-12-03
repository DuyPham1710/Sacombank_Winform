using SacombankWinform.Constants;
using SacombankWinform.models;
using SacombankWinform.services;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SacombankWinform
{
    public partial class TransferToOtherBankForm : Form
    {
        SacombankService _sacombankService;
        private string actionUrl;
        public TransferToOtherBankForm(SacombankService sacombankService, string actionUrl)
        {
            InitializeComponent();
            _sacombankService = sacombankService;
            lblBalance.Visible = false;
            this.actionUrl = actionUrl;
        }

        private async void TransferToOtherBankForm_Load(object sender, EventArgs e)
        {
            //    string urlTransferRequest = _sacombankService.getBaseUrlFromScriptHtml(GlConstants.ORIGINAL_BASE_URL, "PageConfigurationMaster_CMGPMTW__1");
            string hrefTransferUrl = _sacombankService.getHrefTransferAsync(GlConstants.ORIGINAL_BASE_URL);
            //  MessageBox.Show(hrefTransferUrl, "hrefTransferUrl");
         //   System.Diagnostics.Debug.WriteLine($">>> hrefTransferUrl: {hrefTransferUrl}");
            if (hrefTransferUrl != null)
            {
                await _sacombankService.LoadTransferPageAsync(hrefTransferUrl, actionUrl);
            }
            //    MessageBox.Show(urlTransferRequest);
            cbTaiKhoan.Items.Clear();
            cbTaiKhoan.Items.Add("Chọn");

            // Thêm các tài khoản vào ComboBox
            //foreach (var acc in accounts)
            //{
            //    cbTaiKhoan.Items.Add($"(VND) - {acc.TenGoiNho}");
            //}

            cbTaiKhoan.SelectedIndex = 0;

            cbTaiKhoan.SelectedIndexChanged += CbTaiKhoan_SelectedIndexChanged;
        }

        private void CbTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTaiKhoan.SelectedIndex <= 0)
            {
                // Nếu chọn "Chọn" thì ẩn label
                lblBalance.Visible = false;
                return;
            }

            // Lấy tài khoản được chọn
            //int index = cbTaiKhoan.SelectedIndex - 1; // vì index 0 là "Chọn"
            //var selectedAcc = accounts[index];

            //// Cập nhật label và hiển thị
            //lblBalance.Text = $"Số dư khả dụng: {selectedAcc.SoDuKhaDung} VND";
            //lblBalance.Visible = true;
        }
    }
}