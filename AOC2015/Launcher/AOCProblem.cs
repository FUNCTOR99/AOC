using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public abstract class AOCProblem
    {
        private String[] _input;

        private IStandardMessages _standardMessages;
        public AOCProblem(String[] input, IStandardMessages standardMessages)
        {
            _input = input;
            _standardMessages = standardMessages;
        }

        public void Solve()
        {
            _standardMessages.StartingProblem();

            DateTime startTime = DateTime.Now;

            String answer = DoSolve(_input);

            answer = $"{answer} (Calculated in {DateTime.Now.Subtract(startTime).TotalSeconds} seconds.)";

            _standardMessages.ProblemAnswered(answer);
        }

        protected abstract String DoSolve(String[] input);
        
    }
}
