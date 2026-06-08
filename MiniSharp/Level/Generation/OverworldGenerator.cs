using MiniSharp.Level.Tiles;

namespace MiniSharp.Level.Generation;

public class OverworldGenerator : ArcadeGenerator
{
    public void Generate(ref int[] tiles)
    {
        for (var y = 0; y < Arcade.Height; y++)
        for (var x = 0; x < Arcade.Width; x++)
            if (Random.Shared.NextDouble() < 0.4)
                tiles[y * Arcade.Width + x] = Tile.GrassTile.Id;
            else if (Random.Shared.NextDouble() < 0.6)
                tiles[y * Arcade.Width + x] = Tile.DirtTile.Id;
            else
                tiles[y * Arcade.Width + x] = Tile.WaterTile.Id;
    }
}