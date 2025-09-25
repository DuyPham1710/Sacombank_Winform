using SacombankWinform.dto;
using SacombankWinform.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SacombankWinform.services
{

    internal class SacombankService
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
                CookieContainer = _cookieJar,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _httpClient = new HttpClient(handler);
            // Thêm header mô phỏng trình duyệt
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task LoadLoginPageAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string html = await response.Content.ReadAsStringAsync();

            _doc = new HtmlAgilityPack.HtmlDocument();
            _doc.LoadHtml(html);
        }

        public async Task<Image?> LoadCaptchaImageAsync(string baseUrl)
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

            return Image.FromStream(ms);
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

        public async Task<string> CallLoginApiAsync(Login1RequestDto dto, string actionUrl)
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

    }
}
