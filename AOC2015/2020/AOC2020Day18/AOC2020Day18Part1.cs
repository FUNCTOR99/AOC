using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day18Part1 : AOCProblem
    {
        public AOC2020Day18Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            foreach (String line in input)
            {
                result =  result + ProcessEquation(line);
            }

            return $"Result { result }.";        
        }         
        
        private long ProcessEquation(string equation)
        {
            if (equation.Contains('(') == false)
            {
                //no more brackets, process the equation in order
                string[] equationParts = equation.Split(' ');

                long operandA = long.MinValue;
                long operandB = long.MinValue;
                string op = null;

                foreach(string part in equationParts)
                {
                    if (part.Trim().Length > 0)
                    {
                        if (operandA == long.MinValue)
                        {
                            operandA = Convert.ToInt32(part);
                            op = null;
                            operandB = long.MinValue;
                        }
                        else if (op == null)
                        {
                            op = part;
                        }
                        else
                        {
                            operandB = Convert.ToInt32(part);
                        }

                        if ((operandA != long.MinValue) && (operandB != long.MinValue) && (op != null))
                        {
                            switch (op)
                            {
                                case "+":
                                    operandA = operandA + operandB;
                                    break;

                                case "*":
                                    operandA = operandA * operandB;
                                    break;
                            }

                            op = null;
                            operandB = long.MinValue;
                        }
                    }
                }

                return operandA;
            }
            else
            {
                //replace the first bracket found.
                int bracketOpenIndex = equation.IndexOf('(');
                int bracketCloseIndex = 0;

                for (int i = bracketOpenIndex + 1; i < equation.Length; i++)
                {
                    if (equation[i] == ')')
                    {
                        bracketCloseIndex = i;
                        break;
                    }
                    else if (equation[i] == '(')
                    {
                        bracketOpenIndex = i;
                    }
                }

                string insideBracket = equation.Substring(bracketOpenIndex + 1, bracketCloseIndex - bracketOpenIndex - 1);

                long insideBracketSolved = ProcessEquation(insideBracket);

                StringBuilder updatedEquation =  new StringBuilder(equation.Substring(0, bracketOpenIndex));
                updatedEquation.Append($"{insideBracketSolved} ");

                if (bracketCloseIndex != equation.Length - 1)
                {
                    updatedEquation.Append(equation.Substring(bracketCloseIndex + 1, equation.Length - bracketCloseIndex - 1));
                }

                return ProcessEquation(updatedEquation.ToString().Trim());
            }
        }


    }
}
