using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AOC2015
{
    public class LightInstruction : ILightInstruction
    {
        public LightCommand Command { get; set; }

        public Point FromPoint { get; set; }

        public Point ToPoint { get; set; }

        public LightInstruction(String commandString)
        {
            Command = SetLightCommand(commandString);

            SetToFromPoints(commandString);
        }

        //public abstract void Execute(ref ILight[,] lights);

        private LightCommand SetLightCommand(String commandString)
        {
            if (commandString.ToUpper().Contains("TURN ON"))
            {
                return LightCommand.TurnOn;
            }
            else if (commandString.ToUpper().Contains("TURN OFF"))
            {
                return LightCommand.TurnOff;
            }
            else if (commandString.ToUpper().Contains("TOGGLE"))
            {
                return LightCommand.Toggle;
            }
            else
            {
                return LightCommand.Undefined;
            }
        }

        private void SetToFromPoints(String commandString)
        {
            commandString = commandString.ToUpper().Replace("TURN ON", "");
            commandString = commandString.ToUpper().Replace("TURN OFF", "");
            commandString = commandString.ToUpper().Replace("TOGGLE", "");
            commandString = commandString.ToUpper().Replace("THROUGH", ",");

            commandString = commandString.Trim();

            String[] coordinates = commandString.Split(',');

            FromPoint = new Point(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));

            ToPoint = new Point(Convert.ToInt32(coordinates[2]), Convert.ToInt32(coordinates[3]));
        }

    }
}
