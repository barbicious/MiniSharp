namespace MiniSharp.Graphics;

public class Palette
{
    public int ChannelsIndex => _channels - 1;

    private readonly int _channels;
    public uint[] Colors;

    public Palette(int channels)
    {
        _channels = channels;
        Colors = new uint[TotalChannels];
        
        var i = 0;
        for (uint r = 0; r < channels; r++)
        for (uint g = 0; g < channels; g++)
        for (uint b = 0; b < channels; b++)
        {
            var rr = (float)(r * byte.MaxValue) / ChannelsIndex;
            var gg = (float)(g * byte.MaxValue) / ChannelsIndex;
            var bb = (float)(b * byte.MaxValue) / ChannelsIndex;

            var luminance = (rr * 30f + gg * 59f + bb * 11) / 100f;

            ApplyLuminance(luminance, ref rr);
            ApplyLuminance(luminance, ref gg);
            ApplyLuminance(luminance, ref bb);

            Colors[i] = (uint)((0xFF << 24)
                               | ((int)rr << 16)
                               | ((int)gg << 8)
                               | ((int)bb << 0));

            i++;
        }

        _channelsSquared = (int)Math.Pow(_channels, 2);
    }

    public int TotalChannels => (int)Math.Pow(_channels, 3);
    private readonly int _channelsSquared;

    private void ApplyLuminance(float luminance, ref float color)
    {
        color += luminance;
        color /= 2f;
        color *= 230f / byte.MaxValue;
        color += 10f;
    }
    
    public uint Palettize(int r, int g, int b)
    {
        return (uint) ((MapColor(r * byte.MaxValue / ChannelsIndex)) * _channelsSquared +
               (MapColor(g * byte.MaxValue / ChannelsIndex)) * _channels +
               (MapColor(b * byte.MaxValue / ChannelsIndex)));
    }

    private static byte MapColor(int color)
    {
        if (color < 0)
        {
            return 0;
        }

        return (byte)(color * 100f % 10f + color * 10f % 10f + color % 10f);
    }
}