using MiniSharp.Graphics;

namespace MiniSharp.Arcade.Tiles;

public class WaterTile : LiquidTile
{
    public WaterTile(int id) : base(id)
    {
    }

    protected override uint[] GetColors(Renderer renderer)
    {
        return
        [
            renderer.Palette.Palettize(4, 3, 2), renderer.Palette.Palettize(1, 1, 2),
            renderer.Palette.Palettize(1, 1, 5), renderer.Palette.Palettize(3, 3, 5)
        ];
    }
}