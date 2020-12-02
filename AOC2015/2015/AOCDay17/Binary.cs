using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class Binary
    {
        public static int CountSetBits(int input)
        {
            int count = 0;

            while (input > 0)
            {
                count += input & 1;
                input >>= 1;
            }

            return count;
        }

        public static bool IsBitSet(int input, int bit)
        {
            int result = input & (1 << bit);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
