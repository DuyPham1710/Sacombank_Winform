using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using SacombankWinform.Constants;
using SacombankWinform.dto;
using SacombankWinform.helper;
using SacombankWinform.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SacombankWinform
{
    public partial class FLogin2 : Form
    {
        SacombankService _sacombankService;
        private string html;
        public FLogin2(SacombankService sacombankService, string username, string html)
        {
            InitializeComponent();
            _sacombankService = sacombankService;
           
            txtUsername.Text = username;
            this.html = html;

            this.AcceptButton = btnLogin;
        }

        private void FLogin2_Load(object sender, EventArgs e)
        {
            _sacombankService.updateHtml(html);
            //     await _sacombankService.LoadLoginPageAsync(urlFormLogin1);

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string isChecked = "N";
            if (cbVerify.Checked)
            {
                isChecked = "Y";
            }
            else
            {
                MessageBox.Show("Quý khách vui lòng xác nhận Hình ảnh và Ghi chú trước khi tiếp tục", "Thông báo");
                return;
            }
            var encryptKey = _sacombankService.GetJsEncryptKey();

            var encryptedValues = JCryptionHelper.EncryptLogin(txtPassword.Text, encryptKey);

            string dummy1 = encryptedValues["dummy1"];
            string accessCode = encryptedValues["AuthenticationFG.ACCESS_CODE"];
            string dummy2 = encryptedValues["dummy2"];

            //      MessageBox.Show("dummy1: " + dummy1 + " \naccess_code: " + accessCode + " \ndummy2: " + dummy2);

            var dto = new Login2RequestDto(isChecked, txtUsername.Text, dummy1, accessCode, dummy2);

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
                this.Close();
            }
            else if (response.Contains("Lỗi Thông báo"))
            {
                MessageBox.Show("Invalid Password");
                _sacombankService.updateHtml(response);
            }
            else
            {
                _sacombankService.updateHtml(response);

                // Load số dư
                //string urlFinacleRiaRequest = _sacombankService.getUrlBalanceFromHtml(GlConstants.ORIGINAL_BASE_URL);
                //MessageBox.Show(urlFinacleRiaRequest);
                //string data = await _sacombankService.GetBalanceAsync(urlFinacleRiaRequest);

                //MessageBox.Show(data);
                FHome fHome = new FHome(_sacombankService, response);
                this.Hide();
                fHome.ShowDialog();
                this.Close();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Gọi khi form đóng để dispose client
        //protected override void OnFormClosed(FormClosedEventArgs e)
        //{
        //    _sacombankService?.Dispose();
        //    base.OnFormClosed(e);
        //}

        private void btnReEnter_Click(object sender, EventArgs e)
        {
            txtPassword.Text = string.Empty;
        }
    }
}
