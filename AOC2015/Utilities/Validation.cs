using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class Validation
    {
        public static Int32 StringVowelCount(String input)
        {
            Int32 vowelCount = 0;

            String vowels = "aeiou";

            foreach (char vowel in vowels.ToUpper())
            {
                foreach (char letter in input.ToUpper())
                {
                    if (letter == vowel)
                        vowelCount++;
                }
            }

            return vowelCount;
        }

        public static bool StringRepeatedLetter(String input)
        {
            int i = 0;

            for (i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                    return true;
            }

            return false;
        }

        public static bool StringDoesNotContainStrings(String input, String[] checkStrings)
        {
            foreach (String checkString in checkStrings)
            {
                if (input.ToUpper().Contains(checkString.ToUpper()))
                    return false;
            }

            return true;
        }

        public static Int32 CharPairCount(String input)
        {
            int i = 0;
            int charPairCount = 1;

            for (i = 0; i < input.Length - 3; i++)
            {
                for (int j = i + 2; j < input.Length - 1; j++ )
                {
                    if (input.Substring(i, 2).Equals(input.Substring(j, 2)))
                        charPairCount++;
                }
            }

            return charPairCount;
        }

        public static bool CharRepeatsWithOneLetterBetween(String input)
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2])
                    return true;
            }

            return false;
        }


    }
}
