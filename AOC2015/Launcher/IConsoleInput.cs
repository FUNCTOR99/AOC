using System;

namespace AOC2015
{
    public interface IConsoleInput
    {
        void PressAnyKey();

        Int32? InputANumber();

        String InputCommandLine();
    }
}