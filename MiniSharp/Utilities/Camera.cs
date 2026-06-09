namespace MiniSharp.Utilities;

public class Camera(int x, int y, int minX, int maxX, int minY, int maxY)
{
    private readonly int _maxX = maxX;
    private readonly int _maxY = maxY;

    private readonly int _minX = minX;
    private readonly int _minY = minY;
    public int X { get; set; } = Math.Clamp(x, minX, maxX);
    public int Y { get; set; } = Math.Clamp(y, minY, maxY);

    public void Translate(int dx, int dy)
    {
        X = Math.Clamp(X + dx, _minX, _maxX);
        Y = Math.Clamp(Y + dy, _minY, _maxY);
    }
    
    public void CenterOn(int x, int y)
    {
        X = Math.Clamp(x, _minX, _maxX);
        Y = Math.Clamp(y, _minY, _maxY);
    }
}