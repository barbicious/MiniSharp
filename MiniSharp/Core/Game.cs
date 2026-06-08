using MiniSharp.Graphics;
using SDL3;

namespace MiniSharp.Core;

public sealed class Game
{
    private const float FixedDeltaTime = 1f / 60f;

    private Game()
    {
        SDL.Init(SDL.InitFlags.Video | SDL.InitFlags.Audio | SDL.InitFlags.Events);

        var window = SDL.CreateWindow("MiniSharp", 1280, 720, 0);

        Renderer = new Renderer(window, 320, 180);

        TextureManager.Register("Assets/font.png", "font");
        TextureManager.Register("Assets/ground.png", "ground");
        TextureManager.Register("Assets/liquid.png", "liquid");
        TextureManager.Register("Assets/player.png", "player");

        SceneManager.AddScene(new PlayingScene());
        SceneManager.CurrentScene = nameof(PlayingScene);

        Input.Keyboard.Tick();
    }

    public static Game Instance { get; } = new();

    public Input Input { get; } = new();
    public TextureManager TextureManager { get; } = new();
    public Renderer Renderer { get; }
    public SceneManager SceneManager { get; } = new();

    public void Run()
    {
        var running = true;

        var fpsNow = DateTime.Now;
        var fpsLast = fpsNow;

        var fps = 0;
        var tps = 0;

        var now = DateTime.Now;
        var last = now;

        var accumulator = 0f;

        while (running)
        {
            while (SDL.PollEvent(out var ev))
                switch (ev.Type)
                {
                    case (uint)SDL.EventType.Quit:
                        running = false;
                        break;
                }

            if (fpsNow - fpsLast > TimeSpan.FromSeconds(1))
            {
                fpsLast = fpsNow;
                Console.WriteLine($"{fps} fps | {tps} tps");
                fps = tps = 0;
            }

            fpsNow = DateTime.Now;

            now = DateTime.Now;
            var deltaTime = now - last;
            last = now;

            accumulator += (float)deltaTime.TotalSeconds;

            while (accumulator >= FixedDeltaTime)
            {
                Input.Keyboard.Tick();
                SceneManager.Tick();

                accumulator -= FixedDeltaTime;

                tps++;
            }

            Renderer.Flush();

            SceneManager.Blit();

            Renderer.Splat();

            fps++;
        }
    }
}