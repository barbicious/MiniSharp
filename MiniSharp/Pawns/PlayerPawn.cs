using MiniSharp.Core;
using MiniSharp.Level;
using MiniSharp.Level.Tiles;
using SDL3;

namespace MiniSharp.Pawns;

public class PlayerPawn : HumanoidPawn
{
    public PlayerPawn(Arcade arcade, int x, int y) : base(arcade, x, y)
    {
    }

    public override void Tick()
    {
        int dx = 0, dy = 0;
        
        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.S)) dy++;

        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.W)) dy--;

        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.A)) dx--;

        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.D)) dx++;
        
        Move(dx, dy);
        
        Game.Instance.Renderer.Camera.CenterOn(X - Game.Instance.Renderer.Width / 2 + Width / 2, Y - Game.Instance.Renderer.Height / 2 + Height / 2);
        
        base.Tick();
    }

    protected override uint[] GetColors()
    {
        return
        [
            Game.Instance.Renderer.Palette.Palettize(4, 3, 2), Game.Instance.Renderer.Palette.Palettize(3, 2, 1),
            Game.Instance.Renderer.Palette.Palettize(1, 1, 5), Game.Instance.Renderer.Palette.Palettize(3, 3, 5)
        ];
    }
}