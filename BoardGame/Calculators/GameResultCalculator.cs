using BoardGame.Commands;
using System;
using System.Collections.Generic;

namespace BoardGame.Calculators
{
    public class GameResultCalculator : IGameResultCalculator
    {
        public GameResult CalculateGameResult(GameEvent game, ICollection<MoveEvent> moves)
        {
            var position = game.Board.StartPosition;
            var board = game.Board;

            foreach (var move in moves)
            {
                if (move is RotateEvent rotate)
                {
                    position.Direction = Rotate(position.Direction, rotate.RotateDirection);
                    continue;
                }

                if (!CanMakeMove(board, position, position.Direction))
                {
                    continue;
                }

                position = MakeMove(position, position.Direction);
            }

            return new GameResult(position);
        }

        private Position MakeMove(Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    position.Y++;
                    break;

                case Direction.South:
                    position.Y--;
                    break;

                case Direction.West:
                    position.X--;
                    break;

                case Direction.East:
                    position.X++;
                    break;
            }

            return position;
        }

        private bool CanMakeMove(Board board, Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return position.Y < board.HorizontalLength - 1;

                case Direction.South:
                    return position.Y > default(short);

                case Direction.East:
                    return position.X < board.VerticalLength - 1;

                case Direction.West:
                    return position.X > default(short);

                default:
                    throw new Exception("Unsupported direction.");
            }
        }

        private Direction Rotate(Direction currentDirection, RotateDirection rotate)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return rotate == RotateDirection.Right ? Direction.East : Direction.West;

                case Direction.South:
                    return rotate == RotateDirection.Right ? Direction.West : Direction.East;

                case Direction.East:
                    return rotate == RotateDirection.Right ? Direction.South : Direction.North;

                case Direction.West:
                    return rotate == RotateDirection.Right ? Direction.North : Direction.South;

                default:
                    throw new Exception("Unsupported direction.");
            }
        }
    }
}
