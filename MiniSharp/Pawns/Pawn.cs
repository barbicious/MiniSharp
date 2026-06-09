using MiniSharp.Level;
using MiniSharp.Level.Tiles;
using MiniSharp.Utilities;

namespace MiniSharp.Pawns;

public abstract class Pawn
{
    private Arcade _arcade;
    
    protected int Width { get; }
    protected int Height { get; }
    
    private int _tileY, _tileX;
    
    protected int LastX { get; private set; }
    protected int LastY { get; private set; }

    protected bool Swimming { get; set; }
    
    public Pawn(Arcade arcade, int x, int y)
    {
        _arcade = arcade;
        X = x;
        Y = y;
        Direction = Direction.South;
        Width = 16;
        Height = 16;
    }

    protected int X { get; private set; }
    protected int Y { get; private set; }
    protected Direction Direction { get; private set; }

    public virtual void Tick()
    {
        (_tileX, _tileY) = Arcade.ToTile(X, Y);

        Swimming = _arcade[_tileX, _tileY].Id == Tile.WaterTile.Id;

        var (dx, dy) = GetDirection();
        
        if (dx > 0) Direction = Direction.West;
        if (dx < 0) Direction = Direction.East;
        if (dy < 0) Direction = Direction.South;
        if (dy > 0) Direction = Direction.North;
    }

    private (int dx, int dy) GetDirection()
    {
        return (LastX - X, LastY - Y);
    }

    public void Move(int dx, int dy)
    {
        LastX = X;
        LastY = Y;
        
        MoveAxis(dx, 0);
        MoveAxis(0, dy);
    }

    private void MoveAxis(int dx, int dy)
    {
        X += dx;
        Y += dy;
        
        X = Math.Clamp(X, 0, Arcade.Width * Tile.Width - Width);
        Y = Math.Clamp(Y, 0, Arcade.Height * Tile.Height - Height);
    }
    
    public abstract void Blit();
    protected abstract uint[] GetColors();
    protected abstract int GetTextureId();
}