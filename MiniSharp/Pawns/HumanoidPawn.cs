using MiniSharp.Core;
using MiniSharp.Graphics.Orders;
using MiniSharp.Level;
using MiniSharp.Utilities;

namespace MiniSharp.Pawns;

public abstract class HumanoidPawn : MobPawn
{
    public HumanoidPawn(Arcade arcade, int x, int y) : base(arcade, x, y)
    {
    }

    public override void Blit()
    {
        var sx = 0;
        var flipH = false;
        
        if (Direction == Direction.East)
        {
            sx = ((X >> 4) & 1) * Width + 32;
            flipH = true;
        }

        if (Direction == Direction.West)
        {
            sx = ((X >> 4) & 1) * Width + 32;
        }

        if (Direction == Direction.North)
        {
            sx = 16;
            flipH = ((Y >> 4) & 1) == 0;
        }

        if (Direction == Direction.South)
        {
            flipH = ((Y >> 4) & 1) == 0;
        }
        
        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(sx, 0, Width, Height), Dst = new Point(X, Y), TextureId = GetTextureId(), FlipHorizontal = flipH
        });
    }

    protected override int GetTextureId()
    {
        return Game.Instance.TextureManager.GetId("player");
    }
}