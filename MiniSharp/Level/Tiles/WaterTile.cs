using MiniSharp.Core;

namespace MiniSharp.Level.Tiles;

public class WaterTile : LiquidTile
{
    public WaterTile(int id) : base(id)
    {
    }

    protected override uint[] GetColors()
    {
        return
        [
            Game.Instance.Renderer.Palette.Palettize(4, 3, 2), Game.Instance.Renderer.Palette.Palettize(3, 2, 1),
            Game.Instance.Renderer.Palette.Palettize(1, 1, 5), Game.Instance.Renderer.Palette.Palettize(3, 3, 5)
        ];
    }
}