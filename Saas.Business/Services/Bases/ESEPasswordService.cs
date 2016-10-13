using System;
using System.Security.Cryptography;
using System.Text;

namespace Saas.Business.Services.Bases
{
    public class EsePasswordService
    {
        public string DesEncrypt(string password, string key)
        {
            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                byte[] bytePassword = Encoding.UTF8.GetBytes(password);
                desCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
                desCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(key);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytePassword, 0, bytePassword.Length);
                    cryptoStream.FlushFinalBlock();
                    cryptoStream.Close();
                }
                string value = Convert.ToBase64String(memoryStream.ToArray());
                memoryStream.Close();
                return value;
            }
        }

        public string DesDecrypt(string password, string key)
        {
            byte[] bytePassword = Convert.FromBase64String(password);
            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                desCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
                desCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(key);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytePassword, 0, bytePassword.Length);
                    cryptoStream.FlushFinalBlock();
                    cryptoStream.Close();
                }
                string value = Encoding.UTF8.GetString(memoryStream.ToArray());
                memoryStream.Close();
                return value;
            }
        }
    }
}
