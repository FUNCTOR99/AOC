using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class StringOps
    {
        public static String SubStringPost(String input, String delimiter)        
        {
            return input.Substring(input.IndexOf(delimiter) + delimiter.Length, input.Length - (input.IndexOf(delimiter) + delimiter.Length));
        }

        public static String SubStringPre(String input, String delimiter)
        {
            return input.Substring(0, input.IndexOf(delimiter) - 1);
        }
    }
}
