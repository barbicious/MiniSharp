using MiniSharp.Core;
using MiniSharp.Graphics.Orders;
using MiniSharp.Utilities;

namespace MiniSharp.Level.Tiles;

public abstract class GroundTile : Tile
{
    public GroundTile(int id) : base(id)
    {
    }

    public override void Blit(Arcade arcade, int x, int y)
    {
        var u = y > 0 && arcade[x, y - 1].Id == Id;
        var d = y < Arcade.Height - 1 && arcade[x, y + 1].Id == Id;
        var l = x > 0 && arcade[x - 1, y].Id == Id;
        var r = x < Arcade.Width - 1 && arcade[x + 1, y].Id == Id;

        int sx, sy = 0;

        if (u && l)
        {
            (sx, sy) = GetCenterTiles(x, y);
        }
        else
        {
            if (u)
            {
                sx = 0;
                sy = 8;
            }
            else if (l)
            {
                sx = 8;
                sy = 0;
            }
            else
            {
                sx = 0;
                sy = 0;
            }
        }

        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(sx, sy, SubWidth, SubHeight),
            Dst = new Point(x * Width, y * Height), TextureId = GetTextureId()
        });

        if (u && r)
        {
            (sx, sy) = GetCenterTiles(x, y);
        }
        else
        {
            if (u)
            {
                sx = 16;
                sy = 8;
            }
            else if (r)
            {
                sx = 8;
                sy = 0;
            }
            else
            {
                sx = 16;
                sy = 0;
            }
        }

        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(sx, sy, SubWidth, SubHeight),
            Dst = new Point(x * Width + SubWidth, y * Height), TextureId = GetTextureId()
        });

        if (d && l)
        {
            (sx, sy) = GetCenterTiles(x, y);
        }
        else
        {
            if (d)
            {
                sx = 0;
                sy = 8;
            }
            else if (l)
            {
                sx = 8;
                sy = 16;
            }
            else
            {
                sx = 0;
                sy = 16;
            }
        }

        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(sx, sy, SubWidth, SubHeight),
            Dst = new Point(x * Width, y * Height + SubHeight), TextureId = GetTextureId()
        });

        if (d && r)
        {
            (sx, sy) = GetCenterTiles(x, y);
        }
        else
        {
            if (d)
            {
                sx = 16;
                sy = 8;
            }
            else if (r)
            {
                sx = 8;
                sy = 16;
            }
            else
            {
                sx = 16;
                sy = 16;
            }
        }

        Game.Instance.Renderer.BlitSprite(new SpriteOrder
        {
            Colors = GetColors(), Src = new Rectangle(sx, sy, SubWidth, SubHeight),
            Dst = new Point(x * Width + SubWidth, y * Height + SubHeight), TextureId = GetTextureId()
        });
    }

    protected (int sx, int sy) GetCenterTiles(int x, int y)
    {
        int sx, sy;

        if (IsAnimated())
        {
            sx = ((x + Game.Instance.Ticks / 45) & 1) * SubWidth + 24;
            sy = ((x + Game.Instance.Ticks / 45) & 1) * SubHeight;
        }
        else
        {
            sx = (x & 1) * SubWidth + 24;
            sy = (y & 1) * SubHeight;
        }

        return (sx, sy);
    }

    protected override int GetTextureId()
    {
        return Game.Instance.TextureManager.GetId("ground");
    }
}