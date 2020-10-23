using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2015
{
    public class FileInput : IFileInput
    {
        private IErrorMessages _errorMessages;
        private String _fileName;

        public FileInput(IErrorMessages errorMessages, String fileName)
        {
            _errorMessages = errorMessages;
            _fileName = fileName;
        }

        public String[] InputFromFile()
        {
            try
            {
                return File.ReadAllLines(_fileName);
            }
            catch (Exception ex)
            {
                _errorMessages.ErrorAccessingFile(_fileName);
                _errorMessages.ExceptionMessage(ex.Message);

                return null;
            }
        }
    }
}
