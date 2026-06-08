using MiniSharp.Level;

namespace MiniSharp.Pawns;

public abstract class Pawn
{
    private Arcade _arcade;

    public Pawn(Arcade arcade, int x, int y)
    {
        _arcade = arcade;
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Tick();
    public abstract void Blit();
    protected abstract uint[] GetColors();
    protected abstract int GetTextureId();
}