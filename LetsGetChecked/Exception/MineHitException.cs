using System;

namespace LetsGetChecked.Exception
{
    public class MineHitException : System.Exception
    {
        public MineHitException(string message) : base(message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}