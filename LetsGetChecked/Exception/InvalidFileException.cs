using System;


namespace LetsGetChecked.Exception
{
    public class InvalidFileException : System.Exception
    {
        public InvalidFileException(string message) : base(message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}