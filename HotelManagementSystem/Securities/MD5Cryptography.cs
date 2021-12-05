using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Securities
{
    public class MD5Cryptography
    {
        public static string EncryptWithMd5(string PasswordToHash)
        {
            //Encryption
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(PasswordToHash));
            byte[] result = md5.Hash;
            StringBuilder str = new();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
    }
}
