using System.Linq;

namespace LetsGetChecked.Console
{
    class Program
    {
        private const int GameSettingsIndex = 0;
        private const int MoveFileIndex = 1;

        static void Main(string[] args)
        {
            if (args.ElementAt(GameSettingsIndex) == null)
            {
                System.Console.WriteLine("Input File should be informed");
            }

            if (args.ElementAt(MoveFileIndex) == null)
            {
                System.Console.WriteLine("Movement File should be informed");
            }

            var gameSettings = args[0];
            var moveFile = args[1];

            var turtle = new Turtle(gameSettings);
            turtle.MoveTurtleFollowingSequence(moveFile);
            System.Console.ReadKey();
        }
    }
}
