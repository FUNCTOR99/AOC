using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class HandheldGameConsole
    {
        public List<string[]> Operations { get; set; }

        public int Accumulator { get; set; }

        public HandheldGameConsole(List<string[]> operations)
        {
            Operations = operations;
            Accumulator = 0;
        }

        public int Execute(out bool instructionRepeated)
        {
            Accumulator = 0;

            int currentOperation = 0;
            instructionRepeated = false;

            List<int> executedInstructions = new List<int>();

            while (!instructionRepeated)
            {
                if (currentOperation == Operations.Count)
                {
                    break;
                }

                if (executedInstructions.Contains(currentOperation))
                {
                    instructionRepeated = true;
                    break;
                }
                else
                {
                    executedInstructions.Add(currentOperation);

                    switch (Operations[currentOperation][0])
                    {
                        case "acc":

                            Accumulator = Accumulator + Convert.ToInt32(Operations[currentOperation][1]);
                            currentOperation++;
                            break;

                        case "jmp":
                            currentOperation = currentOperation + Convert.ToInt32(Operations[currentOperation][1]);
                            break;

                        case "nop":
                            currentOperation++;
                            break;

                    }
                }
            }

            return Accumulator;
        }

    }
}
