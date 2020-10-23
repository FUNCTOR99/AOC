using System;

namespace AOC2015
{
    public interface ICommand
    {
        int GetProblemDay();

        void EndProgram();

        Int32 GetProblemPart();

        InputType GetInputType();
    }
}