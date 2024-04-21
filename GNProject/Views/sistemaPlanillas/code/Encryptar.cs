using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GNProject.Views.sistemaPlanillas.code
{
    public class Encryptar
    {
        const string Inputkey = "k3Y-pL4n1ll4erp_987xyz";
        const string Saltkey = "987cba321-w3B-pL4n1LL4erp_@^*";
        public static String Encripta(String Cadena)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = NewRijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(cripto.Key, cripto.IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }
        public static String Desencripta(String Cadena)
        {

            Cadena = Cadena.Replace(" ", "+");
            int mod4 = Cadena.Length % 4;
            if (mod4 > 0)
            {
                Cadena += new string('=', 4 - mod4);
            }


            byte[] inputBytes = Convert.FromBase64String(Cadena);


            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = NewRijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(cripto.Key, cripto.IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }
        private static RijndaelManaged NewRijndaelManaged()
        {
            var saltBytes = Encoding.UTF8.GetBytes(Saltkey);
            var key = new Rfc2898DeriveBytes(Inputkey, saltBytes);

            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

            return aesAlg;
        }
    }
}