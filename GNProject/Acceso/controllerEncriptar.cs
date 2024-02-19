using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GNProject.Acceso
{
    public class controllerEncriptar
    {
        private static controllerEncriptar instance = null;
        public static controllerEncriptar getinstance()
        {
            return instance == null ? instance = new controllerEncriptar() : instance;
        }

        public string Decrypt(string p_InputString, string p_SecretKey)
        {
            CipherMode p_CyphMode = CipherMode.ECB;
            //string p_SecretKey = ConfigurationManager.AppSettings["ClientRazonSocial"].ToString();
            if (String.IsNullOrEmpty(p_InputString))
            {
                return String.Empty;
            }
            else
            {
                StringBuilder ret = new StringBuilder();
                byte[] InputbyteArray = new byte[Convert.ToInt32(p_InputString.Length) / 2];
                TripleDESCryptoServiceProvider Des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                try
                {
                    Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(p_SecretKey));
                    Des.Mode = p_CyphMode;
                    for (int X = 0; X <= InputbyteArray.Length - 1; X++)
                    {
                        Int32 IJ = (Convert.ToInt32(p_InputString.Substring(X * 2, 2), 16));
                        ByteConverter BT = new ByteConverter();
                        InputbyteArray[X] = new byte();
                        InputbyteArray[X] = Convert.ToByte(BT.ConvertTo(IJ, typeof(byte)));
                    }
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, Des.CreateDecryptor(), CryptoStreamMode.Write);
                    //Flush the data through the crypto stream into the memory stream

                    cs.Write(InputbyteArray, 0, InputbyteArray.Length);

                    cs.FlushFinalBlock();


                    //Get the decrypted data back from the memory stream

                    byte[] B = ms.ToArray();

                    ms.Close();

                    for (int I = 0; I <= B.GetUpperBound(0); I++)
                    {

                        ret.Append(Convert.ToChar(B[I]));

                    }
                    return ret.ToString();
                }
                catch (System.Security.Cryptography.CryptographicException generatedExceptionName)
                {

                    //   ME.Publish("SF.Utils.Utils", "DecryptString", ex, ManageException_Enumerators.ErrorLevel.FatalError);

                    return String.Empty;

                }


                return ret.ToString();

            }

        }
    }
}