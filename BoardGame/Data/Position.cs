using BoardGame.Data.Enums;

namespace BoardGame.Data
{
    public class Position
    {
        public short X { get; set; }

        public short Y { get; set; }

        public Direction Direction { get; set; }

        public Position(short x, short y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
