using System.Security.Cryptography;
using System.Text;

namespace IT008_O14_QLKS.Util
{
    public class HashPassword
    {
        public static byte[] CalculateSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(str));

            return hashValue;
        }
        
        public static string HashToHexString(byte[] hash)
        {
            
            string hashpass = "";
            foreach (byte item in hash)
            {
                hashpass += item;
            }

            return hashpass;
        }
    }
}