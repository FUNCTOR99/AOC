using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class Permute<T>
    {
        public static List<T[]> PermuteToList (T[] input)
        {
            List<T[]> resultList = new List<T[]>();
            PermuteObjectArray(input, 0, input.Length - 1, ref resultList);

            return resultList;
        }

        private static void PermuteObjectArray(T[] input, int leftIndex, int rightIndex, ref List<T[]> resultList)
        {
            if (leftIndex == rightIndex)
            {
                resultList.Add(input);
            }
            else
            {
                for (int i = leftIndex; i <= rightIndex; i++)
                {
                    input = Swap(input, i, leftIndex);
                    PermuteObjectArray(input, leftIndex + 1, rightIndex, ref resultList);
                    input = Swap(input, i, leftIndex);  //back track
                }
            }
        }

        private static T[] Swap(T[] input, int a, int b)
        {
            T[] result = new T[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (i == a)
                    result[i] = input[b];
                else if (i == b)
                    result[i] = input[a];
                else
                    result[i] = input[i];
            }

            return result;
        }
    }
}
