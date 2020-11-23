using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay14Part1 : AOCProblem
    {
        public AOCDay14Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }        

        protected override String DoSolve(String[] input)
        {
            List<IRacingReindeer> reindeerRace = new List<IRacingReindeer>();

            //read the input
            foreach (String line in input)
            {
                String reindeerName = StringOps.SubStringPre(line, "can");
                int flySpeed = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(line, "km/s"), "fly").Trim());
                int flyDuration = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(line, "seconds,"), "km/s for").Trim());
                int restDuration = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(line, "seconds."), "rest for").Trim());

                reindeerRace.Add(Factory.CreateRacingReindeer(reindeerName, flySpeed, flyDuration, restDuration));
            }

            //Race!
            int currentSecond;
            int raceDurationSeconds = 2503;

            for (currentSecond = 0; currentSecond < raceDurationSeconds; currentSecond++)
            {
                foreach (IRacingReindeer racingReindeer in reindeerRace)
                {
                    racingReindeer.Race1Second();
                }
            }

            //who wins & how far have they travelled?
            int maxDistance = 0;
            String winningReindeerName = "";

            foreach (IRacingReindeer racingReindeer in reindeerRace)
            {
                if (racingReindeer.DistanceTravelled > maxDistance)
                {
                    maxDistance = racingReindeer.DistanceTravelled;
                    winningReindeerName = racingReindeer.Reindeer.Name;
                }
            }

            return $"{ winningReindeerName} is winning at {maxDistance} km!";            
        }     
    }
}
