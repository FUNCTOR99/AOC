using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class LogicGateNOT : LogicGate
    {
        public LogicGateNOT(ref IWire inputWire1, ref IWire outputWire) : base(ref inputWire1, ref outputWire)
        {
            LogicGateType = LogicGateType.Not;
        }

        public override void Execute()
        {
            OutputWire.SetSignal((ushort)~InputWire1.Signal);
            Executed = true;
        }

        public override string ToString()
        {
            return $"Logic Gate:{LogicGateType.ToString()}, InputWire1:{InputWire1.ToString()}, OutputWire:{OutputWire.ToString()}";
        }
    }
}
