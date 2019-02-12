

using System;

namespace LetsGetChecked.Exception
{
    public class FileDoesNotExistsException : System.Exception
    {
        public FileDoesNotExistsException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}