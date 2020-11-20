using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class LogicGateAssign : LogicGate
    {
        public LogicGateAssign(ref IWire inputWire1, ref IWire outputWire) : base(ref inputWire1, ref outputWire)
        {
            LogicGateType = LogicGateType.Assign;
        }

        public override void Execute()
        {
            OutputWire.SetSignal(InputWire1.Signal);
            Executed = true;
        }

        public override string ToString()
        {
            return $"Logic Gate:{LogicGateType.ToString()}, InputWire1:{InputWire1.ToString()}, OutputWire:{OutputWire.ToString()}";
        }
    }
}
