using SDL3;

namespace MiniSharp.Graphics;

public class Renderer
{
    private readonly int _height;

    private readonly PixelBuffer _pixelBuffer;
    private readonly nint _renderer;
    private readonly nint _texture;

    private readonly int _width;
    private readonly List<BlitOrder> _blitOrders;
    private readonly Palette _palette;

    public Renderer(nint window, int width, int height)
    {
        _width = width;
        _height = height;
        _pixelBuffer = new PixelBuffer(width, height);
        _renderer = SDL.CreateRenderer(window, null);
        _texture = SDL.CreateTexture(_renderer, SDL.PixelFormat.ARGB8888, SDL.TextureAccess.Streaming, width, height);
        SDL.SetTextureScaleMode(_texture, SDL.ScaleMode.Nearest);
        _palette = new Palette(6);
        _blitOrders = [];
    }

    public void Flush()
    {
        Array.Fill<byte>(_pixelBuffer.Pixels, 0);
    }

    public void SubmitOrder(BlitOrder blitOrder)
    {
        _blitOrders.Add(blitOrder);
    }

    public void Splat()
    {
        _blitOrders.Sort((a, b) => a.Z.CompareTo(b.Z));

        foreach (var blitOrder in _blitOrders)
        {
            if (blitOrder is BlitOrder.RectOrder rectOrder)
                for (var y = 0; y < rectOrder.Dst.Height; y++)
                {
                    var py = y + rectOrder.Dst.Y;
                    for (var x = 0; x < rectOrder.Dst.Width; x++)
                    {
                        var px = x + rectOrder.Dst.X;

                        _pixelBuffer.SetPixel(px, py, rectOrder.Color);
                    }
                }

            if (blitOrder is BlitOrder.PaletteOrder)
                for (var y = 0; y < _height; y++)
                for (var x = 0; x < _width; x++)
                {
                    var index = (x + y) % _palette.TotalChannels;

                    _pixelBuffer.SetPixel(x, y, _palette.Colors[index]);
                }

            if (blitOrder is BlitOrder.SpriteOrder spriteOrder)
            {
                var texture = TextureManager.Instance.GetTexture(spriteOrder.TextureId);

                for (var y = 0; y < spriteOrder.Src.Height; y++)
                {
                    var py = y + spriteOrder.Dst.Y;
                    for (var x = 0; x < spriteOrder.Src.Width; x++)
                    {
                        var px = x + spriteOrder.Dst.X;

                        var pixel = texture.Pixels[y * spriteOrder.Src.Width + x];

                        _pixelBuffer.SetPixel(px, py, pixel);
                    }
                }
            }
        }

        SDL.RenderClear(_renderer);
        SDL.UpdateTexture(_texture, new SDL.Rect { X = 0, Y = 0, W = 320, H = 180 }, _pixelBuffer.Pixels,
            _pixelBuffer.Pitch);
        SDL.RenderTexture(_renderer, _texture, new SDL.FRect { X = 0, H = 180, W = 320, Y = 0 },
            new SDL.FRect { X = 0, H = 720, W = 1280, Y = 0 });
        SDL.RenderPresent(_renderer);

        _blitOrders.Clear();
    }
}