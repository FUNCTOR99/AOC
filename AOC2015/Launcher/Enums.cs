using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public enum InputType
    {
        Manual = 0,
        File
    };

    public enum LightCommand
    {
        Undefined = 0,
        TurnOn = 1,
        TurnOff = 2,
        Toggle = 3
    };

    public enum LogicGateType
    {
        Undefined = 0,
        Assign,
        And,
        Or,
        LShift, 
        RShift,
        Not
    }
}
