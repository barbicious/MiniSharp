using SDL3;

namespace MiniSharp.Utilities;

public class Keyboard
{
    private const int MaxKeys = 512;
    private readonly bool[] _previousKeys = new bool[MaxKeys];

    private bool[] _currentKeys = new bool[MaxKeys];

    public void Tick()
    {
        for (var i = 0; i < MaxKeys; i++) _previousKeys[i] = _currentKeys[i];
        _currentKeys = SDL.GetKeyboardState(out _).ToArray();
    }

    public bool IsKeyDown(SDL.Scancode scancode)
    {
        return _currentKeys[(int)scancode] && _previousKeys[(int)scancode];
    }

    public bool IsKeyPressed(SDL.Scancode scancode)
    {
        return _currentKeys[(int)scancode] && !_previousKeys[(int)scancode];
    }
}