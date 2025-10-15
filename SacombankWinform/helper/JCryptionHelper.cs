using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SacombankWinform.helper
{
    public class JCryptionHelper
    {
        public static Dictionary<string, string> EncryptLogin(string password, string encryptKey)
        {
            var parts = encryptKey.Split(',');
            if (parts.Length < 2) throw new ArgumentException("encryptKey sai format");

            string exponentHex = parts[0].Trim();
            string modulusHex = parts[1].Trim();
            int maxDigits = parts.Length >= 3 ? int.Parse(parts[2]) : 0;

            BigInteger e = BigInteger.Parse("0" + exponentHex, NumberStyles.HexNumber);
            BigInteger n = BigInteger.Parse("0" + modulusHex, NumberStyles.HexNumber);

            // tính chunkSize giống JS
            var modBytes = HexToBytes(modulusHex);
            int nBytes = modBytes.Length;
            int biHighIndex = (nBytes + 1) / 2 - 1;
            if (biHighIndex < 1) biHighIndex = 1;
            int chunkSize = 2 * biHighIndex;
            if (chunkSize <= 0) chunkSize = Math.Max(nBytes - 2, 1);

            // salt random như JS (16 chữ số sau dấu .)
            string saltPass = MakeJsLikeRandom();
            string saltDummy1 = MakeJsLikeRandom();
            string saltDummy2 = MakeJsLikeRandom();

            //string saltPass = "0.1236578943245645";
            //string saltDummy1 = "0.7456890341234586";
            //string saltDummy2 = "0.5678934521345678";

            string plainPass = $"password={password}_SALT_COMPONENT_={saltPass}";
            string plainDummy1 = $"password=dummy_SALT_COMPONENT_={saltDummy1}";
            string plainDummy2 = $"password=dummy_SALT_COMPONENT_={saltDummy2}";

            string encPass = JcryptionEncrypt(plainPass, e, n, modulusHex, chunkSize);
            string encDummy1 = JcryptionEncrypt(plainDummy1, e, n, modulusHex, chunkSize);
            string encDummy2 = JcryptionEncrypt(plainDummy2, e, n, modulusHex, chunkSize);

            return new Dictionary<string, string>
            {
                { "dummy1", encDummy1 },
                { "AuthenticationFG.ACCESS_CODE", encPass },
                { "dummy2", encDummy2 }
            };
        }

        private static string JcryptionEncrypt(string input, BigInteger e, BigInteger n, string modulusHex, int chunkSize)
        {
            // 1) tính charSum
            int charSum = input.Sum(c => (int)c);
            string tagChars = "0123456789abcdef";
            string tag = "" + tagChars[(charSum & 0xF0) >> 4] + tagChars[charSum & 0x0F];
            string tagged = tag + input;

            // 2) charCodeAt
            List<int> encrypt = tagged.Select(c => (int)c).ToList();

            // 3) pad 0
            while (encrypt.Count % chunkSize != 0) encrypt.Add(0);

            // 4) chia block và mã hóa
            List<string> blocks = new List<string>();
            int expectedHexLen = modulusHex.Length;

            for (int offset = 0; offset < encrypt.Count; offset += chunkSize)
            {
                int wordsCount = chunkSize / 2;
                ushort[] words = new ushort[wordsCount];
                int wi = 0;
                for (int k = offset; k < offset + chunkSize; k += 2)
                {
                    int lo = encrypt[k];
                    int hi = (k + 1 < encrypt.Count) ? encrypt[k + 1] : 0;
                    ushort word = (ushort)(lo + (hi << 8));
                    words[wi++] = word;
                }

                // BigInt m từ words (little endian)
                BigInteger m = BigInteger.Zero;
                for (int w = wordsCount - 1; w >= 0; w--)
                {
                    m = (m << 16) | words[w];
                }

                // powMod
                BigInteger c = BigInteger.ModPow(m, e, n);
                string hex = c.ToString("x");
                if (hex.Length < expectedHexLen)
                    hex = new string('0', expectedHexLen - hex.Length) + hex;
                blocks.Add(hex);
            }

            return string.Join(" ", blocks);
        }

        private static byte[] HexToBytes(string hex)
        {
            hex = hex.Trim();
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                hex = hex.Substring(2);
            if (hex.Length % 2 == 1)
                hex = "0" + hex;
            byte[] res = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
                res[i / 2] = byte.Parse(hex.Substring(i, 2), NumberStyles.HexNumber);
            return res;
        }

        private static string MakeJsLikeRandom()
        {
            double r = new Random().NextDouble();
            string s = r.ToString("0.################", System.Globalization.CultureInfo.InvariantCulture);
            int dotIndex = s.IndexOf('.');
            if (dotIndex >= 0)
            {
                int decimals = s.Length - dotIndex - 1;
                if (decimals < 16)
                    s = s + new string('0', 16 - decimals);
                else if (decimals > 16)
                    s = s.Substring(0, dotIndex + 1 + 16);
            }
            else
            {
                s = "0." + new string('0', 16);
            }
            return s;
        }

    }
}
