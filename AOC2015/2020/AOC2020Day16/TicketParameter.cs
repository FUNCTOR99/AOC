using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class TicketParameter : ITicketParameter
    {
        public string Name { get; set; }

        public int Range1Min { get; set; }
        public int Range1Max { get; set; }
        public int Range2Min { get; set; }
        public int Range2Max { get; set; }

        public TicketParameter(string input)
        {
            ParseInput(input);
        }

        private void ParseInput(String input)
        {
            Name = StringOps.SubStringPre(input, ":").Trim();

            Range1Min = Convert.ToInt32(StringOps.SubStringPostAndPre(input, ":", "-").Trim());
            Range1Max = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPre(input, " or ").Trim(), "-").Trim());

            Range2Min = Convert.ToInt32(StringOps.SubStringPre(StringOps.SubStringPost(input, " or ").Trim(), "-").Trim());
            Range2Max = Convert.ToInt32(StringOps.SubStringPost(StringOps.SubStringPost(input, " or ").Trim(), "-").Trim());

        }

        public bool IsValid(int value)
        {
            if ((value >= Range1Min) && (value <= Range1Max))
                return true;

            if ((value >= Range2Min) && (value <= Range2Max))
                return true;

            return false;
        }
    }
}
