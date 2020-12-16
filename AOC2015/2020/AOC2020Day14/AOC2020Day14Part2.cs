using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day14Part2 : AOCProblem
    {

        public AOC2020Day14Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            string mask = "";
            Dictionary<UInt64, UInt64> memory = new Dictionary<ulong, ulong>();

            foreach (String line in input)
            {
                if (line.Contains("mask"))
                {
                    mask = StringOps.SubStringPost(line, "=").Trim();
                }

                else if (line.Contains("mem"))
                {
                    UInt64 address = Convert.ToUInt64(StringOps.SubStringPre(line, "=").Replace("mem[", "").Replace("]", ""));
                    UInt64 value = Convert.ToUInt64(StringOps.SubStringPost(line, "="));

                    DecodeValue(mask, ref memory, address, value);
                }

            }

            UInt64 sum = 0;

            foreach (KeyValuePair<UInt64, UInt64> pair in memory)
            {
                sum = sum + pair.Value;
            }

            return $"Result { sum }.";
        }

        private void DecodeValue(string mask, ref Dictionary<ulong, ulong> memory, ulong startingAddress, ulong value)
        {
            List<ulong> addresses = new List<ulong>();
            addresses.Add(startingAddress);

            int iterations = 0;

            for (int j = 0; j < mask.Length; j++)
            {
                int maskIndex = mask.Length - 1 - j;

                switch (mask[j])
                {
                    case 'X':
                        iterations = addresses.Count();

                        for (int k = 0; k < iterations; k++)
                        {
                            addresses[k] &= ~((UInt64)1 << maskIndex);          //force bit to 0

                            ulong newAddress = addresses[k];
                            newAddress = newAddress | ((UInt64)1 << maskIndex); //force bit to 1

                            addresses.Add(newAddress);
                        }

                        break;

                    case '1':
                        iterations = addresses.Count();

                        for (int k = 0; k < iterations; k++)
                        {
                            addresses[k] = addresses[k] | ((UInt64)1 << maskIndex); //force bit to 1
                        }
                        break;

                    case '0':
                        //maskedAddress = maskedAddress | ((UInt64)1 << maskIndex);
                        break;

                    default:
                        break;
                }
            }

            //write the values to the addresses
            foreach (ulong address in addresses)
            {
                if (memory.ContainsKey(address))
                {
                    memory[address] = value;
                }
                else
                {
                    memory.Add(address, value);
                }
            }
        }
    }
}
