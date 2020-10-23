using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class StandardMessages : IStandardMessages
    {
        public void ApplicationTitle()
        {
            Console.WriteLine("*** ADVENT OF CODE : 2015 ***");
        }

        public void SelectDay()
        {
            Console.Write("Please enter a Day number to test:");
        }

        public void SelectPart()
        {
            Console.Write("Part 1 or 2? ");
        }

        public void ExitApplication()
        {
            Console.Write("Press Any Key to Exit...");
        }

        public void QuestionInputType()
        {
            Console.Write("Enter Input Type.  (Manually = 0, From File = 1): ");
        }

        public void ManualInputMessage()
        {
            Console.WriteLine("Enter input manually.  Press <ENTER> at the end of each line.  Type: 'DONE' on the last line to end the input.");
        }

        public void StartingProblem()
        {
            Console.WriteLine("Solving Problem...");
        }

        public void ProblemAnswered(String text)
        {
            Console.WriteLine($"Problem Answer: { text } ");
        }

    }
}
