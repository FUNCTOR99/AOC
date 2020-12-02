using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class LogicGateAND : LogicGate
    {
        public LogicGateAND(ref IWire inputWire1, ref IWire inputWire2, ref IWire outputWire) : base(ref inputWire1, ref inputWire2, ref outputWire)
        {
            LogicGateType = LogicGateType.And;
        }

        public override void Execute()
        {
            OutputWire.SetSignal((ushort)(InputWire1.Signal & InputWire2.Signal));
            Executed = true;
        }

        public override string ToString()
        {
            return $"Logic Gate:{LogicGateType.ToString()}, InputWire1:{InputWire1.ToString()}, InputWire2:{InputWire2.ToString()}, OutputWire:{OutputWire.ToString()}";
        }
    }
}
