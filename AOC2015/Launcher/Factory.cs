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

        public static IAOCProblem CreateProblem(Int32 day, Int32 part, InputType inputType)
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



        
    }
}
