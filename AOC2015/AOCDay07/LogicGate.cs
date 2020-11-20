namespace AOC2015
{
    public abstract class LogicGate
    {
        public IWire InputWire1 { get; set; }
        public IWire InputWire2 { get; set; }

        public LogicGate(ref IWire inputWire1, ref IWire inputWire2, ref IWire outputWire)
        {
            InputWire1 = inputWire1;
            InputWire2 = inputWire2;
            OutputWire = outputWire;

            Executed = false;
        }

        public LogicGate(ref IWire inputWire1, ref IWire outputWire)
        {
            InputWire1 = inputWire1;
            OutputWire = outputWire;

            Executed = false;
        }

        public LogicGateType LogicGateType { get; set; }

        public IWire OutputWire { get; set; }

        public bool Executed { get; set; }

        public abstract void Execute();

        
    }
}
