using StbImageSharp;

namespace MiniSharp.Graphics;

public class Texture
{
    public const byte OpaquePixel = 0xFF;
    private readonly int _height;

    private readonly int _width;

    public Texture(string filePath)
    {
        using (var stream = File.OpenRead(filePath))
        {
            var image = ImageResult.FromStream(stream);

            _width = image.Width;
            _height = image.Height;

            _pixels = new byte[_width * _height];

            for (var i = 0; i < _pixels.Length; i++) _pixels[i] = image.Data[i * PixelBuffer.Channels];
        }

        for (var i = 0; i < _pixels.Length; i++)
        {
            if (_pixels[i] == 0)
            {
                _pixels[i] = OpaquePixel;
                continue;
            }

            _pixels[i] /= 64;
        }
    }

    private readonly byte[] _pixels;

    public uint GetAlphaPixel(int x, int y)
    {
        var index = y * _width + x;

        return _pixels[index];
    }
}