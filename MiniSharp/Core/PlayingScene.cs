using MiniSharp.Level;

namespace MiniSharp.Core;

public class PlayingScene : IScene
{
    private readonly Arcade _arcade;

    public PlayingScene()
    {
        _arcade = new Arcade();
    }

    public void Tick()
    {
        _arcade.Tick();
    }

    public void Blit()
    {
        _arcade.Blit();
    }
}