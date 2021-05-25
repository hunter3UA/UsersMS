using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;



namespace UsersMS.Services
{
    public class PasswordService:IPasswordService
    {
        public string CreateSHA256Hash(string stringToHash)
        {
            if (string.IsNullOrEmpty(stringToHash))
            {
                return String.Empty;
            }
            using(var sha=new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(stringToHash);
                byte[] computeHash =sha.ComputeHash(textData);
                return BitConverter.ToString(computeHash).Replace("-", String.Empty);
            }
        }
    }
}
