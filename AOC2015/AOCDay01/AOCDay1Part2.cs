﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay1Part2 : IAOCProblem
    {

        public AOCDay1Part2(String[] input, IStandardMessages standardMessages):base(input, standardMessages) { }

        protected override string doSolve()
        {
            int currentFloor = 0;
            int currentPosition = 1;
            bool inBasement = false;

            foreach (String line in _input)
            {                       
                foreach (char x in line)
                {
                    if (x == '(')           
                        currentFloor++;
                    else if (x == ')')
                        currentFloor--;

                    if (currentFloor < 0)
                    {                        
                        inBasement = true;
                        break;
                    }

                    currentPosition++;
                }

                if (inBasement)
                    break;
            }

            return $"Santa enters the basement on position { currentPosition }.";
        }


    }
}
