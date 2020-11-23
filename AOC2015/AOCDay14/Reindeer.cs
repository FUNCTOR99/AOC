using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Reindeer : IReindeer
    {
        public String Name { get; set; }
        public int FlySpeed { get; set; }
        public int FlyDuration { get; set; }

        public int RestDuration { get; set; }

        public Reindeer(String name, int flySpeed, int flyDuration, int restDuration)
        {
            Name = name;
            FlySpeed = flySpeed;
            FlyDuration = flyDuration;
            RestDuration = restDuration;
        }
    }
}
