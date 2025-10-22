using SacombankWinform.models;
using System.Windows.Forms;

namespace SacombankWinform
{
    public partial class TransferToOtherBankForm : Form
    {
        List<AccountInfo> accounts;
        public TransferToOtherBankForm()
        {
            InitializeComponent();
            lblBalance.Visible = false;
        }

        public TransferToOtherBankForm(List<AccountInfo> accounts) : this()
        {
            this.accounts = accounts;
        }

        private void TransferToOtherBankForm_Load(object sender, EventArgs e)
        {
            cbTaiKhoan.Items.Clear();
            cbTaiKhoan.Items.Add("Chọn");

            // Thêm các tài khoản vào ComboBox
            foreach (var acc in accounts)
            {
                cbTaiKhoan.Items.Add($"(VND) - {acc.TenGoiNho}");
            }
 
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
            int index = cbTaiKhoan.SelectedIndex - 1; // vì index 0 là "Chọn"
            var selectedAcc = accounts[index];

            // Cập nhật label và hiển thị
            lblBalance.Text = $"Số dư khả dụng: {selectedAcc.SoDuKhaDung} VND";
            lblBalance.Visible = true;
        }
    }
}