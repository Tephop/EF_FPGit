using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        byte[] AesKey = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        byte[] AesIV = Encoding.UTF8.GetBytes("1234567890123456");
        string cipherText = "VEY4xcJr0woDXW0LNltofA==";
        
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = AesKey;
            aesAlg.IV = AesIV;
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        Console.WriteLine(srDecrypt.ReadToEnd());
                    }
                }
            }
        }
    }
}
