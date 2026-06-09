namespace MiniSharp.Utilities;

public struct Point(int x, int y)
{
    public readonly int X = x;
    public readonly int Y = y;

    public static Point FromDirection(Direction direction)
    {
        return direction switch
        {
            Direction.East => new Point(-1, 0),
            Direction.West => new Point(1, 0),
            Direction.North => new Point(0, 1),
            Direction.South => new Point(0, -1),
        };
    }
}