using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day18Part2 : AOCProblem
    {

        public AOC2020Day18Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            foreach (String line in input)
            {
                result = result + ProcessEquation(line);
            }

            return $"Result { result }.";
        }

        private long ProcessEquation(string equation)
        {
            if (equation.Contains('(') == false)
            {
                List<string> equationParts = equation.Split(' ').ToList();

                equationParts.RemoveAll(x => x.Equals(""));

                long operandA = long.MinValue;
                long operandB = long.MinValue;
                string op = null;

                if (equation.Contains('+') == false)
                {
                    foreach (string part in equationParts)
                    {
                        if (part.Trim().Length > 0)
                        {
                            if (operandA == long.MinValue)
                            {
                                operandA = Convert.ToInt64(part);
                                op = null;
                                operandB = long.MinValue;
                            }
                            else if (op == null)
                            {
                                op = part;
                            }
                            else
                            {
                                operandB = Convert.ToInt64(part);
                            }

                            if ((operandA != long.MinValue) && (operandB != long.MinValue) && (op != null))
                            {
                                operandA = operandA * operandB;
                                       
                                op = null;
                                operandB = long.MinValue;
                            }
                        }
                    }

                    return operandA;
                }
                else
                {
                    int operandAIndex = -1;
                    int opIndex = -1;
                    int operantBIndex = -1;

                    for (int i = 1; i < equationParts.Count() - 1; i++)
                    {
                        if (equationParts[i] != "")
                        {
                            if (equationParts[i].Equals("+"))
                            {
                                operandAIndex = i - 1;
                                opIndex = i;
                                operantBIndex = i + 1;

                                break;
                            }
                        }
                    }

                    StringBuilder newEquation = new StringBuilder();

                    for (int j = 0; j < equationParts.Count(); j++)
                    {
                        if ((j != operandAIndex) && (j != opIndex) && (j != operantBIndex))
                        {
                            newEquation.Append($"{equationParts[j]} ");
                        }
                        else if (j == opIndex)
                        {
                            newEquation.Append($"{Convert.ToInt64(equationParts[operandAIndex]) + Convert.ToInt64(equationParts[operantBIndex])} ");
                        }
                    }

                    if (newEquation.ToString().Trim().Contains(' '))
                    {
                        return ProcessEquation(newEquation.ToString().Trim());
                    }
                    else
                    {
                        return Convert.ToInt64(newEquation.ToString().Trim());
                    }                   

                }
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

                StringBuilder updatedEquation = new StringBuilder(equation.Substring(0, bracketOpenIndex));
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
