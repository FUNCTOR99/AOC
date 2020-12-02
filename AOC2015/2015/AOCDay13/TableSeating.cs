using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class TableSeating : ITableSeating
    {
        public List<IRelationship> Relationships { get; set; }
        private List<String> People { get; set; }

        public TableSeating()
        {
            Relationships = new List<IRelationship>();
            People = new List<string>();
        }

        public void AddRelationship(IRelationship relationship)
        {
            Relationships.Add(relationship);
        }

        private void GetPeopleFromRelationships()
        {
            foreach (IRelationship relationship in Relationships)
            {
                if (People.Contains(relationship.SourceName) == false)
                {
                    People.Add(relationship.SourceName);
                }

                if (People.Contains(relationship.AcquaintanceName) == false)
                {
                    People.Add(relationship.AcquaintanceName);
                }
            }
        }

        public Int32 BestHappinessSeatingPlan()
        {
            GetPeopleFromRelationships();

            List<String[]> peoplePermutations = Permute<String>.PermuteToList(People.ToArray());

            int maxHappinessLevel = 0;

            foreach (String[] peoplePermutation in peoplePermutations)
            {
                int permutationHappiness = 0;

                for (int i = 0; i < peoplePermutation.Length; i++)
                {
                    //Calculate happiness of that person to the left and right.  i is the source.
                    int rightHappiness = Relationships.Where(x => x.SourceName.Equals(peoplePermutation[i]))
                                                      .Where(y => y.AcquaintanceName.Equals(peoplePermutation[(i + 1) % peoplePermutation.Length]))
                                                      .First().Happiness;

                    int leftHappiness = Relationships.Where(x => x.SourceName.Equals(peoplePermutation[i]))
                                                     .Where(y => y.AcquaintanceName.Equals(peoplePermutation[(i - 1 + peoplePermutation.Length) % peoplePermutation.Length]))
                                                     .First().Happiness;

                    permutationHappiness = permutationHappiness + rightHappiness + leftHappiness;
                }                

                if (permutationHappiness > maxHappinessLevel)
                    maxHappinessLevel = permutationHappiness;
            }

            return maxHappinessLevel;
        }

        public List<String> GetPeople()
        {
            GetPeopleFromRelationships();

            return People;
        }
    }
}
