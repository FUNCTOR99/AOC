using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Bags
    {

        public string BagColor { get; set; }
        public Dictionary<string, int> containBags { get; set; }

        public Bags(String inputLine)
        {
            containBags = new Dictionary<string, int>();

            ParseInput(inputLine);
        }

        private void ParseInput(String inputLine)
        {
            BagColor = StringOps.SubStringPre(inputLine, "contain").Trim();
            BagColor = BagColor.Replace("bags", "").Trim();
            BagColor = BagColor.Replace("bag", "").Trim();

            string working = StringOps.SubStringPost(inputLine, "contain").Trim();
            working = working.Replace(".", "");
            working = working.Replace("bags", "");
            working = working.Replace("bag", "");

            String[] bags = working.Split(',');

            foreach (string bag in bags)
            {
                if (!bag.Trim().Equals("no other"))
                {
                    string qty = StringOps.SubStringPre(bag.Trim(), " ");
                    int iqty = Convert.ToInt32(qty);

                    string bagColour = StringOps.SubStringPost(bag.Trim(), " ").Trim();

                    containBags.Add(bagColour, iqty);
                }
            }
        }

    }
}
