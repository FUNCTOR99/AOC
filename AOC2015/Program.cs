using System;

namespace AOC2015
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency Inversion Pinciple.  High level modules should not depend on low level modules, both on abstractions.

            // Usually the messages used in an application are stored in a localization file.
            // C# transforms those files into Strongly typed Static classes that you can use in your code.
            // Also it is a good idea to separate the messages from the OUTPUT. This is handled by a log library
            // the log library can be controlled to send the output to STDOUT or a log file or a DB.
            // You need the messages and the output to be decoupled so your code could be reused in a webservice or 
            // a microservice or anything else. Otherwise you make it dependent on the Console.
            IStandardMessages messages = Factory.CreateStandardMessages();
            
            // A similar situation here, the mechanism to get the input values is strongly coupled to the Console.
            ICommand command = Factory.CreateCommand();
            
            // One thing to keep in mind: It is also a good practice to 
            // use namespaces to have a clear scopes. FOr instance
            // aoc.2015.problems.IAOCProblem
            // aoc.2015.buildings.IHouse
            // aoc.2015.buildings.House

            messages.ApplicationTitle();

            Int32 day = command.GetProblemDay();
            Int32 part = command.GetProblemPart();
            InputType inputType = command.GetInputType();

            // I think Factory can be split into 2 or more Factories. I would definitively go for a Factory 
            // that is exclusive for Creating problems, this way you can decouple PROBLEMS from the 
            // rest of the concerns: How to get the inputs, display messages, etc.
            IAOCProblem problem = Factory.CreateProblem(day, part, inputType);
            
            problem.Solve();

            command.EndProgram();


        }
    }
}
