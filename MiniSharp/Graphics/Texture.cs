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

            Pixels = new byte[_width * _height];

            for (var i = 0; i < Pixels.Length; i++) Pixels[i] = image.Data[i * PixelBuffer.Channels];
        }

        for (var i = 0; i < Pixels.Length; i++)
        {
            if (Pixels[i] == 0) Pixels[i] = OpaquePixel;

            Pixels[i] /= 64;
        }
    }

    public byte[] Pixels { get; init; }

    public uint GetAlphaPixel(int x, int y)
    {
        var index = y * _width + x;

        return Pixels[index];
    }
}