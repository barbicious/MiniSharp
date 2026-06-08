using StbImageSharp;

namespace MiniSharp.Graphics;

public class Texture
{
    public const byte OpaquePixel = 0xFF;
    
    public byte[] Pixels { get; init; }

    private readonly int _width;
    private readonly int _height;

    public Texture(string filePath)
    {
        using (var stream = File.OpenRead(filePath))
        {
            var image = ImageResult.FromStream(stream);

            _width = image.Width;
            _height = image.Height;
            
            Pixels = new byte[_width * _height];

            for (int i = 0; i < Pixels.Length; i++)
            {
                Pixels[i] = image.Data[i * PixelBuffer.Channels];
            }
        }
        
        for (int i = 0; i < Pixels.Length; i++)
        {
            if (Pixels[i] == 0)
            {
                Pixels[i] = OpaquePixel;
            }

            Pixels[i] /= 64;
        }
    }
    
    public uint GetAlphaPixel(int x, int y)
    {
        var index = (y * _width + x);

        return (uint)(Pixels[index]);
    }
}