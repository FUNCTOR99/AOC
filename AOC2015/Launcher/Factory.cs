using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2015
{
    public static class Factory
    {
        public static IStandardMessages CreateStandardMessages()
        {
            return new StandardMessages();
        }

        public static IConsoleInput CreateConsoleInput()
        {
            IErrorMessages errorMessages = CreateErrorMessages();

            return new ConsoleInput(errorMessages);
        }

        public static IErrorMessages CreateErrorMessages()
        {
            return new ErrorMessages();
        }

        public static ICommand CreateCommand()
        {
            IConsoleInput input = CreateConsoleInput();
            IStandardMessages standardMessages = CreateStandardMessages();
            IErrorMessages errorMessages = CreateErrorMessages();
            IValidator validator = CreateValidator();

            return new Command( input,  standardMessages,  errorMessages, validator);
        }

        public static IValidator CreateValidator()
        {
            IErrorMessages errorMessages = CreateErrorMessages();

            return new Validator(errorMessages);
        }

        public static AOCProblem CreateProblem(Int32 day, Int32 part, InputType inputType)
        {
            ICommand command = CreateCommand();
            IStandardMessages standardMessages = CreateStandardMessages();
            
            switch (day)
            {
                case 1:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d01p01_input.txt");
                            return new AOCDay1Part1(inputp1.GetInput(), standardMessages);
                                                        
                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d01p02_input.txt");
                            return new AOCDay1Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 2:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d02p01_input.txt");
                            return new AOCDay2Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d02p02_input.txt");
                            return new AOCDay2Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 3:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d03p01_input.txt");
                            return new AOCDay03Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d03p02_input.txt");
                            return new AOCDay03Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 4:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d04p01_input.txt");
                            return new AOCDay04Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d04p02_input.txt");
                            return new AOCDay04Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 5:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d05p01_input.txt");
                            return new AOCDay05Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d05p02_input.txt");
                            return new AOCDay05Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 6:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d06p01_input.txt");
                            return new AOCDay06Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d06p02_input.txt");
                            return new AOCDay06Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 7:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d07p01_input.txt");
                            return new AOCDay07Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d07p02_input.txt");
                            return new AOCDay07Part1(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 8:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d08p01_input.txt");
                            return new AOCDay08Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d08p02_input.txt");
                            return new AOCDay08Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 9:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d09p01_input.txt");
                            return new AOCDay09Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d09p02_input.txt");
                            return new AOCDay09Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                default:
                    break;
            }

            throw new Exception("No Problem Class Defined");
        }

        public static IFileInput CreateFileInput(String filename)
        {
            IErrorMessages errorMessages = CreateErrorMessages();

            return new FileInput(errorMessages, filename);
        }

        public static IInput CreateInput(InputType inputType, String filename)
        {
            return new Input(inputType, filename, CreateStandardMessages(), CreateConsoleInput(), CreateFileInput(filename));
        }

        public static IPresent CreatePresent(int length, int width, int height)
        {
            return new Present(length, width, height);
        }

        public static IHouse CreateHouse(Point point)
        {
            return new House(point);
        }

        public static List<IHouse> CreateListHouse()
        {
            return new List<IHouse>();
        }

        public static ILight CreateLight()
        {
            return new Light();
        }

        public static IDimmableLight CreateDimmableLight()
        {
            return new DimmableLight();
        }

        public static ILightInstruction CreateLightInstruction(String lightInstruction)
        {
            return new LightInstruction(lightInstruction);
        }

        public static IWire CreateWire(String name, ushort signal, bool hasSignal)
        {
            return new Wire(name, signal, hasSignal);
        }

        public static IWire CreateWire(String name)
        {
            return new Wire(name);
        }

        public static IWire CreateWire()
        {
            return new Wire();
        }

        public static LogicGate CreateLogicGateAND(ref IWire input1, ref IWire input2, ref IWire output)
        {
            return new LogicGateAND(ref input1, ref input2, ref output);
        }

        public static LogicGate CreateLogicGateOR(ref IWire input1, ref IWire input2, ref IWire output)
        {
            return new LogicGateOR(ref input1, ref input2, ref output);
        }

        public static LogicGate CreateLogicGateNOT(ref IWire input1, ref IWire output)
        {
            return new LogicGateNOT(ref input1, ref output);
        }

        public static LogicGate CreateLogicGateAssign(ref IWire input1, ref IWire output)
        {
            return new LogicGateAssign(ref input1, ref output);
        }

        public static LogicGate CreateLogicLShift(ref IWire input1, ref IWire input2, ref IWire output)
        {
            return new LogicGateLShift(ref input1, ref input2, ref output);
        }

        public static LogicGate CreateLogicRShift(ref IWire input1, ref IWire input2, ref IWire output)
        {
            return new LogicGateRShift(ref input1, ref input2, ref output);
        }

        public static IPath<String> CreatePath(String end1, String end2, Int32 distance)
        {
            return new Path<String>(end1, end2, distance);
        }

        public static IPathCollection CreatePathCollection(List<IPath<String>> paths)
        {
            return new PathCollection<String>(paths);
        }

    }
}
