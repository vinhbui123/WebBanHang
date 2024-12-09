using System;
using System.Security.Cryptography;
using System.Text;

namespace WebBanHang.Extension
{
    public static class HashHelper
    {
        public static string ToMD5(this string str)
        {
            using (MD5 md5 = MD5.Create()) // Proper disposal
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2")); // More concise formatting
                return sb.ToString();
            }
        }
    }
}
 