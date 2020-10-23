using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2015
{
    public class ConsoleInput : IConsoleInput
    {
        IErrorMessages _errorMessages;

        public ConsoleInput(IErrorMessages errorMessages)
        {
            _errorMessages = errorMessages;
        }
        public void PressAnyKey()
        {
            Console.Read();
        }

        public Int32? InputANumber()
        {
            Int32 output;

            String readLine;

            readLine = Console.ReadLine();

            try
            {

                output = Convert.ToInt32(readLine);

                return output;
            }
            catch (Exception ex)
            {
                _errorMessages.ErrorConvertingToNumber(readLine);
                _errorMessages.ExceptionMessage(ex.Message);

                return null;
            }
        }

        public String InputCommandLine()
        {
            return Console.ReadLine();
        }       

    }
}
