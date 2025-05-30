using System.Security.Cryptography;
using System.Text;

namespace LandingApi.Services
{
    public static class ConnectionStringDecryptor
    {
        private static readonly string Key = "Sana@dyarSecretKey123"; // باید ثابت باشه

        public static string Decrypt(string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            var key = new Rfc2898DeriveBytes(Key, Encoding.UTF8.GetBytes("SaltIsFixed!"));
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(buffer);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
