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
            possibleMatches = FindAllMatchingStrings(ref rules, 0, ref possibleMatches);

            int count = 0;

            foreach (string message in messages)
            {
                if (possibleMatches.Any(x => x.Equals(message)))
                    count++;
            }


            return $"Result { count }.";            

        }       

        private List<string> FindAllMatchingStrings(ref List<Rule> rules, int startingRule, ref List<string> matches)
        {
            Rule startRule = rules.Where(r => r.RuleID == startingRule).First();
            List<string> result = new List<string>();

            if (startRule.MatchChar != 0)
            {
                result.Add(startRule.MatchChar.ToString());
                return result;
            }
            else
            {
                foreach (int[] rule in startRule.SubRules)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (int item in rule)
                    {
                        //result.AddRange(FindAllMatchingStrings(ref rules, item, ref matches));
                        sb.Append(FindAllMatchingStrings(ref rules, item, ref matches));                        
                    }

                    matches.Add(sb.ToString());
                }

                return result;
            }
        }


    }
}
