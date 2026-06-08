using MiniSharp.Graphics.Orders;
using MiniSharp.Utilities;

namespace MiniSharp.Graphics;

public static class Font
{
    private const int CharWidth = 8;
    private const int CharHeight = CharWidth;

    private const int CharRows = 4;
    private const int CharColumns = 16;

    private static readonly char[] Characters =
    [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
        'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '!', '/', '<', '>', ':', '+', '1', '2',
        '3', '4', '5', '6', '7', '8', '9', '0', '&', '=', '(', ')', '.', '?', ' '
    ];

    private static readonly int FontId = TextureManager.Instance.GetId("font");

    public static void BlitChar(Renderer renderer, char character, int x, int y, uint foreground, uint background)
    {
        for (var cy = 0; cy < CharRows; cy++)
        for (var cx = 0; cx < CharColumns; cx++)
        {
            var index = cy * CharColumns + cx;

            if (index >= Characters.Length) break;

            if (character != Characters[cy * CharColumns + cx]) continue;

            renderer.BlitSprite(new SpriteOrder
            {
                Colors = [foreground, 0, 0, background],
                Src = new Rectangle(cx * CharWidth, cy * CharHeight, CharWidth, CharHeight), Dst = new Point(x, y),
                TextureId = FontId
            });
        }
    }

    public static void BlitString(Renderer renderer, string str, int x, int y, uint foreground, uint background)
    {
        foreach (var c in str)
        {
            BlitChar(renderer, c, x, y, foreground, background);
            x += CharWidth;
        }
    }
}