using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class Encryptor
    {
        //MD5 Encrypting Algorithm
       
        public string EncryptMD5(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);
           
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {             
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
