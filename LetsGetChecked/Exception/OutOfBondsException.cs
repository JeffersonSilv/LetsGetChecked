using System;

namespace LetsGetChecked.Exception
{
    public class OutOfBondsException : System.Exception
    {
        public OutOfBondsException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}