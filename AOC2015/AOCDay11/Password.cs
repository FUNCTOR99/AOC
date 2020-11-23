using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Password : IPassword
    {
        public String PasswordValue { get; set; }

        public Password(String password)
        {
            PasswordValue = password;
        }

        public void UpdatePassword(String newPassword)
        {
            PasswordValue = newPassword;
        }


        public bool IsValid()
        {
            if (ValidateLength() == false)
                return false;

            if (ValidateNoInvalidChars() == false)
                return false;

            if (Validate3SequentialChars() == false)
                return false;

            if (ValidateContains2Pairs() == false)
                return false;

            return true;
        }

        private bool ValidateLength()
        {
            if (PasswordValue.Length == 8)
                return true;
            else
                return false;
        }

        private bool ValidateNoInvalidChars()
        {
            if (PasswordValue.Contains('i') || PasswordValue.Contains('o') || PasswordValue.Contains('l'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Validate3SequentialChars()
        {
            for (int i = 0; i < PasswordValue.Length - 2; i++)
            {
                if (((int)PasswordValue[i] + 2 == (int)PasswordValue[i + 1] + 1) && ((int)PasswordValue[i + 1] + 1 == (int)PasswordValue[i + 2]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidateContains2Pairs()
        {
            int pairCount = 0;

            for (int i = 0; i < PasswordValue.Length - 1; i++)
            {
                if (PasswordValue[i] == PasswordValue[i + 1])
                {
                    pairCount++;
                    i = i + 1;
                }
            }

            if (pairCount >= 2)
                return true;
            else
                return false;
        }
    }
}
