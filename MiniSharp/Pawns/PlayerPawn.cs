using MiniSharp.Core;
using MiniSharp.Level;
using SDL3;

namespace MiniSharp.Pawns;

public class PlayerPawn : HumanoidPawn
{
    public PlayerPawn(Arcade arcade, int x, int y) : base(arcade, x, y)
    {
    }

    public override void Tick()
    {
        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.S)) Y++;

        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.W)) Y--;

        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.A)) X--;

        if (Game.Instance.Input.Keyboard.IsKeyDown(SDL.Scancode.D)) X++;
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