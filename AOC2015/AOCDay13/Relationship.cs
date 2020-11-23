using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Relationship : IRelationship
    {
        public int Happiness { get; set; }

        public String SourceName { get; set; }
        public String AcquaintanceName { get; set; }

        public Relationship(String sourceName, String acquaintenaceName, int happiness)
        {
            Happiness = happiness;
            SourceName = sourceName;
            AcquaintanceName = acquaintenaceName;
        }
    }
}
