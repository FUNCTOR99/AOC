using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay12Part2 : AOCProblem
    {
        public AOCDay12Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            Int32 sum = 0;

            //read the input
            foreach (String line in input)
            {
                bool redFound = line.Contains("red");
                string working = line;

                while (redFound)
                {
                    Int32 redIndex = working.IndexOf("red");
                    Int32 parameterStartIndex = 0;
                    Int32 parameterCharCount = 0;

                    if (IsParameter(working, redIndex, out parameterStartIndex))
                    {
                        parameterCharCount = FindParameterCharCount(working, parameterStartIndex);
                        working = working.Remove(parameterStartIndex, parameterCharCount);
                    }
                    else
                    {
                        working = working.Remove(redIndex, 1);
                    }

                    redFound = working.Contains("red");                    
                }

                working = working.Replace(",", " ");
                working = working.Replace(":", " ");
                working = working.Replace("[", " ");
                working = working.Replace("]", " ");
                working = working.Replace("(", " ");
                working = working.Replace(")", " ");
                working = working.Replace("{", " ");
                working = working.Replace("}", " ");
                working = working.Replace("\"", " ");

                string[] items = working.Split(' ');

                foreach (string item in items)
                {
                    Int32 number = 0;
                    Int32.TryParse(item.Trim(), out number);

                    sum = sum + number;
                }
            }

            return $"The sum is {sum}.";

        }

        private bool IsParameter(String json, int index, out int parameterStartIndex)
        {
            int bracketClosedCountCurly = 0;
            int bracketClosedCountSquare = 0;

            for (int i = index; i > 0; i--)
            {
                if (json[i - 1] == '{')
                {
                    if (bracketClosedCountCurly == 0)
                    {
                        parameterStartIndex = i - 1;
                        return true;
                    }
                    else
                    {
                        bracketClosedCountCurly--;
                    }
                }
                else if (json[i - 1] == '[')
                {
                    if (bracketClosedCountSquare == 0)
                    {
                        parameterStartIndex = -1;
                        return false;
                    }
                    else
                    {
                        bracketClosedCountSquare--;
                    }
                }
                else if (json[i - 1] == '}')
                {
                    bracketClosedCountCurly++;
                }
                else if (json[i - 1] == ']')
                {
                    bracketClosedCountSquare++;
                }
            }

            parameterStartIndex = 0;
            return true;
        }

        private Int32 FindParameterCharCount(String json, int startIndex)
        {
            int openBracketCountCurly = 0;
            int openBracketCountSquare = 0;
            int charCount = 0;

            for (int i = startIndex; i < json.Length; i++)
            {
                if (json[i] == '}')
                {
                    openBracketCountCurly--;

                    if ((openBracketCountCurly == 0) && (openBracketCountSquare == 0))
                    {
                        return charCount + 1;
                    }
                }
                else if (json[i] == '{')
                {
                    openBracketCountCurly++;
                }
                else if (json[i] == '[')
                {
                    openBracketCountSquare++;
                }
                else if (json[i] == ']')
                {
                    openBracketCountSquare--;
                }

                charCount++;
            }

            return charCount;
        }

      
    }
}
