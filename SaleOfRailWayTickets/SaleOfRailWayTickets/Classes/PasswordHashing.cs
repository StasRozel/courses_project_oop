using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab4_5
{
    public class PasswordHashing
    {
        public static string Hash(string password)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            string hash = "";

            byte[] bytes = win1251.GetBytes(password);

            for (int i = 0; i < bytes.Count(); i++)
            {
                hash += 31 * bytes[i];
            }
            return hash;
        }

        public static string DecodeHash(string hash)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            StringBuilder decodedPassword = new StringBuilder();

            for (int i = 0; i < hash.Length; i += 2)
            {
                int charCode = int.Parse(hash.Substring(i, 2));
                decodedPassword.Append((char)(charCode / 31));
            }

            return win1251.GetString(decodedPassword.ToString().Select(c => (byte)c).ToArray());
        }
    }
}
