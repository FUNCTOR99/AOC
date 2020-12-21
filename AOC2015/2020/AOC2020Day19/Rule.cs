using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Rule
    {
        public int RuleID { get; set; }
        
        public List<int[]> SubRules { get; set; }
        
        public char MatchChar { get; set; }

        public Rule(string input)
        {
            BuildRule(input);
        }

        private void BuildRule(string input)
        {
            RuleID = Convert.ToInt32(StringOps.SubStringPre(input, ":"));

            if (input.Contains('"'))
            {
                MatchChar = input.Substring(input.IndexOf('"') + 1, 1)[0];
            }
            else
            {
                SubRules = new List<int[]>();

                if (input.Contains('|'))
                {
                    string working = StringOps.SubStringPost(input, ":").Trim();

                    string[] rulesOr = working.Split('|');


                    foreach (string ruleOr in rulesOr)
                    {
                        string[] rules = ruleOr.Trim().Split(' ');
                        int[] rulesInt = new int[rules.Length];

                        for (int i = 0; i < rules.Length; i++)
                        {
                            rulesInt[i] = Convert.ToInt32(rules[i]);
                        }

                        SubRules.Add(rulesInt);
                    }
                }
                else
                {
                    string[] rules = StringOps.SubStringPost(input, ":").Trim().Split(' ');
                    int[] rulesInt = new int[rules.Length];

                    for (int i = 0; i < rules.Length; i++)
                    {
                        rulesInt[i] = Convert.ToInt32(rules[i]);
                    }

                    SubRules.Add(rulesInt);
                }
            }
        }

    }

    
}
