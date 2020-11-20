using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOCDay07Part1 : AOCProblem
    {
        public AOCDay07Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<IWire> wires = new List<IWire>();
            List<LogicGate> gates = new List<LogicGate>();

            int pendingGatesToExecute = 1;
            int gatesExecuted = 0;
            int cycles = 0;

            //bool gatesOutputted = false;

            //process the input
            foreach (String inputLine in input)
            {
                ParseInputLine(inputLine, ref wires, ref gates);
            }

            //Run the calcs
            while (pendingGatesToExecute > 0)
            {
                pendingGatesToExecute = 0;
                cycles++;

                //if (gatesExecuted >= 305 && !gatesOutputted)
                //{
                //    OutputWires(wires);
                //    OutputGates(gates);
                //    gatesOutputted = true;
                //}

                foreach (LogicGate gate in gates)
                {
                    if (gate.Executed == false)
                    {    
                        if ((gate.LogicGateType == LogicGateType.Assign) ||
                            (gate.LogicGateType == LogicGateType.Not))
                        {
                            if (gate.InputWire1.HasSignal == true)
                            {
                                gate.Execute();
                                gatesExecuted++;
                            }
                            else
                            {
                                pendingGatesToExecute++;
                            }
                        }
                        else if ((gate.LogicGateType == LogicGateType.And) ||
                                 (gate.LogicGateType == LogicGateType.Or) ||
                                 (gate.LogicGateType == LogicGateType.LShift) ||
                                 (gate.LogicGateType == LogicGateType.RShift))
                        {
                            if (gate.InputWire1.HasSignal && gate.InputWire2.HasSignal)
                            {
                                gate.Execute();
                                gatesExecuted++;
                            }
                            else
                            {
                                pendingGatesToExecute++;
                            }
                        }
                    }
                }
            }

            return $"Wire A has a signal: {wires.First(x => x.Name.ToUpper().Equals("A")).Signal} .";
            
        }

        private void ParseInputLine(String input, ref List<IWire> wires, ref List<LogicGate> gates)
        {
            IWire inputWire1;
            IWire inputWire2;
            IWire outputWire;

            String outputWireName = StringOps.SubStringPost(input, "->").Trim(); // input.Substring(input.IndexOf("->") + 2, input.Length - (input.IndexOf("->") + 2)).Trim() ;

            outputWire = InitializeWire(outputWireName, ref wires);

            String expression = input.Substring(0, input.IndexOf("->") - 1);

            if (expression.ToUpper().Contains("AND"))
            {
                inputWire1 = InitializeWire(StringOps.SubStringPre(expression, "AND").Trim(), ref wires);
                inputWire2 = InitializeWire(StringOps.SubStringPost(expression, "AND").Trim(), ref wires);

                gates.Add(Factory.CreateLogicGateAND(ref inputWire1, ref inputWire2, ref outputWire));
            }
            else if (expression.ToUpper().Contains("OR"))
            {
                inputWire1 = InitializeWire(StringOps.SubStringPre(expression, "OR").Trim(), ref wires);
                inputWire2 = InitializeWire(StringOps.SubStringPost(expression, "OR").Trim(), ref wires);

                gates.Add(Factory.CreateLogicGateOR(ref inputWire1, ref inputWire2, ref outputWire));
            }
            else if (expression.ToUpper().Contains("NOT"))
            {
                inputWire2 = InitializeWire(StringOps.SubStringPost(expression, "NOT").Trim(), ref wires);

                gates.Add(Factory.CreateLogicGateNOT(ref inputWire2, ref outputWire));
            }
            else if (expression.ToUpper().Contains("RSHIFT"))
            {
                inputWire1 = InitializeWire(StringOps.SubStringPre(expression, "RSHIFT").Trim(), ref wires);
                inputWire2 = InitializeWire(StringOps.SubStringPost(expression, "RSHIFT").Trim(), ref wires);

                gates.Add(Factory.CreateLogicRShift(ref inputWire1, ref inputWire2, ref outputWire));
            }
            else if (expression.ToUpper().Contains("LSHIFT"))
            {
                inputWire1 = InitializeWire(StringOps.SubStringPre(expression, "LSHIFT").Trim(), ref wires);
                inputWire2 = InitializeWire(StringOps.SubStringPost(expression, "LSHIFT").Trim(), ref wires);

                gates.Add(Factory.CreateLogicLShift(ref inputWire1, ref inputWire2, ref outputWire));
            }
            else            
            {   //Assign
                inputWire1 = InitializeWire(expression, ref wires);

                gates.Add(Factory.CreateLogicGateAssign(ref inputWire1, ref outputWire));
            }
        }

        private IWire InitializeWire(String nameOrSignal, ref List<IWire> wires)
        {
            ushort signal = 0;
            bool hasSignal = false;
            IWire wire;

            bool canConvert = ushort.TryParse(nameOrSignal, out signal);

            if (canConvert == true)
            {
                nameOrSignal = "";
                hasSignal = true;
            }
            else
            {
                if (wires.Where(x => x.Name == nameOrSignal).Count() > 0)
                {
                    return wires.First(x => x.Name == nameOrSignal);
                }
            }

            wire = Factory.CreateWire(nameOrSignal, signal, hasSignal);
            wires.Add(wire);

            return wire;
        }

        //private void OutputGates(List<LogicGate> logicGates)
        //{
        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter("gates_logfile.txt"))
        //    {
        //        foreach (LogicGate gate in logicGates)
        //        {
        //            file.WriteLine(gate.ToString());
        //        }
        //    }
        //}

        //private void OutputWires(List<IWire> wires)
        //{
        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter("wires_logfile.csv"))
        //    {
        //        foreach (IWire wire in wires)
        //        {
        //            file.WriteLine(wire.ToCSV());
        //        }
        //    }
        //}

    }
}
