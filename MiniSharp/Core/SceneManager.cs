namespace MiniSharp.Core;

public class SceneManager
{
    private readonly Dictionary<string, IScene> _scenes = new();
    public string CurrentScene { private get; set; }

    public void AddScene(IScene scene)
    {
        _scenes.Add(scene.GetType().Name, scene);
    }

    public void Blit()
    {
        _scenes[CurrentScene].Blit();
    }

    public void Tick()
    {
        _scenes[CurrentScene].Tick();
    }
}