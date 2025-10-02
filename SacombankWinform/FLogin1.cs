using HtmlAgilityPack;
using SacombankWinform.Constants;
using SacombankWinform.dto;
using SacombankWinform.helper;
using SacombankWinform.services;
using System.Buffers.Text;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Text;

namespace SacombankWinform
{
    public partial class FLogin1 : Form
    {
        SacombankService _sacombankService;
        public FLogin1()
        {
            InitializeComponent();
            _sacombankService = new SacombankService();

            this.AcceptButton = btnLogin;
        }

        private async void FSignup1_Load(object sender, EventArgs e)
        {
            await _sacombankService.LoadLoginPageAsync(GlConstants.ORIGINAL_BASE_URL);

            var captchaImg = await _sacombankService.LoadCaptchaImageAsync(GlConstants.ORIGINAL_BASE_URL);
            if (captchaImg != null)
            {
                pictureBoxCaptcha.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxCaptcha.Image = captchaImg;
            }
        }

        // Gọi khi form đóng để dispose client
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _sacombankService?.Dispose();
            base.OnFormClosed(e);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var dto = new Login1RequestDto(txtUsername.Text, txtCaptcha.Text);

            var actionUrl = _sacombankService.GetActionUrl(GlConstants.ORIGINAL_BASE_URL);

            if (string.IsNullOrEmpty(actionUrl)) return;

            string response;
            try
            {
                response = await _sacombankService.CallLoginApiAsync(dto, actionUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return;
            }

            if (response.Contains("APPLICATION SECURITY ERROR"))
            {
                MessageBox.Show("unauthorized");
            }
            else if (response.Contains("Lỗi Thông báo"))
            {
                MessageBox.Show("Sai thông tin đăng nhập hoặc captcha.");
            }
            else
            {
                FLogin2 fLogin2 = new FLogin2(dto.AuthenticationFG_USER_PRINCIPAL, response);
                this.Hide();
                fLogin2.ShowDialog();
                this.Show();
            }

            FSignup1_Load(sender, e);
        }

        private async void iconRefresh_Click(object sender, EventArgs e)
        {
            var captchaImg = await _sacombankService.RefreshCaptchaImageAsync(GlConstants.ORIGINAL_BASE_URL);
            if (captchaImg != null)
            {
                pictureBoxCaptcha.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxCaptcha.Image = captchaImg;
            }
        }
    }
}
