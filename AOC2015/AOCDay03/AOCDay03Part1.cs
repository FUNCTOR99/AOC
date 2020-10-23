using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2015
{
    public class AOCDay03Part1 : IAOCProblem
    {
        String[] _input;
        List<IHouse> _visitedHouses;

        IStandardMessages _standardMessages;

        public AOCDay03Part1(String[] input, IStandardMessages standardMessages)
        {
            _input = input;
            _standardMessages = standardMessages;

            _visitedHouses = Factory.CreateListHouse();
        }

        public void Solve()
        {
            _standardMessages.StartingProblem();

            int housePresentCount = 0;

            Point santasLocation = new Point(0, 0);

            _visitedHouses.Add(Factory.CreateHouse(santasLocation));

            foreach (String line in _input)
            {
                foreach (char instruction in line)
                {
                    switch (instruction)
                    {
                        case '^':
                            santasLocation.Y++;
                            AddHouseIfNew(santasLocation);
                            break;

                        case 'v':
                            santasLocation.Y--;
                            AddHouseIfNew(santasLocation);

                            break;

                        case '>':
                            santasLocation.X++;
                            AddHouseIfNew(santasLocation);

                            break;

                        case '<':
                            santasLocation.X--;
                            AddHouseIfNew(santasLocation);

                            break;
                    }
                }
                
            }

            housePresentCount = _visitedHouses.Count;

            _standardMessages.ProblemAnswered($"{ housePresentCount } houses received at least one present.");
            
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
    }
}
