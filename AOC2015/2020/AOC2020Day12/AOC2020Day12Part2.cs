using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day12Part2 : AOCProblem
    {

        public AOC2020Day12Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<string> actions = new List<string>();

            foreach (String line in input)
            {
                actions.Add(line);
            }

            int shipX = 0;
            int shipY = 0;

            int wayPointX = 10;
            int wayPointY = 1;

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
                        MoveWayPoint(command, distance, ref wayPointX, ref wayPointY);
                        break;

                    case 'L':
                    case 'R':
                        Rotate(command, distance, ref wayPointX, ref wayPointY, shipX, shipY);
                        break;

                    case 'F':
                        MoveShip(distance, ref shipX, ref shipY, wayPointX, wayPointY);
                        break;
                }
            }

            long manhatan = Convert.ToInt64( Math.Abs(shipX)) + Convert.ToInt64(Math.Abs(shipY));

            return $"Result { manhatan }.";

        }

        private void MoveWayPoint(char direction, int distance, ref int x, ref int y)
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

        private void MoveShip(int distance, ref int shipX, ref int shipY, int wayPointX, int wayPointY)
        {
            shipX = shipX + (distance * wayPointX);
            shipY = shipY + (distance * wayPointY);
        }

        private void Rotate(char way, int angle, ref int wayPointX, ref int wayPointY, int shipX, int shipY)            
        {
            int temp = 0;

            for (int i = 0; i < angle / 90; i++)
            {
                switch (way)
                {
                    case 'L':
                        temp = wayPointX;
                        wayPointX = wayPointY * (-1);
                        wayPointY = temp;

                        break;

                    case 'R':
                        temp = wayPointX;
                        wayPointX = wayPointY;
                        wayPointY = temp * (-1);

                        break;
                }
            }
        }
    }
}
