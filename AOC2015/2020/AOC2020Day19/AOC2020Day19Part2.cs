using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day19Part2 : AOCProblem
    {

        public AOC2020Day19Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
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

            rules.Remove(rules.Where(r => r.RuleID == 8).First());
            rules.Remove(rules.Where(r => r.RuleID == 11).First());
            
            rules.Add(new Rule("8: 42 | 42 8"));
            rules.Add(new Rule("11: 42 31 | 42 11 31"));           


            Dictionary<int, List<string>> calculatedValues = new Dictionary<int, List<string>>();

            for (int i = 1; i < rules.Max(r => r.RuleID); i++)
            {
                if ((i != 8) && (i != 11))
                    calculatedValues.Add(i, FindAllMatchingStrings(ref rules, i, ref calculatedValues));
            }

            List<string> values31 =  FindAllMatchingStrings(ref rules, 31, ref calculatedValues); 
            List<string> values42 =  FindAllMatchingStrings(ref rules, 42, ref calculatedValues);

            int count = 0;

            foreach (string message in messages)
            {
                if (MatchesRule0(message, ref values42, ref values31))
                    count++;
            }

            return $"Result { count }.";
        }

        private bool MatchesRule0(string input, ref List<string> rule42Strings, ref List<string> rule31Strings)
        {
            string working = input;

            int repeat42Count = 0;

            while (working.Length >= rule42Strings.Min(str => str.Length))
            {
                bool match42Found = false;

                foreach (string rule42String in rule42Strings)
                {
                    if (working.StartsWith(rule42String))
                    {
                        working = working.Substring(rule42String.Length, working.Length - rule42String.Length);
                        repeat42Count++;
                        match42Found = true;
                        break;
                    }
                }

                if (!match42Found)
                    break;
            }

            int repeat31Count = 0;

            while (working.Length >= rule31Strings.Min(str => str.Length))
            {
                bool match31Found = false;

                foreach (string rule31String in rule31Strings)
                {
                    if (working.StartsWith(rule31String))
                    {
                        working = working.Substring(rule31String.Length, working.Length - rule31String.Length);
                        repeat31Count++;
                        match31Found = true;
                        break;
                    }
                }

                if (!match31Found)
                    break;
            }

            if ((working.Length == 0)
                    && (repeat42Count > repeat31Count)
                    && (repeat31Count > 0))
                return true;
            else
                return false;
        }        

        private List<string> FindAllMatchingStrings(ref List<Rule> rules, int currentRule, ref Dictionary<int, List<string>> calculatedValues)
        {
            Rule startRule = rules.Where(r => r.RuleID == currentRule).First();
            List<string> results = new List<string>();            

            if (calculatedValues.ContainsKey(currentRule))
            {
                return calculatedValues[currentRule];
            }

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

                        List<String> individualResults = FindAllMatchingStrings(ref rules, item, ref calculatedValues);

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
                                    string resultToAdd = $"{workingResults[i]}{individualResult}";

                                    subRuleResults.Add(resultToAdd);                                    
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
