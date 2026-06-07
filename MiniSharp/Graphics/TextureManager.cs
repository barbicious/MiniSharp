namespace MiniSharp.Graphics;

public class TextureManager
{
    private static TextureManager? _instance;
    public static TextureManager Instance => _instance ??= new TextureManager();
    
    private List<Texture> _textures;
    private Dictionary<string, int> _names;
    private int _currentId;

    private TextureManager()
    {
        _textures = [];
        _names = [];
        _currentId = 0;
    }

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