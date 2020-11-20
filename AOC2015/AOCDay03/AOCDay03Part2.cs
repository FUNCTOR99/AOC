using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2015
{
    public class AOCDay03Part2 : AOCProblem
    {
        List<IHouse> _visitedHouses;

        public AOCDay03Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)
        {
            _visitedHouses = Factory.CreateListHouse();
        }

        protected override String DoSolve(String[] input)
        {

            int instructionCount = 0;
            int housePresentCount = 0;

            Point santasLocation = new Point(0, 0);
            Point roboSantasLocation = new Point(0, 0);

            IHouse startingHouse = Factory.CreateHouse(santasLocation);
            startingHouse.DeliverPresent();     //from Santa
            startingHouse.DeliverPresent();     //from Robo-Santa

            _visitedHouses.Add(startingHouse);

            foreach (String line in input)
            {
                foreach (char instruction in line)
                {                 
                    switch (instruction)
                    {
                        case '^':
                            ProcessInstruction(ref santasLocation, ref roboSantasLocation, instructionCount, 0, 1);                            
                            break;

                        case 'v':
                            ProcessInstruction(ref santasLocation, ref roboSantasLocation, instructionCount, 0, -1);
                            break;

                        case '>':
                            ProcessInstruction(ref santasLocation, ref roboSantasLocation, instructionCount, 1, 0);
                            break;

                        case '<':
                            ProcessInstruction(ref santasLocation, ref roboSantasLocation, instructionCount, -1, 0);
                            break;
                    }

                    instructionCount++;
                }
                
            }

            housePresentCount = _visitedHouses.Count;

            return $"{ housePresentCount } houses received at least one present.";
            
        }

        private void AddHouseIfNew(Point point)
        {
            IHouse house = Factory.CreateHouse(point);

            if (_visitedHouses.Contains(house))
            {
                house.DeliverPresent();
            }
            else
            {
                _visitedHouses.Add(house);
            }
        }

        private void ProcessInstruction(ref Point santasLocation, ref Point roboSantasLocation, int instructionCount, int deltaX, int deltaY)
        {
            if (instructionCount % 2 == 0)
            {
                santasLocation.X = santasLocation.X + deltaX;
                santasLocation.Y = santasLocation.Y + deltaY;

                AddHouseIfNew(santasLocation);
            }
            else
            {
                roboSantasLocation.X = roboSantasLocation.X + deltaX;
                roboSantasLocation.Y = roboSantasLocation.Y + deltaY;

                AddHouseIfNew(roboSantasLocation);
            }
        }
    }
}
