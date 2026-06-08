using System.Diagnostics;

namespace MiniSharp.Level.Tiles;

public abstract class Tile
{
    public static Tile[] Tiles { get; } = new Tile[MaxTiles];
    
    protected const int SubWidth = 8;
    protected const int SubHeight = 8;
    public const int Width = SubWidth * 2;
    public const int Height = SubHeight * 2;

    private const int MaxTiles = byte.MaxValue;
    public static readonly GrassTile GrassTile = new(0);
    public static readonly DirtTile DirtTile = new(1);
    public static readonly WaterTile WaterTile = new(2);

    protected Tile(int id)
    {
        Id = id;
        Debug.Assert(Tiles[Id] == null);
        Tiles[Id] = this;
    }
    
    public int Id { get; init; }
    
    public abstract void Blit(Arcade arcade, int x, int y);

    protected virtual uint[] GetColors()
    {
        throw new NotImplementedException();
    }

    protected virtual int GetTextureId()
    {
        throw new NotImplementedException();
    }
}