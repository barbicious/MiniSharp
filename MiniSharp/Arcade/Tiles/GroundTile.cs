using MiniSharp.Graphics;
using MiniSharp.Graphics.Orders;
using MiniSharp.Utilities;

namespace MiniSharp.Arcade.Tiles;

public class GroundTile : Tile
{
    public GroundTile(int id) : base(id)
    {
    }

    public override void Blit(Arcade arcade, Renderer renderer, int x, int y)
    {
        var u = y > 0 && arcade[x, y - 1].Id == Id;
        var d = y < Arcade.Height - 1 && arcade[x, y + 1].Id == Id;
        var l = x > 0 && arcade[x - 1, y].Id == Id;
        var r = x < Arcade.Width - 1 && arcade[x + 1, y].Id == Id;

        int sx, sy = 0;
        
        if (u && l)
        {
            sx = 8;
            sy = 8;
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
        
        renderer.BlitSprite(new SpriteOrder { Colors = GetColors(renderer), Src = new Rectangle(sx, sy, SubWidth, SubHeight), Dst = new Point(x * Width, y * Height), TextureId = GetTextureId() } );
        
        if (u && r)
        {
            sx = 8;
            sy = 8;
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
        
        renderer.BlitSprite(new SpriteOrder { Colors = GetColors(renderer), Src = new Rectangle(sx, sy, SubWidth, SubHeight), Dst = new Point(x * Width + SubWidth, y * Height), TextureId = GetTextureId() } );
        
        if (d && l)
        {
            sx = 8;
            sy = 8;
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
        
        renderer.BlitSprite(new SpriteOrder { Colors = GetColors(renderer), Src = new Rectangle(sx, sy, SubWidth, SubHeight), Dst = new Point(x * Width, y * Height + SubHeight), TextureId = GetTextureId() } );
        
        if (d && r)
        {
            sx = 8;
            sy = 8;
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
        
        renderer.BlitSprite(new SpriteOrder { Colors = GetColors(renderer), Src = new Rectangle(sx, sy, SubWidth, SubHeight), Dst = new Point(x * Width + SubWidth, y * Height + SubHeight), TextureId = GetTextureId() } );


    }
    
    protected override int GetTextureId()
    {
        return TextureManager.Instance.GetId("ground");
    }
}