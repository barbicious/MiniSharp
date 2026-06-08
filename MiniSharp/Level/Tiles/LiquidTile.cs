using MiniSharp.Core;

namespace MiniSharp.Level.Tiles;

public abstract class LiquidTile : GroundTile

{
    public LiquidTile(int id) : base(id)
    {
    }

    protected override int GetTextureId()
    {
        return Game.Instance.TextureManager.GetId("liquid");
    }
}