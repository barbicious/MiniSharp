namespace MiniSharp.Graphics;

public class TextureManager
{
    private static TextureManager? _instance;
    private int _currentId;
    private readonly Dictionary<string, int> _names;

    private readonly List<Texture> _textures;

    private TextureManager()
    {
        _textures = [];
        _names = [];
        _currentId = 0;
    }

    public static TextureManager Instance => _instance ??= new TextureManager();

    public void Register(string filePath, string name)
    {
        _names[name] = _currentId;
        _textures.Add(new Texture(filePath));
        _currentId++;
    }

    public Texture GetTexture(string name)
    {
        return GetTexture(_names[name]);
    }

    public Texture GetTexture(int id)
    {
        return _textures[id];
    }

    public int GetId(string name)
    {
        return _names[name];
    }
}