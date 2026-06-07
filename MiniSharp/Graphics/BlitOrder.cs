using MiniSharp.Utilities;

namespace MiniSharp.Graphics;

public record BlitOrder(int Z)
{
    public record RectOrder(Rectangle Dst, int Z, uint Color) : BlitOrder(Z);

    public record PaletteOrder() : BlitOrder(0);

    public record SpriteOrder(Rectangle Src, Point Dst, int Z, uint[] Colors, int TextureId) : BlitOrder(Z);
}