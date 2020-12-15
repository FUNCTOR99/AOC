using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day14Part1 : AOCProblem
    {
        public AOC2020Day14Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int result = 0;

            string mask = "";
            Dictionary<UInt64, UInt64> memory = new Dictionary<ulong, ulong>();
                      


            foreach (String line in input)
            {
                if (line.Contains("mask"))
                {
                    mask = StringOps.SubStringPost(line, "=");
                }

                else if (line.Contains("mem"))
                {
                    UInt64 address = Convert.ToUInt64(StringOps.SubStringPre(line, "=").Replace("mem[", "").Replace("]", ""));
                    UInt64 value = Convert.ToUInt64(StringOps.SubStringPost(line, "="));

                    UInt64 maskedValue = MaskValue(mask.Trim(), value);

                    if (memory.ContainsKey(address))
                    {
                        memory[address] = maskedValue;
                    }
                    else
                    {
                        memory.Add(address, maskedValue);
                    }
                }       

            }

            UInt64 sum = 0;

            foreach (KeyValuePair<UInt64, UInt64> pair in memory)
            {
                sum = sum + pair.Value;
            }



           



            return $"Result { sum }.";            

        }

        private UInt64 MaskValue(string mask, UInt64 value)
        {
            UInt64 result = value;

            for (int i = 0; i < mask.Length; i++)
            {
                int maskIndex = mask.Length - 1 - i;
                
                switch (mask[i])
                {
                    case '0':
                        result &= ~((UInt64)1 << maskIndex);
                        break;

                    case '1':
                        result = result | ((UInt64)1 << maskIndex);
                        break;

                    default:
                        break;
                }
            }

            return result;
        }

        


    }
}
