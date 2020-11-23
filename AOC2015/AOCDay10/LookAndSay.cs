using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class LookAndSay
    {
        public static String ConvertToLookAndSay(String input)
        {

            StringBuilder sb = new StringBuilder();
            int i = 0;

            while (i < input.Length)
            {
                int j = 1;

                while (((i + j) < input.Length) && (input[i] == input[i + j]))
                {
                    j++;
                }

                sb.Append(j);
                sb.Append(input[i]);

                i = i + j;
            }

            return sb.ToString();
        }
    }
}
