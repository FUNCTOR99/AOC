using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day19Part1 : AOCProblem
    {
        public AOC2020Day19Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            //int result = 0;

            List<Rule> rules = new List<Rule>();
            List<string> messages = new List<string>();

            bool ruleInputSection = true;
            bool dataInputSection = false;

            foreach (String line in input)
            {
                if (line.Trim().Length > 0)
                {
                    if (ruleInputSection)
                    {
                        rules.Add(new Rule(line));
                    }
                    else if (dataInputSection)
                    {
                        messages.Add(line);
                    }
                }
                else
                {
                    ruleInputSection = false;
                    dataInputSection = true;
                }                
            }

            List<string> possibleMatches = new List<string>();
            possibleMatches = FindAllMatchingStrings(ref rules, 42);

            int count = 0;

            foreach (string message in messages)
            {
                if (possibleMatches.Any(x => x.Equals(message)))
                    count++;
            }


            return $"Result { count }.";            

        }       

        private List<string> FindAllMatchingStrings(ref List<Rule> rules, int currentRule)
        {
            Rule startRule = rules.Where(r => r.RuleID == currentRule).First();
            List<string> results = new List<string>();

            if (startRule.MatchChar != 0)
            {
                results.Add(startRule.MatchChar.ToString());
                return results;
            }
            else
            {
                foreach (int[] rule in startRule.SubRules)
                {
                    List<string> subRuleResults = new List<string>();
                    List<string> workingResults = new List<string>();

                    foreach (int item in rule)
                    {
                        workingResults = subRuleResults.ToList();
                        subRuleResults.Clear();

                        List<String> individualResults = FindAllMatchingStrings(ref rules, item);                             
                        
                        foreach (string individualResult in individualResults)
                        {
                            if (workingResults.Count == 0)
                            {
                                subRuleResults.Add($"{individualResult}");
                            }
                            else
                            {
                                int workingResultCount = workingResults.Count;

                                for (int i = 0; i < workingResultCount; i++)
                                {
                                    subRuleResults.Add($"{workingResults[i]}{individualResult}");
                                }
                            }
                        }                                                                     
                    }

                    results.AddRange(subRuleResults);
                }

                return results;
            }
        }


    }
}
