using MiniSharp.Core;
using MiniSharp.Graphics.Orders;
using MiniSharp.Level;
using MiniSharp.Level.Tiles;
using MiniSharp.Utilities;
using SDL3;

namespace MiniSharp.Graphics;

public class Renderer
{
    private readonly PixelBuffer _pixelBuffer;
    private readonly nint _renderer;
    private readonly nint _texture;
    
    public int Width { get; }
    public int Height { get; }

    public Renderer(nint window, int width, int height)
    {
        Width = width;
        Height = height;
        _pixelBuffer = new PixelBuffer(width, height);
        _renderer = SDL.CreateRenderer(window, null);
        _texture = SDL.CreateTexture(_renderer, SDL.PixelFormat.ARGB8888, SDL.TextureAccess.Streaming, width, height);
        SDL.SetTextureScaleMode(_texture, SDL.ScaleMode.Nearest);
        Palette = new Palette(6);
        Camera = new Camera(0, 0, 0, Arcade.Width * Tile.Width - width, 0, Arcade.Height * Tile.Height - height);

        SDL.SetRenderVSync(_renderer, 1);
    }

    public Palette Palette { get; }
    public Camera Camera { get; }

    public void Flush()
    {
        SDL.RenderClear(_renderer);
    }

    public void BlitSprite(SpriteOrder spriteOrder)
    {
        if (spriteOrder.Dst.X < Camera.X - spriteOrder.Src.Width || spriteOrder.Dst.Y < Camera.Y - spriteOrder.Src.Height || spriteOrder.Dst.X - Camera.X >= _pixelBuffer.Width ||
            spriteOrder.Dst.Y - Camera.Y >= _pixelBuffer.Height) return;

        var texture = Game.Instance.TextureManager.GetTexture(spriteOrder.TextureId);

        if (spriteOrder.FlipHorizontal)
            for (var y = 0; y < spriteOrder.Src.Height; y++)
            {
                var py = y + spriteOrder.Dst.Y - Camera.Y;

                if (py < 0 || py >= _pixelBuffer.Height) continue;

                for (var x = 0; x < spriteOrder.Src.Width; x++)
                {
                    var px = spriteOrder.Src.Width - x - 1 + spriteOrder.Dst.X - Camera.X;

                    if (px < 0 || px >= _pixelBuffer.Width) continue;

                    var textureIndex = texture.GetAlphaPixel(x + spriteOrder.Src.X, y + spriteOrder.Src.Y);

                    if (textureIndex == Texture.OpaquePixel) continue;

                    var pixel = Palette.Colors[spriteOrder.Colors[textureIndex]];

                    _pixelBuffer.SetPixel(px, py, pixel);
                }
            }
        else
            for (var y = 0; y < spriteOrder.Src.Height; y++)
            {
                var py = y + spriteOrder.Dst.Y - Camera.Y;

                if (py < 0 || py >= _pixelBuffer.Height) continue;

                for (var x = 0; x < spriteOrder.Src.Width; x++)
                {
                    var px = x + spriteOrder.Dst.X - Camera.X;

                    if (px < 0 || px >= _pixelBuffer.Width) continue;

                    var textureIndex = texture.GetAlphaPixel(x + spriteOrder.Src.X, y + spriteOrder.Src.Y);

                    if (textureIndex == Texture.OpaquePixel) continue;

                    var pixel = Palette.Colors[spriteOrder.Colors[textureIndex]];

                    _pixelBuffer.SetPixel(px, py, pixel);
                }
            }
    }

    public void Splat()
    {
        SDL.UpdateTexture(_texture, new SDL.Rect { X = 0, Y = 0, W = _pixelBuffer.Width, H = _pixelBuffer.Height },
            _pixelBuffer.Pixels,
            _pixelBuffer.Pitch);
        SDL.RenderTexture(_renderer, _texture,
            new SDL.FRect { X = 0, H = _pixelBuffer.Height, W = _pixelBuffer.Width, Y = 0 },
            new SDL.FRect { X = 0, H = 720, W = 1280, Y = 0 });
        SDL.RenderPresent(_renderer);
    }
}