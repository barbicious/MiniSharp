using StbImageSharp;

namespace MiniSharp.Graphics;

public class Texture
{
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
            Pixels = image.Data;
        }
    }
}