using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day08Part1 : AOCProblem
    {
        public AOC2020Day08Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            int result = 0;

            List<string[]> operations = new List<string[]>();



            foreach (String line in input)
            {
                operations.Add(line.Split(' '));



            }

            HandheldGameConsole console = new HandheldGameConsole(operations);

            bool instructionRepeated = false;

            int acc = console.Execute(out instructionRepeated);

            //int acc = 0;

            //int currentOperation = 0;
            //bool instructionRepeated = false;

            //List<int> executedInstructions = new List<int>();

            //while (!instructionRepeated)
            //{
            //    if (executedInstructions.Contains(currentOperation))
            //    {
            //        instructionRepeated = true;
            //        break;
            //    }
            //    else
            //    {
            //        executedInstructions.Add(currentOperation);

            //        switch (operations[currentOperation][0])
            //        {
            //            case "acc":

            //                acc = acc + Convert.ToInt32(operations[currentOperation][1]);                            
            //                currentOperation++;
            //                break;

            //            case "jmp":
            //                currentOperation = currentOperation + Convert.ToInt32(operations[currentOperation][1]);
            //                break;

            //            case "nop":
            //                currentOperation++;
            //                break;

            //        }
            //    }
            //}





            return $"Result { acc }.";            

        }
    }
}
