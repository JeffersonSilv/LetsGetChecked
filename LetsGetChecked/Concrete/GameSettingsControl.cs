using LetsGetChecked.Abstract;
using LetsGetChecked.Helpers;
using System;
using System.Linq;
using LetsGetChecked.Exception;

namespace LetsGetChecked.Concrete
{
    public delegate void MovementControl();

    public class GameSettingsControl : IGameSettingsControl
    {
        public  Tile CurrentTileInfo { get; set; }
        public  BoardSizeInformation BoardSizeInfo { get; set; }
        public  BoardExitInformation BoardExitInfo { get; set; }
        public  BoardMiningInformation BoardMiningInfo { get; set; }
        private void ValidateNextCoordinate(Func<System.Exception> validation)
        {
            var exception = validation?.Invoke();
            if (exception != null)
            {
                throw exception;
            }
        }

        private void MoveNorth()
        {
            ValidateNextCoordinate(() =>
            {
                var newPosition = CurrentTileInfo.Y + 1;
                if (BoardMiningInfo.Mines.Any(mine => mine.Y == newPosition && mine.Y == CurrentTileInfo.Y))
                {
                    return new MineHitException($"Mine hit!! Position X {CurrentTileInfo.X} Y {newPosition}");
                }

                return newPosition > BoardSizeInfo.Position.Y ? new OutOfBondsException("Out Of Bonds") : null;
            });
            CurrentTileInfo.Y++; 
        }

        private void MoveEast()
        {
            ValidateNextCoordinate(() =>
            {
                var newPosition = CurrentTileInfo.X + 1;
                if (BoardMiningInfo.Mines.Any(mine => mine.X == newPosition && mine.Y == CurrentTileInfo.Y))
                {
                    return new MineHitException($"Mine hit!! Position X {newPosition} Y {CurrentTileInfo.Y}");
                }

                return newPosition > BoardSizeInfo.Position.X ? new OutOfBondsException("Out Of Bonds") : null;
            });

            CurrentTileInfo.X++;
        }

        private void MoveSouth()
        {
            ValidateNextCoordinate(() =>
            {
                var newPosition = CurrentTileInfo.Y - 1;
                if (BoardMiningInfo.Mines.Any(mine => mine.Y == newPosition && mine.X == CurrentTileInfo.X))
                {
                    return new MineHitException($"Mine hit!! Position X {CurrentTileInfo.X} Y {newPosition}");
                }

                return newPosition > BoardSizeInfo.Position.Y ? new OutOfBondsException("Out Of Bonds") : null;
            });

            CurrentTileInfo.Y--;
        }

        private void MoveWest()
        {
            ValidateNextCoordinate(() =>
            {
                var newPosition = CurrentTileInfo.X - 1;
                if (BoardMiningInfo.Mines.Any(mine => mine.X == newPosition && mine.Y == CurrentTileInfo.Y))
                {
                    return new MineHitException($"Mine hit!! X {newPosition} Y {CurrentTileInfo.Y}");
                }

                return newPosition > BoardSizeInfo.Position.X ? new OutOfBondsException("Out Of Bonds") : null;
            });

            CurrentTileInfo.X--;
        }

        public void RotateRight()
        {
            var next = CurrentTileInfo.Direction.Next();
            CurrentTileInfo.SetDirection(next);
        }

        public void MoveForward()
        {
            MovementControl movementControl = null;
            switch (CurrentTileInfo.Direction)
            {
                case Direction.North:
                    movementControl = MoveNorth;
                    break;
                case Direction.East:
                    movementControl = MoveEast;
                    break;
                case Direction.South:
                    movementControl = MoveSouth;
                    break;
                case Direction.West:
                    movementControl = MoveWest;
                    break;
            }

            movementControl?.Invoke();
        }

        public string OutputResult()
        {
            var result = string.Empty;

            if (CurrentTileInfo.X == BoardExitInfo.Position.X && 
                CurrentTileInfo.Y == BoardExitInfo.Position.Y)
            {
                result = "Success";
            }
            else
            {
                result = "Still In Danger!!";
            }

            Console.WriteLine(result);
            return result;
        }
    }
}