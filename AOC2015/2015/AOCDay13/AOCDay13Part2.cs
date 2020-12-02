using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay13Part2 : AOCProblem
    {
        public AOCDay13Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            ITableSeating seatingPlan = Factory.CreateTableSeating();

            //read the input
            foreach (String line in input)
            {
                String sourceName = StringOps.SubStringPre(line, "would ").Trim();
                int happinessLevel = 0;

                String acquaintanceName = StringOps.SubStringPost(line, "to ").Trim().Replace(".", "");

                String happiness = StringOps.SubStringPre(line, "happiness");
                happiness = StringOps.SubStringPost(happiness, "would ");

                if (happiness.Contains("lose"))
                {
                    happinessLevel = Convert.ToInt32(StringOps.SubStringPost(happiness, "lose").Trim()) * (-1);
                }
                else
                {
                    happinessLevel = Convert.ToInt32(StringOps.SubStringPost(happiness, "gain").Trim());
                }

                seatingPlan.AddRelationship(Factory.CreateRelationship(sourceName, acquaintanceName, happinessLevel));
            }

            //add myself to the List of People
            List<String> people = seatingPlan.GetPeople();

            foreach(String person in people)
            {
                seatingPlan.AddRelationship(Factory.CreateRelationship("Me", person, 0));
                seatingPlan.AddRelationship(Factory.CreateRelationship(person, "Me", 0));
            }

            return $"The Best Happiness Level is { seatingPlan.BestHappinessSeatingPlan() }.";

        }

      
    }
}
