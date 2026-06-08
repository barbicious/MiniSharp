using MiniSharp.Core;

namespace MiniSharp.Level.Tiles;

public class GrassTile : GroundTile
{
    public GrassTile(int id) : base(id)
    {
    }

    protected override uint[] GetColors()
    {
        return
        [
            Game.Instance.Renderer.Palette.Palettize(4, 3, 2), Game.Instance.Renderer.Palette.Palettize(0, 3, 0),
            Game.Instance.Renderer.Palette.Palettize(1, 4, 1), Game.Instance.Renderer.Palette.Palettize(2, 5, 2)
        ];
    }
}