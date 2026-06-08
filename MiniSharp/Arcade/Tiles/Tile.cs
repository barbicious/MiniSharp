using System.Diagnostics;
using MiniSharp.Graphics;

namespace MiniSharp.Arcade.Tiles;

public abstract class Tile
{
    protected const int SubWidth = 8;
    protected const int SubHeight = 8;
    protected const int Width = SubWidth * 2;
    protected const int Height = SubHeight * 2;

    private const int MaxTiles = byte.MaxValue;
    public static readonly GrassTile GrassTile = new(0);
    public static readonly DirtTile DirtTile = new(1);
    public static readonly WaterTile WaterTile = new(2);

    public Tile(int id)
    {
        Id = id;
        Debug.Assert(Tiles[Id] == null);
        Tiles[Id] = this;
    }

    public static Tile[] Tiles { get; } = new Tile[MaxTiles];

    public int Id { get; }

    public abstract void Blit(Arcade arcade, Renderer renderer, int x, int y);

    protected virtual uint[] GetColors(Renderer renderer)
    {
        throw new NotImplementedException();
    }

    protected virtual int GetTextureId()
    {
        throw new NotImplementedException();
    }
}