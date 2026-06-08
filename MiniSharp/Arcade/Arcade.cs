using MiniSharp.Arcade.Generation;
using MiniSharp.Arcade.Tiles;
using MiniSharp.Graphics;

namespace MiniSharp.Arcade;

public class Arcade
{
    public const int Width = 12;
    public const int Height = 12;
    
    private int[] _tiles;
    
    private ArcadeGenerator _generator;

    public Arcade()
    {
        _generator = new OverworldGenerator();
        
        _tiles = new int[Width * Height];
        
        _generator.Generate(ref _tiles);
    }

    public Tile this[int x, int y] => Tile.Tiles[_tiles[y * Width + x]];
    
    public void Blit(Renderer renderer)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                this[x, y].Blit(this, renderer, x, y);
            }
        }
    }
}