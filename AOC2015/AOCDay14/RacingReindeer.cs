using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class RacingReindeer : IRacingReindeer
    {
        public IReindeer Reindeer { get; set; }

        public int DistanceTravelled { get; set; }

        private int _timeElapsed { get; set; }

        private int _flyTime;
        private int _restTime;

        private bool _isFlying;

        public RacingReindeer(String name, int flySpeed, int flyDuration, int restDuration)
        {
            Reindeer = Factory.CreateReindeer(name, flySpeed, flyDuration, restDuration);
            DistanceTravelled = 0;

            _timeElapsed = 0;
            _flyTime = 0;
            _restTime = 0;

            _isFlying = true;
        }

        public void Race1Second()
        {
            if (_isFlying)
            {
                DistanceTravelled = DistanceTravelled + Reindeer.FlySpeed;
                _flyTime++;

                if (_flyTime >= Reindeer.FlyDuration)
                {
                    _flyTime = 0;
                    _restTime = 0;
                    _isFlying = false;
                }
            }
            else
            {
                _restTime++;

                if (_restTime >= Reindeer.RestDuration)
                {
                    _flyTime = 0;
                    _restTime = 0;
                    _isFlying = true;
                }
            }
        }


    }
}
