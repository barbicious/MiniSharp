using MiniSharp.Core;
using MiniSharp.Graphics.Orders;
using MiniSharp.Utilities;

namespace MiniSharp.Level.Tiles;

public class DirtTile : GroundTile
{
    public DirtTile(int id) : base(id)
    {
    }

    public override void Blit(Arcade arcade, int x, int y)
    {
        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width, y * Height), TextureId = GetTextureId()
        });
        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width + SubWidth, y * Height), TextureId = GetTextureId()
        });
        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width, y * Height + SubHeight), TextureId = GetTextureId()
        });
        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width + SubWidth, y * Height + SubHeight), TextureId = GetTextureId()
        });
    }

    protected override uint[] GetColors()
    {
        return
        [
            Game.Instance.Renderer.Palette.Palettize(3, 2, 1), Game.Instance.Renderer.Palette.Palettize(3, 2, 1),
            Game.Instance.Renderer.Palette.Palettize(4, 3, 2), Game.Instance.Renderer.Palette.Palettize(3, 2, 1)
        ];
    }
}