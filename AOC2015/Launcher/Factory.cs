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

                case 10:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d10p01_input.txt");
                            return new AOCDay10Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d10p02_input.txt");
                            return new AOCDay10Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 11:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d11p01_input.txt");
                            return new AOCDay11Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d11p02_input.txt");
                            return new AOCDay11Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 12:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d12p01_input.txt");
                            return new AOCDay12Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d12p02_input.txt");
                            return new AOCDay12Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 13:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d13p01_input.txt");
                            return new AOCDay13Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d13p02_input.txt");
                            return new AOCDay13Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 14:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d14p01_input.txt");
                            return new AOCDay14Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d14p02_input.txt");
                            return new AOCDay14Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 15:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d15p01_input.txt");
                            return new AOCDay15Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d15p02_input.txt");
                            return new AOCDay15Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 16:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d16p01_input.txt");
                            return new AOCDay16Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d16p02_input.txt");
                            return new AOCDay16Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 17:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2015_d17p01_input.txt");
                            return new AOCDay17Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2015_d17p02_input.txt");
                            return new AOCDay17Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202001:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d01p01_input.txt");
                            return new AOC2020Day01Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d01p01_input.txt");
                            return new AOC2020Day01Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202002:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d02p01_input.txt");
                            return new AOC2020Day02Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d02p01_input.txt");
                            return new AOC2020Day02Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202003:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d03p01_input.txt");
                            return new AOC2020Day03Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d03p01_input.txt");
                            return new AOC2020Day03Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202004:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d04p01_input.txt");
                            return new AOC2020Day04Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d04p01_input.txt");
                            return new AOC2020Day04Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202005:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d05p01_input.txt");
                            return new AOC2020Day05Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d05p01_input.txt");
                            return new AOC2020Day05Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202006:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d06p01_input.txt");
                            return new AOC2020Day06Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d06p01_input.txt");
                            return new AOC2020Day06Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202007:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d07p01_input.txt");
                            return new AOC2020Day07Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d07p01_input.txt");
                            return new AOC2020Day07Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202008:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d08p01_input.txt");
                            return new AOC2020Day08Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d08p01_input.txt");
                            return new AOC2020Day08Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202009:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d09p01_input.txt");
                            return new AOC2020Day09Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d09p01_input.txt");
                            return new AOC2020Day09Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202010:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d10p01_input.txt");
                            return new AOC2020Day10Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d10p01_input.txt");
                            return new AOC2020Day10Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202011:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d11p01_input.txt");
                            return new AOC2020Day11Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d11p01_input.txt");
                            return new AOC2020Day11Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202012:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d12p01_input.txt");
                            return new AOC2020Day12Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d12p01_input.txt");
                            return new AOC2020Day12Part2(inputp2.GetInput(), standardMessages);
                    }
                    break;

                case 202013:
                    switch (part)
                    {
                        case 1:
                            IInput inputp1 = CreateInput(inputType, "Inputs/2020_d13p01_input.txt");
                            return new AOC2020Day13Part1(inputp1.GetInput(), standardMessages);

                        case 2:
                            IInput inputp2 = CreateInput(inputType, "Inputs/2020_d13p01_input.txt");
                            return new AOC2020Day13Part2(inputp2.GetInput(), standardMessages);
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

        public static IPassword CreatePassword(String password)
        {
            return new Password(password);
        }

        public static IPasswordFinder CreatePasswordFinder(String passwordSeed)
        {
            return new PasswordFinder(passwordSeed);
        }

        public static IRelationship CreateRelationship(String sourceName, String acquaintenaceName, int happiness)
        {
            return new Relationship( sourceName,  acquaintenaceName,  happiness);
        }

        public static ITableSeating CreateTableSeating()
        {
            return new TableSeating();
        }

        public static IReindeer CreateReindeer(String name, int flySpeed, int flyDuration, int restDuration)
        {
            return new Reindeer(name, flySpeed, flyDuration, restDuration);
        }

        public static IRacingReindeer CreateRacingReindeer(String name, int flySpeed, int FlyDuration, int restDuration)
        {
            return new RacingReindeer(name, flySpeed, FlyDuration, restDuration);
        }

        public static IRacingReindeerPoints CreateRacingReindeerPoints(String name, int flySpeed, int FlyDuration, int restDuration)
        {
            return new RacingReindeerPoints(name, flySpeed, FlyDuration, restDuration);
        }

        public static IIngredient CreateIngredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            return new Ingredient(name, capacity, durability, flavor, texture, calories);
        }

        public static ICookie CreateCookie(List<IIngredient> ingredients, int[] ingredientQuantities)
        {
            return new Cookie(ingredients, ingredientQuantities);
        }

        public static IAuntSue CreateAuntSue(String inputParameters)
        {
            return new AuntSue(inputParameters);
        }

        public static IRealAuntSue CreateRealAuntSue(String inputParameters)
        {
            return new RealAuntSue(inputParameters);
        }

        public static INode CreateNode(int value)
        {
            return new Node(value);
        }

        public static IAdapterTree CreateAdapterTree(int[] values)
        {
            return new AdapterTree(values);
        }
    }
}
