using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Wire : IWire
    {
        public String Name { get; set; }

        public ushort Signal { get; set; }

        public bool HasSignal { get; set; }

        public Wire()
        {
            Name = null;
            Signal = 0;
        }

        public Wire(String name)
        {
            Name = name;
            Signal = 0;
        }

        public Wire(String name, ushort signal, bool hasSignal)
        {
            Name = name;
            Signal = signal;
            HasSignal = hasSignal;
        }       

        public void SetSignal(ushort value)
        {
            Signal = value;
            HasSignal = true;
        }

        public override string ToString()
        {
            return $"[Wire Name({Name}), Signal({Signal}), HasSignal({HasSignal})]";
        }

        public string ToCSV()
        {
            return $"{Name},{Signal},{HasSignal}";
        }
    }
}
