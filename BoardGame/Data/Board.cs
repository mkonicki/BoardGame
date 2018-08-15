using BoardGame.Data.Enums;

namespace BoardGame.Data
{
    public class Board
    {
        public readonly short VerticalLength = 5;

        public readonly short HorizontalLength = 5;

        public readonly Position StartPosition = new Position(0, 0, Direction.North);
    }
}
