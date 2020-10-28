using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    // I think this should be an Abstract Class that AOCDay(n)Part(m) extend from. 
    public abstract class IAOCProblem
    {
        private protected String[] _input;

        private protected IStandardMessages _standardMessages;

        public IAOCProblem(String[] input, IStandardMessages standardMessages)
        {
            _input = input;
            _standardMessages = standardMessages;
        }
        public void Solve()
        {
            _standardMessages.StartingProblem();

            String answer = doSolve();

            _standardMessages.ProblemAnswered(answer);
            
        }

        protected abstract String doSolve();

    }
}
