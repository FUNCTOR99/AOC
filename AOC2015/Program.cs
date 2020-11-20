using System;

namespace AOC2015
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency Inversion Pinciple.  High level modules should not depend on low level modules, both on abstractions.

            IStandardMessages messages = Factory.CreateStandardMessages();
            ICommand command = Factory.CreateCommand();

            messages.ApplicationTitle();

            Int32 day = command.GetProblemDay();
            Int32 part = command.GetProblemPart();
            InputType inputType = command.GetInputType();

            AOCProblem problem = Factory.CreateProblem(day, part, inputType);
            
            problem.Solve();

            command.EndProgram();


        }
    }
}
