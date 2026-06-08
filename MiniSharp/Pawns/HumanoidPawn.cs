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
        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(0, 0, 16, 16), Dst = new Point(X, Y), TextureId = GetTextureId()
        });
    }

    protected override int GetTextureId()
    {
        return Game.Instance.TextureManager.GetId("player");
    }
}