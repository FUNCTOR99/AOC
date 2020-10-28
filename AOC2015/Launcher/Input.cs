using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class Input : IInput
    {
        // The default access modifier is "internal" is this intentional?
        InputType _inputType;
        String _filename;

        String[] _input;

        IStandardMessages _standardMessages;
        IConsoleInput _consoleInput;
        IFileInput _fileInput;

        public Input(InputType inputType, String filename, IStandardMessages standardMessages, IConsoleInput consoleInput, IFileInput fileInput)
        {
            _inputType = inputType;
            _filename = filename;

            _standardMessages = standardMessages;
            _consoleInput = consoleInput;
            _fileInput = fileInput;
        }
        public String[] GetInput()
        {
            switch (_inputType)
            {
                case InputType.Manual:
                    _input = GetManualInput();
                    break;
                case InputType.File:
                    _input = GetFileInput();
                    break;
            }

            return _input;
        }

        public String[] GetManualInput()
        {
            List<String> listOutput = new List<string>();
            String line = "";

            _standardMessages.ManualInputMessage();

            line = _consoleInput.InputCommandLine();

            while (line.ToUpper().Equals("DONE") == false)
            {
                listOutput.Add(line);
                line = _consoleInput.InputCommandLine();
            }

            return listOutput.ToArray();
        }

        public String[] GetFileInput()
        {
            String[] inputFileLines = _fileInput.InputFromFile();

            return inputFileLines;
        }

    
    }
}
