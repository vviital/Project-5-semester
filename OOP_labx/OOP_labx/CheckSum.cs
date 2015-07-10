using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labx
{
    static class CheckSum
    {
        public static string ComputeMD5Checksum(string path)
        {
            try
            {
                FileStream fs = File.OpenRead(path);
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, (int)fs.Length);
                    byte[] checkSum = md5.ComputeHash(fileData);
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    return result;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
           
        }
    }
}
