using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day12Part1 : AOCProblem
    {
        public AOC2020Day12Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {         
            List<string> actions = new List<string>();

            foreach (String line in input)
            {
                actions.Add(line);
            }

            int currentX = 0;
            int currentY = 0;

            char currentDirection = 'E';

            foreach (string action in actions)
            {
                char command = action[0];
                int distance = Convert.ToInt32(action.Substring(1, action.Length - 1));

                switch (command)
                {
                    case 'N':
                    case 'S':
                    case 'E':
                    case 'W':
                        Move(command, distance, ref currentX, ref currentY);
                        break;     

                    case 'L':  
                    case 'R':
                        Rotate(command, distance, ref currentDirection);
                        break;

                    case 'F':
                        Move(currentDirection, distance, ref currentX, ref currentY);
                        break;
                }
            }

            int manhatan = Math.Abs(currentX) + Math.Abs(currentY);

            return $"Result { manhatan }.";            

        }

        private void Move(char direction, int distance, ref int x, ref int y)
        {
            switch (direction)
            {
                case 'N':
                    y = y + distance;
                    break;

                case 'S':
                    y = y - distance;
                    break;

                case 'E':
                    x = x + distance;
                    break;

                case 'W':
                    x = x - distance;
                    break;
            }
        }

        private void Rotate(char way, int angle, ref char currentDirection)
        {
            for (int i = 0; i < angle/90; i++)
            {
                switch (way)
                {
                    case 'L':
                        switch (currentDirection)
                        {
                            case 'N':
                                currentDirection = 'W';
                                break;

                            case 'S':
                                currentDirection = 'E';
                                break;

                            case 'E':
                                currentDirection = 'N';
                                break;

                            case 'W':
                                currentDirection = 'S';
                                break;
                        }
                        break;

                    case 'R':
                        switch (currentDirection)
                        {
                            case 'N':
                                currentDirection = 'E';
                                break;

                            case 'S':
                                currentDirection = 'W';
                                break;

                            case 'E':
                                currentDirection = 'S';
                                break;

                            case 'W':
                                currentDirection = 'N';
                                break;
                        }
                        break;
                }


            }

            
        }


    }
}
