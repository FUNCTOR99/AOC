using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class RacingReindeerPoints : RacingReindeer, IRacingReindeerPoints
    {
        public IRacingReindeer RacingReindeer { get; set; }
        public int Points { get; set; }

        public RacingReindeerPoints(string name, int flySpeed, int flyDuration, int restDuration) : base (name, flySpeed, flyDuration, restDuration) 
        {
            Points = 0;
        }
    }
}
