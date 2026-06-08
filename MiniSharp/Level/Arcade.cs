using MiniSharp.Level.Generation;
using MiniSharp.Level.Tiles;
using MiniSharp.Pawns;

namespace MiniSharp.Level;

public class Arcade
{
    public const int Width = 25;
    public const int Height = 12;

    private readonly ArcadeGenerator _generator;

    private readonly List<Pawn> _pawns;

    private readonly int[] _tiles;

    public Arcade()
    {
        _generator = new OverworldGenerator();

        _tiles = new int[Width * Height];

        _generator.Generate(ref _tiles);

        _pawns = [new PlayerPawn(this, 3, 3)];
    }

    public Tile this[int x, int y] => Tile.Tiles[_tiles[y * Width + x]];

    public void Tick()
    {
        _pawns.ForEach(p => p.Tick());
    }

    public void Blit()
    {
        for (var y = 0; y < Height; y++)
        for (var x = 0; x < Width; x++)
            this[x, y].Blit(this, x, y);

        _pawns.ForEach(p => p.Blit());
    }
}