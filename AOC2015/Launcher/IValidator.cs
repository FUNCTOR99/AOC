using System;

namespace AOC2015
{
    public interface IValidator
    {
        bool IsDayValid(int day);
        bool IsPartValid(int part);
        bool IsInputTypeValid(Int32 inputType);
    }
}