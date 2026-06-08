using MiniSharp.Utilities;

namespace MiniSharp.Graphics.Orders;

public struct SpriteOrder
{
    public Rectangle Src;
    public Point Dst;
    public uint[] Colors;
    public int TextureId;
}