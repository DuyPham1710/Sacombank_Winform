using SacombankWinform.dto;
using SacombankWinform.helper;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SacombankWinform.services
{

    public class SacombankService
    {
        private readonly CookieContainer _cookieJar = new CookieContainer();
        private HttpClient _httpClient;
        private HtmlAgilityPack.HtmlDocument _doc;
      
        public SacombankService()
        {
            InitHttpClient();
        }

        private void InitHttpClient()
        {
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                AllowAutoRedirect = true,
                CookieContainer = _cookieJar,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _httpClient = new HttpClient(handler);
            // Thêm header mô phỏng trình duyệt
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public void updateHtml(string html)
        {
         //   File.WriteAllText("debugHomePage.html", html);
            _doc = new HtmlAgilityPack.HtmlDocument();
            _doc.LoadHtml(html);
        }
        public async Task LoadLoginPageAsync(string url)
        {       
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();
         //   File.WriteAllText("debugLogin1.html", html);
            _doc = new HtmlAgilityPack.HtmlDocument();
            _doc.LoadHtml(html);
        }

        public async Task<System.Drawing.Image?> LoadCaptchaImageAsync(string baseUrl)
        {
            if (_doc == null) return null;

            var spanNode = _doc.DocumentNode.SelectSingleNode("//span[@id='LoginHDisplay.Rc1.C2']");
            if (spanNode == null) return null;

            var imgNode = spanNode.SelectSingleNode(".//img[@src]");
            if (imgNode == null) return null;

            string src = imgNode.GetAttributeValue("src", "").Trim();
            if (string.IsNullOrEmpty(src)) return null;

            // Nếu src là relative -> chuyển thành absolute
            string imageUrl = src;
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                var baseUri = new Uri(baseUrl);
                imageUrl = new Uri(baseUri, src).ToString();
            }

            // Tải ảnh bằng cùng HttpClient 
            var imgResponse = await _httpClient.GetAsync(imageUrl);
            imgResponse.EnsureSuccessStatusCode();
            using var ms = new MemoryStream();
            await imgResponse.Content.CopyToAsync(ms);
            ms.Position = 0;

            return System.Drawing.Image.FromStream(ms);
        }

        public async Task<System.Drawing.Image?> RefreshCaptchaImageAsync(string baseUrl)
        {
            await LoadLoginPageAsync(baseUrl);

            return await LoadCaptchaImageAsync(baseUrl);
        }

        public string? GetActionUrl(string baseUrl)
        {
            if (_doc == null) return null;

            var formNode = _doc.DocumentNode.SelectSingleNode("//form");
            var action = formNode?.GetAttributeValue("action", "");

            if (string.IsNullOrEmpty(action)) return null;
            
            Uri baseUri = new Uri(baseUrl);
            Uri actionUri = new Uri(baseUri, action);
            
            return actionUri.ToString();
        }

        public async Task<string> CallLoginApiAsync<T>(T dto, string actionUrl)
        {
            var content = FormHelper.ToFormData(dto);
            HttpResponseMessage response = await _httpClient.PostAsync(actionUrl, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public string? GetJsEncryptKey()
        {
            var node = _doc.DocumentNode.SelectSingleNode("//input[@id='__JS_ENCRYPT_KEY__']");
            return node?.GetAttributeValue("value", "");
        }
        
        public string? GetTextById(string id)
        {
            var nameHeader = _doc.DocumentNode.SelectSingleNode($"//span[@id='{id}']");
            return nameHeader?.InnerText.Trim();
        }

        public string getUrlBalanceFromHtml(string baseUrl)
        {
            var scriptNode = _doc.DocumentNode
                                .SelectSingleNode("//div[@id='CorporateUserDashboardUX5_WAC85__1']//script");
            if (scriptNode != null)
            {
                var scriptContent = scriptNode.InnerText;
                var match = Regex.Match(scriptContent, @"baseUrl:\s*""([^""]+)""");
                if (match.Success)
                {
                    string urlScript = match.Groups[1].Value;

                    Uri baseUri = new Uri(baseUrl);
                    Uri actionUri = new Uri(baseUri, urlScript);
                    return actionUri.ToString();
                }
            }
            return null;
        }

        public async Task<string> GetBalanceAsync(string url)
        {
            try
            {
                // Debug: In ra cookies hiện tại
                var cookies = _cookieJar.GetCookies(new Uri("https://www.isacombank.com.vn"));
                System.Diagnostics.Debug.WriteLine($"Current cookies count: {cookies.Count}");
                foreach (Cookie cookie in cookies)
                {
                    System.Diagnostics.Debug.WriteLine($"Cookie: {cookie.Name}={cookie.Value}");
                }

                // Thêm headers quan trọng cho AJAX request
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                
                // Headers từ DevTools
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Referer", "https://www.isacombank.com.vn/corp/AuthenticationController");
                request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Pragma", "no-cache");

                // Body FormData từ DevTools
                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>(
                        "criteria",
                        "{\"WID_CONF\":\"CorporateUserDashboardUX5_WAC85__1\",\"PARENT_MENU_FOR_REMOVE\":\"DASHAT\",\"GROUPLETS_IN_PAGE\":\",CorporateUserDashboardUX5_WAC85__1\"}"
                    ),
                    new KeyValuePair<string, string>("target", "CorporateUserDashboardUX5_WAC85__1"),
                    new KeyValuePair<string, string>("requestId", "0")
                });

                request.Content = formData;
                
                var response = await _httpClient.SendAsync(request);
                
                // In ra status và headers để debug
                System.Diagnostics.Debug.WriteLine($"Response Status: {response.StatusCode}");
                System.Diagnostics.Debug.WriteLine($"Response Headers: {response.Headers}");
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetBalanceAsync: {ex.Message}");
                throw;
            }
        }
    
    }
}
