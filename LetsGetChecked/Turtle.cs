using LetsGetChecked.Abstract;
using LetsGetChecked.Concrete;
using LetsGetChecked.Helpers;
using System;

namespace LetsGetChecked
{
    public class Turtle : ITurtle
    {
        private IGameSettingsControl GameSettingsControl { get; }
        
        public Turtle(string gameSettings)
        {
            var settings = FileHelper.ReadFile(gameSettings);

            GameSettingsControl = FileHelper.DeserializeFile<GameSettingsControl>(settings);
        }


        public string MoveTurtleFollowingSequence(string filepath)
        {
            var fileContent = FileHelper.ReadFile(filepath);

            var moves = FileHelper.DeserializeFile<Moves>(fileContent);

            foreach (var move in moves.Sequence)
            {
                switch (move)
                {
                    case ('R'):
                        GameSettingsControl.RotateRight();
                        break;
                    case ('M'):
                        GameSettingsControl.MoveForward();
                        break;
                    default:
                        throw new ArgumentException($"Invalid command: {move}");
                }
            }

            return GameSettingsControl.OutputResult();
        }
    }
}