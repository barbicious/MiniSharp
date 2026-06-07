using MiniSharp.Graphics;
using MiniSharp.Utilities;
using SDL3;

namespace MiniSharp;

public class Program
{
    private static void Main()
    {
        SDL.Init(SDL.InitFlags.Video);

        var window = SDL.CreateWindow("MiniSharp", 1280, 720, 0);

        var renderer = new Renderer(window, 320, 180);

        var running = true;
        
        var texture = new Texture("Assets/font.png");
        TextureManager.Instance.Register("Assets/font.png", "font");

        while (running)
        {
            SDL.Event ev;
            while (SDL.PollEvent(out ev))
                switch (ev.Type)
                {
                    case (uint)SDL.EventType.Quit:
                        running = false;
                        break;
                }

            renderer.Flush();

            renderer.SubmitOrder(new BlitOrder.RectOrder(new Rectangle(3, 12, 20, 10), 1, 0xFFAA44));
            renderer.SubmitOrder(new BlitOrder.RectOrder(new Rectangle(5, 8, 10, 10), 2, 0xFF00FF));
            renderer.SubmitOrder(new BlitOrder.SpriteOrder(new Rectangle(0, 0, 64, 64), new Point(3, 3), 2, new uint[]{0xFF00FF, 0xFF0000, 0x00FF00, 0x0000FF}, 0));
            renderer.SubmitOrder(new BlitOrder.PaletteOrder());

            renderer.Splat();
        }
    }
}