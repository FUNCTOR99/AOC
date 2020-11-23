using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class PasswordFinder : IPasswordFinder
    {
        private IPassword _password;

        public PasswordFinder(String passwordSeed)
        {
            _password = Factory.CreatePassword(passwordSeed);
        }

        public String FindNext()
        {
            IteratePassword();

            while (_password.IsValid() == false)
            {
                IteratePassword();
            }

            return _password.PasswordValue;
        }

        private void IteratePassword()
        {
            IncreaseChar(_password.PasswordValue.Length - 1);
        }

        private void IncreaseChar(int position)
        {
            char[] pwd = _password.PasswordValue.ToCharArray();

            if ((int)pwd[position] == 122)
            {
                pwd[position] = 'a';
                _password.UpdatePassword(new string(pwd));

                IncreaseChar(position - 1);
            }
            else
            {
                pwd[position] = (char)((int)pwd[position] + 1);
                _password.UpdatePassword(new string(pwd));
            }
        }
    }
}
