using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class Literals
    {
        public static Int32 NetLiteralCount(String input)
        {

            Int32 stringLength = input.Length;

            String working = input;

            //remove the leading and trailing quotes
            if (working[0] == '"')
            {
                working = working.Remove(0, 1);
            }

            if (working[working.Length - 1] == '"')
            {
                working = working.Remove(working.Length - 1, 1);
            }

            //replace double backslash with a single char (underscore)
            if (working.Contains("\\\\"))
            {
                working = working.Replace("\\\\", "_");
            }

            //replace \" with a single char (underscore)
            if (working.Contains("\\\""))
            {
                working = working.Replace("\\\"", "_");
            }

            //replace \x hex codes
            bool containsSlashX = working.Contains("\\x");

            while (containsSlashX)
            {
                working = working.Remove(working.IndexOf("\\x"), 4) + "_";
                containsSlashX = working.Contains("\\x");
            }

            return stringLength - working.Length;
        }

        public static Int32 NetLiteralCountInverse(String input)
        {

            Int32 stringLength = input.Length;

            String working = input;

            working = working.Replace("\"", "__");
            working = working.Replace("\\", "__");
            working = "_" + working + "_";

            return working.Length - input.Length;
        }
    }
}
