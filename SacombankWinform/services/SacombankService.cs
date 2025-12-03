using SacombankWinform.Constants;
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
using SacombankWinform.models;
using System.Threading.Tasks;
using System.Windows.Controls;
using HtmlAgilityPack;

namespace SacombankWinform.services
{

    public class SacombankService
    {
        private readonly CookieContainer _cookieJar = new CookieContainer();
        private HttpClient _httpClient;
        private HtmlAgilityPack.HtmlDocument _doc;
        private string _xNum;

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

        public void AddCookie(string name, string value, string domain, string path = "/", bool secure = false, bool httpOnly = false, DateTime? expires = null)
        {
            try
            {
                // Domain may include leading dot; CookieContainer.Add requires a Uri
                var host = domain?.TrimStart('.') ?? "www.isacombank.com.vn";
                var uri = new Uri($"https://{host}");
                var cookie = new Cookie(name, value, path, domain)
                {
                    Secure = secure,
                    HttpOnly = httpOnly
                };
                if (expires.HasValue)
                {
                    cookie.Expires = expires.Value;
                }
                _cookieJar.Add(uri, cookie);
                System.Diagnostics.Debug.WriteLine($"Imported cookie: {name}={value}; domain={domain}; path={path}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding cookie: {ex.Message}");
            }
        }

        public void SetXNum(string xNum)
        {
            _xNum = xNum;
            System.Diagnostics.Debug.WriteLine($"xNum set: {_xNum}");
        }

        public async Task LoadPageAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();
            MessageBox.Show(html);
           // File.WriteAllText("debugLogin1.html", html);
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
            await LoadPageAsync(baseUrl);

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

        //public void PrintRequestHeaders(string url)
        //{
        //    System.Diagnostics.Debug.WriteLine("=== Current HttpClient Headers ===");
        //    System.Diagnostics.Debug.WriteLine($"UserAgent: {_httpClient.DefaultRequestHeaders.UserAgent}");
        //    System.Diagnostics.Debug.WriteLine($"Accept: {_httpClient.DefaultRequestHeaders.Accept}");

        //    System.Diagnostics.Debug.WriteLine("\n=== Cookies for sacombank ===");
        //    var cookies = _cookieJar.GetCookies(new Uri("https://www.isacombank.com.vn"));
        //    foreach (Cookie cookie in cookies)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"{cookie.Name}: {cookie.Value}");
        //    }
            
        //    System.Diagnostics.Debug.WriteLine($"\n=== Target URL ===");
        //    System.Diagnostics.Debug.WriteLine(url);
        //}

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

        public string getBaseUrlFromScriptHtml(string baseUrl, string id)
        {
            var scriptNode = _doc.DocumentNode
                                .SelectSingleNode($"//div[@id='{id}']//script");
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

        public async Task<string> SendSacombankRequestAsync(string url)
        {
            try
            {
                string finParam = SacombankApiHelper.CreateFinParam(url, 0, _xNum);
                
               // MessageBox.Show(finParam);

                // Thêm headers quan trọng cho AJAX request (cookies sent automatically from CookieContainer)
                var request = new HttpRequestMessage(HttpMethod.Post, url);

                // Standard headers
                request.Headers.TryAddWithoutValidation("Accept", "*/*");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br, zstd");
                request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.8");
                request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
             //   request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/141.0.0.0 Safari/537.36");

                // AJAX + app specific headers
                request.Headers.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
                request.Headers.TryAddWithoutValidation("Origin", "https://www.isacombank.com.vn");
                // Referer should include the login URL with jsessionid/bwayparam when available
                try
                {
                        var refUri = new Uri(GlConstants.ORIGINAL_BASE_URL);
                        request.Headers.Referrer = refUri;
                }
                catch { }

                request.Headers.TryAddWithoutValidation("IPTYPE", "XML");
                request.Headers.TryAddWithoutValidation("requestId", "0");

                // custom finParam header
                request.Headers.TryAddWithoutValidation("finParam", finParam);

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
     
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetBalanceAsync: {ex.Message}");
                throw;
            }
        }

        public List<AccountInfo> ExtractAccountInfo(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var accounts = new List<AccountInfo>();

            // Lấy danh sách các index (0, 1, 2, ...) vì có thể có nhiều tài khoản
            int index = 0;
            while (true)
            {
                var soDuNode = doc.DocumentNode.SelectSingleNode(
                    $"//span[@id='CorporateUserDashboardUX5_WAC85__1:HREF_OutputTextbox29902876[{index}]']");
                var tenGoiNhoNode = doc.DocumentNode.SelectSingleNode(
                    $"//a[@id='HREF_CorporateUserDashboardUX5_WAC85__1:AccountSummaryFG.OPR_ACCOUNT_NUMBER_ARRAY[{index}]']");
                var loaiTaiKhoanNode = doc.DocumentNode.SelectSingleNode(
                    $"//span[@id='CorporateUserDashboardUX5_WAC85__1:AccountSummaryFG.OPR_ACCOUNT_TYPE_ARRAY[{index}]']");

                // Nếu không còn node nào → dừng
                if (soDuNode == null && tenGoiNhoNode == null && loaiTaiKhoanNode == null)
                    break;
                
                decimal soDu = 0;
                if (decimal.TryParse(soDuNode?.InnerText?.Trim(), out var parsedValue))
                {
                    soDu = parsedValue;
                }
                
                var account = new AccountInfo
                {
                    SoDuKhaDung = soDu,
                    TenGoiNho = tenGoiNhoNode?.InnerText?.Trim() ?? "",
                    LoaiTaiKhoan = loaiTaiKhoanNode?.InnerText?.Trim() ?? ""
                };

                accounts.Add(account);
                index++;
            }

            return accounts;
        }

        public string? getHrefTransferAsync(string baseUrl)
        {
            if (_doc == null) return null;

            //var liNode = _doc.DocumentNode.SelectSingleNode("//li[@id='IL_Chuyn-tin-trong-nc_2']");
            //if (liNode == null) return null;

            //var aNode = liNode.SelectSingleNode(".//a[@href]");
            //if (aNode == null) return null;

            var aNode = _doc.DocumentNode.SelectSingleNode("//a[@id='Chuyn-tin-trong-nc_Chuyn-tin-n-Ngn-hng-khc']");
            if (aNode == null) return null;

            string href = aNode.GetAttributeValue("href", "").Trim();
            if (string.IsNullOrEmpty(href)) return null;

            // Nếu src là relative -> chuyển thành absolute
            string transferUrl = href;
            if (!Uri.IsWellFormedUriString(transferUrl, UriKind.Absolute))
            {
                var baseUri = new Uri(baseUrl);
                transferUrl = new Uri(baseUri, href).ToString();
            }

            return transferUrl;
        }

        public async Task LoadTransferPageAsync(string url, string actionUrl)
        {
        //    var request = new HttpRequestMessage(HttpMethod.Get, url);

        //    // 🧩 Chuẩn các header như từ trình duyệt thật
        //    request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8\r\n");
        //    request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br, zstd");
        //    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.8");
        //    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
        //    request.Headers.TryAddWithoutValidation("Host", "www.isacombank.com.vn");
        //    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
        //    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "document");
        //    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "navigate");
        //    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-origin");
        //    request.Headers.TryAddWithoutValidation("Sec-Fetch-User", "?1");
        //    request.Headers.TryAddWithoutValidation("Sec-Gpc", "1");
        //    request.Headers.TryAddWithoutValidation("Sec-CH-UA", "\"Brave\";v=\"141\", \"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"141\"");
        //    request.Headers.TryAddWithoutValidation("Sec-CH-UA-Mobile", "?0");
        //    request.Headers.TryAddWithoutValidation("Sec-CH-UA-Platform", "\"Windows\"");
        //    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36");
        //    // 🧩 Referrer
        //    try
        //    {
        //        var refUri = new Uri(actionUrl);
        //        //request.Headers.Referrer = refUri;
        //        request.Headers.TryAddWithoutValidation("referer", refUri.ToString());

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Referrer URL không hợp lệ");
        //    }

        //    // 🪶 Debug check headers
        //    StringBuilder headerInfo = new StringBuilder();
        //    foreach (var header in request.Headers)
        //    {
        //        headerInfo.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");
        //    }
        //    MessageBox.Show(headerInfo.ToString(), "Request Headers");

            // 📨 Gửi request

            var uri = new Uri("https://www.isacombank.com.vn");

            // Xóa userType cũ
            foreach (Cookie c in _cookieJar.GetCookies(uri))
            {
                if (c.Name == "userType")
                {
                    c.Expired = true;
                }
            }

            // Thêm cookie mới
            _cookieJar.Add(uri, new Cookie("userType", "2"));
            _cookieJar.Add(uri, new Cookie("tree1Selected", ""));
            _cookieJar.Add(uri, new Cookie("tree1State", ""));


            System.Diagnostics.Debug.WriteLine("\n=== Cookies for sacombank ===");
            foreach (Cookie cookie in _cookieJar.GetCookies(uri))
            {
                System.Diagnostics.Debug.WriteLine($"{cookie.Name}={cookie.Value}");
            }
         //   var response = await _httpClient.SendAsync(request);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();
            MessageBox.Show(html);
            File.WriteAllText("transferPage.html", html);
            //_doc = new HtmlAgilityPack.HtmlDocument();
            //_doc.LoadHtml(html);
            updateHtml(html);
        }
    }
}
