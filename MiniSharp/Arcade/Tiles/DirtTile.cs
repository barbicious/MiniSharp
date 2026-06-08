using MiniSharp.Graphics;
using MiniSharp.Graphics.Orders;
using MiniSharp.Utilities;

namespace MiniSharp.Arcade.Tiles;

public class DirtTile : GroundTile
{
    public DirtTile(int id) : base(id)
    {
    }

    public override void Blit(Arcade arcade, Renderer renderer, int x, int y)
    {
        renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(renderer), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width, y * Height), TextureId = GetTextureId()
        });
        renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(renderer), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width + SubWidth, y * Height), TextureId = GetTextureId()
        });
        renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(renderer), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width, y * Height + SubHeight), TextureId = GetTextureId()
        });
        renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(renderer), Src = new Rectangle(24, 0, SubWidth, SubHeight),
            Dst = new Point(x * Width + SubWidth, y * Height + SubHeight), TextureId = GetTextureId()
        });
    }

    protected override uint[] GetColors(Renderer renderer)
    {
        return
        [
            renderer.Palette.Palettize(3, 2, 1), renderer.Palette.Palettize(3, 2, 1),
            renderer.Palette.Palettize(4, 3, 2), renderer.Palette.Palettize(3, 2, 1)
        ];
    }
}