using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class MD5
    {
        public static String CalculateMD5(String input)
        {
            byte[] tmpSource;
            byte[] tmpHash;

            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(input);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            return Conversion.ByteArrayToString(tmpHash);
        }
    }
}
