using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWeb.Utils
{
    public class SenhaMD5
    {
        public string GerarMD5(string valor)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }
            return strBuilder.ToString();

        }
    }
}
