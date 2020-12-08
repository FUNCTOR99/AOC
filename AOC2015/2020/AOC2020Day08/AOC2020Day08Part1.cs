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
            List<string[]> operations = new List<string[]>();

            foreach (String line in input)
            {
                operations.Add(line.Split(' '));
            }

            HandheldGameConsole console = new HandheldGameConsole(operations);

            bool instructionRepeated = false;

            int acc = console.Execute(out instructionRepeated);

            return $"Result { acc }.";        
        }
    }
}
