using MiniSharp.Graphics;

namespace MiniSharp.Arcade.Tiles;

public class GrassTile : GroundTile
{
    public GrassTile(int id) : base(id)
    {
    }
    
    protected override uint[] GetColors(Renderer renderer)
    {
        return
        [
            renderer.Palette.Palettize(4, 3, 2), renderer.Palette.Palettize(1, 2, 1),
            renderer.Palette.Palettize(1, 3, 1), renderer.Palette.Palettize(1, 4, 1)
        ];
    }
}