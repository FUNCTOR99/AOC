using System.Collections.Generic;

namespace AOC2015
{
    public interface ITableSeating
    {
        void AddRelationship(IRelationship relationship);
        int BestHappinessSeatingPlan();

        List<string> GetPeople();
    }
}