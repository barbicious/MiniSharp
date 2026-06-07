namespace MiniSharp.Graphics;

public class Palette
{
    private readonly int _channels;
    public uint[] Colors;

    public Palette(int channels)
    {
        _channels = channels;
        Colors = new uint[TotalChannels];

        var channelsIndex = channels - 1;

        var i = 0;
        for (uint r = 0; r < channels; r++)
        for (uint g = 0; g < channels; g++)
        for (uint b = 0; b < channels; b++)
        {
            var rr = (float)(r * byte.MaxValue) / channelsIndex;
            var gg = (float)(g * byte.MaxValue) / channelsIndex;
            var bb = (float)(b * byte.MaxValue) / channelsIndex;

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
    }

    public int TotalChannels => (int)Math.Pow(_channels, 3);

    private void ApplyLuminance(float luminance, ref float color)
    {
        color += luminance;
        color /= 2f;
        color *= 230f / byte.MaxValue;
        color += 10f;
    }
}