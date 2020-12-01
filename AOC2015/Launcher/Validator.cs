using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class Validator : IValidator
    {
        IErrorMessages _errorMessages;

        public Validator(IErrorMessages errorMessages)
        {
            _errorMessages = errorMessages;
        }
        public bool IsDayValid(Int32 day)
        {
            if ((day >= 1) && ((day <= 202025)))
            {
                return true;
            }
            else
            {
                _errorMessages.ErrorValidatingDay(day);
                return false;
            }
        }
                     
        public bool IsPartValid(Int32 part)
        {
            if ((part >= 1) && ((part <= 2)))
            {
                return true;
            }
            else
            {
                _errorMessages.ErrorValidatingPart(part);
                return false;
            }
        }

        public bool IsInputTypeValid(Int32 inputType)
        {
            if ((inputType >= 0) && ((inputType <= 1)))
            {
                return true;
            }
            else
            {
                _errorMessages.ErrorValidatingInputType(inputType);
                return false;
            }
        }
    }
}
