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
        
        TextureManager.Instance.Register("Assets/font.png", "font");
        TextureManager.Instance.Register("Assets/ground.png", "ground");

        var arcade = new Arcade.Arcade();

        while (running)
        {
            while (SDL.PollEvent(out var ev))
                switch (ev.Type)
                {
                    case (uint)SDL.EventType.Quit:
                        running = false;
                        break;
                }

            renderer.Flush();

            arcade.Blit(renderer);

            renderer.Splat();
        }
    }
} 