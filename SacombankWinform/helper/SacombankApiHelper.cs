using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SacombankWinform.helper
{
    public static class SacombankApiHelper
    {
        // Hàm này mô phỏng JavaScript: createHashandIncrementRia(options, requestId)
        public static string CreateFinParam(string baseUrl, int requestId, string xNumKey)
        {
            try
            {
                // 1. Tìm và giải mã giá trị bwayparam từ baseUrl
                string bwayparam = GetBwayParamFromUrl(baseUrl);
                if (string.IsNullOrEmpty(bwayparam))
                {
                    // Xử lý lỗi nếu không tìm thấy bwayparam hợp lệ
                    return null;
                }

                // 2. Chuẩn bị Chuỗi Đầu vào (bwayParamtoHash)

                // Loại bỏ khoảng trắng (JavaScript: bwayparam.replace(/\s/g,""))
                bwayparam = bwayparam.Replace(" ", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);

                string bwayParamtoHash;
                int bwayparamLength = bwayparam.Length;

                // Lấy 10 ký tự cuối (JavaScript: bwayparam.substring(bwayparamLength-10))
                if (bwayparamLength > 10)
                {
                    bwayParamtoHash = bwayparam.Substring(bwayparamLength - 10);
                }
                else
                {
                    bwayParamtoHash = bwayparam;
                }

                // Nối requestId (JavaScript: bwayParamtoHash = bwayParamtoHash + requestId)
                bwayParamtoHash = bwayParamtoHash + requestId.ToString();

                // 3. Tính HMAC-SHA256 và Base64 Encode
                // Khóa bí mật là xNumKey (sessionStorage.xNum)
                var keyBytes = Encoding.UTF8.GetBytes(xNumKey);
                var valueBytes = Encoding.UTF8.GetBytes(bwayParamtoHash);

                string hashInBase64;
                using (var hmac = new HMACSHA256(keyBytes))
                {
                    var hashBytes = hmac.ComputeHash(valueBytes);
                    // Base64 Encode (JavaScript: CryptoJS.enc.Base64.stringify(hash))
                    hashInBase64 = Convert.ToBase64String(hashBytes);
                }

                // 4. URL Encode và Trả về (JavaScript: encodeURIComponent(hashInBase64))
                return HttpUtility.UrlEncode(hashInBase64);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo Finparam: {ex.Message}");
                return null;
            }
        }

        // Hàm phụ trợ để trích xuất và giải mã bwayparam
        private static string GetBwayParamFromUrl(string url)
        {
            try
            {
                // Phân tích cú pháp URL để lấy các tham số
                var uriBuilder = new UriBuilder(url.Split('?')[0]);
                var query = HttpUtility.ParseQueryString(url.Split('?')[1]);

                string bwayparam = query["bwayparam"];

                // Giải mã URL (JavaScript: decodeURIComponent(bwayparam))
                // Lưu ý: HttpUtility.UrlDecode sẽ giải mã nếu cần
                return HttpUtility.UrlDecode(bwayparam);
            }
            catch (Exception)
            {
                // Xử lý khi URL không đúng định dạng
                return null;
            }
        }
    }
}
