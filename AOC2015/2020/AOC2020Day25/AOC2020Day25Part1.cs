using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day25Part1 : AOCProblem
    {
        public AOC2020Day25Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            long cardPublicKey = Convert.ToInt64(input[0]);
            long doorPublicKey = Convert.ToInt64(input[1]);

            long cardLoopSize = 0;
            long doorLoopSize = 0;

            long subjectNumber = 7;

            long transformation = 1;
            bool cardLoopFound = false;
            bool doorLoopFound = false;
            long currentLoop = 1;

            while ((cardLoopFound && doorLoopFound) == false)
            {
                transformation = Transform(transformation, subjectNumber);
                //transformation = transformation * subjectNumber;
                //transformation = transformation % 20201227;

                if (!cardLoopFound)
                {
                    if (transformation == cardPublicKey)
                    {
                        cardLoopSize = currentLoop;
                        cardLoopFound = true;
                    }
                }

                if (!doorLoopFound)
                {
                    if (transformation == doorPublicKey)
                    {
                        doorLoopSize = currentLoop;
                        doorLoopFound = true;
                    }
                }

                currentLoop++;
            }

            long encryptionKey = Decrypt(cardPublicKey, doorLoopSize);

            return $"Loop Sizes: card:{ cardLoopSize }  Door:{doorLoopSize}   Encryption Key:{encryptionKey}.";
        }

        private long Transform(long input, long subjectNumber)
        {
            long result = input * subjectNumber;
            result = result % 20201227;

            return result;
        }

        private long Decrypt(long publicKey, long loopSize)
        {
            long result = 1;

            for (long i = 0; i < loopSize; i++)
            {
                result = Transform(result, publicKey);
            }

            return result;
        }
        
    }
}
