using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class Command : ICommand
    {
        IConsoleInput _consoleInput;

        IStandardMessages _standardMessages;
        IErrorMessages _errorMessages;

        IValidator _validator;       

        public Command(IConsoleInput consoleInput, IStandardMessages standardMessages, IErrorMessages errorMessages, IValidator validator)
        {
            _consoleInput = consoleInput;

            _standardMessages = standardMessages;
            _errorMessages = errorMessages;
            _validator = validator;
        }

        public Int32 GetProblemDay()
        {   
            _standardMessages.SelectDay();

            Int32? day = _consoleInput.InputANumber();

            if (day == null)
                day = 0;

            if (_validator.IsDayValid(Convert.ToInt32(day)) == false)
                EndProgram();

            return Convert.ToInt32(day);
        }

        public Int32 GetProblemPart()
        {
            _standardMessages.SelectPart();

            Int32? part = _consoleInput.InputANumber();

            if (part == null)
                part = 0;

            if (_validator.IsPartValid(Convert.ToInt32(part)) == false)
                EndProgram();

            return Convert.ToInt32(part);
        }

        public void EndProgram()
        {
            _standardMessages.ExitApplication();
            _consoleInput.PressAnyKey();

            Environment.Exit(0);

        }

        public InputType GetInputType()
        {
            _standardMessages.QuestionInputType();

            Int32? inputType = _consoleInput.InputANumber();

            if (inputType == null)
                inputType = -1;

            if (_validator.IsInputTypeValid(Convert.ToInt32(inputType)) == false)
                EndProgram();

            return (InputType)inputType;
        }




    }
}
