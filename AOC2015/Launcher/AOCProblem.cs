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

            String answer = DoSolve(_input);

            _standardMessages.ProblemAnswered(answer);
        }

        protected abstract String DoSolve(String[] input);
        
    }
}
