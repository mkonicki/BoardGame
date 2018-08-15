using BoardGame.Data.Enums;

namespace BoardGame.Data
{
    public class GameResult
    {
        public readonly short X;

        public readonly short Y;

        public readonly Direction Direction;

        public GameResult(Position position)
        {
            X = position.X;
            Y = position.Y;
            Direction = position.Direction;
        }
    }
}
