using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class ErrorMessages : IErrorMessages
    {
        public void ErrorConvertingToNumber(String input)
        {
            Console.WriteLine($"Error Converting '{ input }' to a Number.");
        }

        public void ErrorValidatingDay(Int32 input)
        {
            Console.WriteLine($"'{ input }' is not a valid day.  Day must be between 1 and 25.");
        }

        public void ErrorValidatingPart(Int32 input)
        {
            Console.WriteLine($"'{ input }' is not a valid part.  Part must be 1 or 2.");
        }

        public void ErrorValidatingInputType(Int32 input)
        {
            Console.WriteLine($"'{ input }' is not a valid Input Type.  Input Type must be 0 for manual entry, or 1 for input from a file.");
        }

        public void ErrorAccessingFile(String file)
        {
            Console.WriteLine($"Error Accessing file: '{ file }'.");
        }

        public void ExceptionMessage(String text)
        {
            Console.WriteLine($"Exception: { text }");
        }
    }
}
