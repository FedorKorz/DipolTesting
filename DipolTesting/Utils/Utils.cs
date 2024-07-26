using System.Drawing;

namespace DipolTesting;

public static class Utils
{
    public static Color GetColorAt(int x, int y)
    {
        using var bitmap = new Bitmap(1, 1);
        using (var g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(x, y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
        }

        return bitmap.GetPixel(0, 0);
    }

    public static string ArgbToHex(Color colorInRgb)
    {
        int red = colorInRgb.R;
        int green = colorInRgb.G;
        int blue = colorInRgb.B;

        return $"#{red:X2}{green:X2}{blue:X2}";
    }
}