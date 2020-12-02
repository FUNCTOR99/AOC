using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class AOCDay06Part2 : AOCProblem
    {

        public AOCDay06Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            IDimmableLight[,] lightGrid = InitializeLightGrid(1000, 1000);

            foreach (String inputLine in input)
            {
                ILightInstruction lightInstruction = Factory.CreateLightInstruction(inputLine);

                for (int x = lightInstruction.FromPoint.X; x <= lightInstruction.ToPoint.X; x++)
                {
                    for (int y = lightInstruction.FromPoint.Y; y <= lightInstruction.ToPoint.Y; y++)
                    {
                        switch (lightInstruction.Command)
                        {
                            case LightCommand.TurnOn:
                                lightGrid[x, y].TurnOn();
                                break;

                            case LightCommand.TurnOff:
                                lightGrid[x, y].TurnOff();
                                break;

                            case LightCommand.Toggle:
                                lightGrid[x, y].ToggleLight();
                                break;
                        }
                    }
                }
            }

            return $"There total brightness is {GetGridBrightness(lightGrid)}.";
        }

        private IDimmableLight[,] InitializeLightGrid(int x, int y)
        {
            IDimmableLight[,] lightGrid = new IDimmableLight[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    lightGrid[i, j] = Factory.CreateDimmableLight();
                }
            }

            return lightGrid;
        }

        private Int32 GetGridBrightness(IDimmableLight[,] lightGrid)
        {
            Int32 totalBrightness = 0;

            for (int x = 0; x < lightGrid.GetLength(0); x++)
            {
                for (int y = 0; y < lightGrid.GetLength(1); y++)
                {
                    totalBrightness = totalBrightness + lightGrid[x, y].GetLightBrightness();
                }
            }

            return totalBrightness;
        }


    }
}
