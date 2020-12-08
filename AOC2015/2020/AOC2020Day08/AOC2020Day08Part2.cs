using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day08Part2 : AOCProblem
    {

        public AOC2020Day08Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<string[]> operations = new List<string[]>();

            foreach (String line in input)
            {
                operations.Add(line.Split(' '));
            }

            int acc = 0;
            bool instructionRepeated = false;
            List<int> executedInstructions = new List<int>();

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i][0].Equals("acc") == false)
                {
                    List<string[]> testOperations = new List<string[]>();

                    foreach (string[] operation in operations)
                    {
                        string op = operation[0];
                        string operand = operation[1];

                        testOperations.Add(new string[] { op, operand });
                    }
                    
                    switch (testOperations[i][0])
                    {
                        case "jmp":
                            testOperations[i][0] = "nop";
                            break;

                        case "nop":
                            testOperations[i][0] = "jmp";
                            break;
                    }

                    HandheldGameConsole console = new HandheldGameConsole(testOperations);
                    instructionRepeated = false;
                    acc = console.Execute(out instructionRepeated);

                    if (!instructionRepeated)
                        break;                   
                }         
            }

            return $"Result { acc }.";
        }

        
    }
}
