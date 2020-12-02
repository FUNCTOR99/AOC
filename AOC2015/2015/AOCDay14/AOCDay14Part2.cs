using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay14Part2 : AOCProblem
    {
        public AOCDay14Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages)     { }

        protected override String DoSolve(String[] input)
        {
            List<IRacingReindeerPoints> reindeerRace = new List<IRacingReindeerPoints>();

            //read the input
            foreach (String line in input)
            {
                String reindeerName = StringOps.SubStringPre(line, "can");
                int flySpeed = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(line, "km/s"), "fly").Trim());
                int flyDuration = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(line, "seconds,"), "km/s for").Trim());
                int restDuration = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(line, "seconds."), "rest for").Trim());

                reindeerRace.Add(Factory.CreateRacingReindeerPoints(reindeerName, flySpeed, flyDuration, restDuration));
            }

            //Race!
            int currentSecond;
            int raceDurationSeconds = 2503;

            for (currentSecond = 0; currentSecond < raceDurationSeconds; currentSecond++)
            {
                foreach (IRacingReindeerPoints racingReindeer in reindeerRace)
                {
                    racingReindeer.Race1Second();
                }

                //Assign Points to the leader(s)
                //Find the most distance travelled
                int currentMaxDistance = 0;
                foreach (IRacingReindeerPoints racingReindeer in reindeerRace)
                {
                    if (racingReindeer.DistanceTravelled > currentMaxDistance)
                    {
                        currentMaxDistance = racingReindeer.DistanceTravelled;
                    }
                }

                //assign points to the reindeer with that maxdistance
                foreach (IRacingReindeerPoints racingReindeer in reindeerRace)
                {
                    if (racingReindeer.DistanceTravelled == currentMaxDistance)
                    {
                        racingReindeer.Points++;
                    }
                }
            }

            //who wins & how far have they travelled?
            int maxPoints = 0;
            String winningReindeerName = "";

            foreach (IRacingReindeerPoints racingReindeer in reindeerRace)
            {
                if (racingReindeer.Points > maxPoints)
                {
                    maxPoints = racingReindeer.Points;
                    winningReindeerName = racingReindeer.Reindeer.Name;
                }
            }



            return $"{ winningReindeerName} is winning at {maxPoints} points!";

        }


      
    }
}
