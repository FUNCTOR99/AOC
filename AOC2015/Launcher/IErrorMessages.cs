using System;

namespace AOC2015
{
    public interface IErrorMessages
    {
        void ErrorConvertingToNumber(string input);

        void ErrorValidatingDay(Int32 input);

        void ErrorValidatingPart(Int32 input);

        void ErrorValidatingInputType(Int32 input);

        void ErrorAccessingFile(String file);

        void ExceptionMessage(String text);
    }
}