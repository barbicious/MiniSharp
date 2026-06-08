using MiniSharp.Graphics.Orders;
using SDL3;

namespace MiniSharp.Graphics;

public class Renderer
{
    private readonly int _height;

    private readonly PixelBuffer _pixelBuffer;
    private readonly nint _renderer;
    private readonly nint _texture;

    private readonly int _width;

    public Renderer(nint window, int width, int height)
    {
        _width = width;
        _height = height;
        _pixelBuffer = new PixelBuffer(width, height);
        _renderer = SDL.CreateRenderer(window, null);
        _texture = SDL.CreateTexture(_renderer, SDL.PixelFormat.ARGB8888, SDL.TextureAccess.Streaming, width, height);
        SDL.SetTextureScaleMode(_texture, SDL.ScaleMode.Nearest);
        Palette = new Palette(6);
    }

    public Palette Palette { get; }

    public void Flush()
    {
        Array.Fill<byte>(_pixelBuffer.Pixels, 0);
    }

    public void BlitSprite(SpriteOrder spriteOrder)
    {
        if (spriteOrder.Dst.X < 0 || spriteOrder.Dst.Y < 0 || spriteOrder.Dst.X >= _pixelBuffer.Width ||
            spriteOrder.Dst.Y >= _pixelBuffer.Height) return;

        var texture = TextureManager.Instance.GetTexture(spriteOrder.TextureId);

        for (var y = 0; y < spriteOrder.Src.Height; y++)
        {
            var py = y + spriteOrder.Dst.Y;

            if (py < 0 || py >= _pixelBuffer.Height) continue;

            for (var x = 0; x < spriteOrder.Src.Width; x++)
            {
                var px = x + spriteOrder.Dst.X;

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
        SDL.UpdateTexture(_texture, new SDL.Rect { X = 0, Y = 0, W = 320, H = 180 }, _pixelBuffer.Pixels,
            _pixelBuffer.Pitch);
        SDL.RenderTexture(_renderer, _texture, new SDL.FRect { X = 0, H = 180, W = 320, Y = 0 },
            new SDL.FRect { X = 0, H = 720, W = 1280, Y = 0 });
        SDL.RenderPresent(_renderer);
    }
}