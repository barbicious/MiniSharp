namespace MiniSharp.Graphics;

public class PixelBuffer(int width, int height)
{
    private const int Channels = 4;

    public byte[] Pixels { get; } = new byte[width * height * Channels];

    public int Pitch => width * Channels;

    public void SetPixel(int x, int y, uint color) => SetPixel(x, y, (byte)(color >> 0), (byte)(color >> 8), (byte)(color >> 16), 0xFF);
    
    public void SetPixel(int x, int y, byte r, byte g, byte b, byte a)
    {
        var index = (y * width + x) * Channels;

        Pixels[index + 0] = r;
        Pixels[index + 1] = g;
        Pixels[index + 2] = b;
        Pixels[index + 3] = a;
    }
}