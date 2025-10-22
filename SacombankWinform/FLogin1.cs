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
        private Microsoft.Web.WebView2.WinForms.WebView2 _webView;
        public FLogin1()
        {
            InitializeComponent();
            _sacombankService = new SacombankService();

            this.AcceptButton = btnLogin;
        }

        private async void FSignup1_Load(object sender, EventArgs e)
        {
            try
            {
                _webView = new Microsoft.Web.WebView2.WinForms.WebView2();
                _webView.Visible = false;
                _webView.CreateControl();
                this.Controls.Add(_webView);
                await _webView.EnsureCoreWebView2Async();

                // Điều hướng sang trang login (WebView2 sẽ chạy JS trên trang)
                _webView.CoreWebView2.Navigate(GlConstants.ORIGINAL_BASE_URL);

                // đợi navigation hoàn tất
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                void handler(object s, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs a)
                {
                    tcs.TrySetResult(true);
                }

                _webView.CoreWebView2.NavigationCompleted += handler;
                await tcs.Task;
                _webView.CoreWebView2.NavigationCompleted -= handler;

                // Lấy sessionStorage.xNum
                string script = "window.sessionStorage.getItem('xNum');";
                var result = await _webView.CoreWebView2.ExecuteScriptAsync(script);
                // result is quoted JSON string or null
                string xNum = null;
                if (!string.IsNullOrEmpty(result) && result != "null")
                {
                    try { xNum = System.Text.Json.JsonSerializer.Deserialize<string>(result); } 
                    catch { xNum = result.Trim('"'); }
                }

                if (!string.IsNullOrEmpty(xNum))
                {
                    _sacombankService.SetXNum(xNum);
                  //  MessageBox.Show(xNum);
                }

                // Import tất cả cookie từ WebView2 CookieManager -> CookieContainer
               
                    var cookieManager = _webView.CoreWebView2.CookieManager;
                    var cwCookies = await cookieManager.GetCookiesAsync("https://www.isacombank.com.vn");
                    foreach (var c in cwCookies)
                    {
                        // CoreWebView2Cookie properties: Name, Value, Domain, Path, IsHttpOnly, IsSecure, Expires (nullable DateTimeOffset)
                        DateTime? expires = null;
                     
                        _sacombankService.AddCookie(
                            c.Name, 
                            c.Value, 
                            c.Domain ?? ".isacombank.com.vn", 
                            c.Path ?? "/", 
                            c.IsSecure, 
                            c.IsHttpOnly, 
                            expires
                        );
                    }


                // After importing cookies and xNum we still also populate the parsed HTML in service for other scraping
                var loginHtml = await _webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
                string loginHtmlStr = string.Empty;
                if (!string.IsNullOrEmpty(loginHtml) && loginHtml != "null")
                {
                    try { loginHtmlStr = System.Text.Json.JsonSerializer.Deserialize<string>(loginHtml); } catch { loginHtmlStr = loginHtml.Trim('"'); }
                }
                if (!string.IsNullOrEmpty(loginHtmlStr))
                {
                    _sacombankService.updateHtml(loginHtmlStr);
                  //  System.IO.File.WriteAllText("debugLogin1.html", loginHtmlStr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"WebView2 init error: {ex.Message}");
                // fallback to HttpClient fetch
                await _sacombankService.LoadLoginPageAsync(GlConstants.ORIGINAL_BASE_URL);
            }

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
            try
            {
                if (pictureBoxCaptcha.Image != null)
                {
                    pictureBoxCaptcha.Image.Dispose();
                }

                if (_webView?.CoreWebView2 != null)
                {
                    _webView.CoreWebView2.Stop();
                    _webView.CoreWebView2.Navigate("about:blank");
                }

                _webView?.Dispose();
                _sacombankService?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Dispose error: {ex.Message}");
            }
            finally
            {
                base.OnFormClosed(e);
            }
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
                FLogin2 fLogin2 = new FLogin2(_sacombankService, dto.AuthenticationFG_USER_PRINCIPAL, response);
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
