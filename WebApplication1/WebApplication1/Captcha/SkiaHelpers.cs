
using SkiaSharp;


namespace SkiaCaptcha
{


    internal class SkiaHelpers
    {


        public static int SkToArgb(SKColor col)
        {
            return SkToArgb(col.Alpha, col.Red, col.Green, col.Blue);
        }


        public static int SkToArgb(int a, int r, int g, int b)
        {
            return (a << 24) | (r << 16) | (g << 8) | (b << 0);
        }


        public static System.Tuple<int, int, int, int> ArgbToIntTuple(int argb)
        {
            int blue = argb & 0xff;
            int green = argb >> 8 & 0xff;
            int red = argb >> 16 & 0xff;
            int alpha = argb >> 24 & 0xff;

            return new System.Tuple<int, int, int, int>(alpha, red, green, blue);
        }


        public static System.Tuple<float, float, float, float> ArgbToFloatTuple(int argb)
        {
            int blue = argb & 0xff;
            int green = argb >> 8 & 0xff;
            int red = argb >> 16 & 0xff;
            int alpha = argb >> 24 & 0xff;

            float withRd = red / 255.0f;
            float withGreen = green / 255.0f;
            float withBlue = blue / 255.0f;
            float withAlpha = alpha / 255.0f;

            return new System.Tuple<float, float, float, float>(alpha, red, green, blue);
        }


        // MeasureText("Impact", 12, SKTypefaceStyle.Bold);
        internal static SkiaSharp.SKRect MeasureText(string text, SKPaint paint)
        {
            SkiaSharp.SKRect rect = new SKRect();
            paint.MeasureText(text, ref rect);
            return rect;
        } // End Function MeasureText 


        // MeasureText("Impact", 12, SKTypefaceStyle.Bold);
        public static SkiaSharp.SKRect MeasureText(string text, string fontName, float fontSize, SKTypefaceStyle fontStyle)
        {
            SkiaSharp.SKRect rect = new SKRect();

            using (SkiaSharp.SKTypeface font = SkiaSharp.SKTypeface.FromFamilyName(fontName, fontStyle))
            {

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    // paint.Color = new SKColor(0x2c, 0x3e, 0x50);
                    // paint.StrokeCap = SKStrokeCap.Round;
                    paint.Typeface = font;
                    paint.TextSize = fontSize;
                    paint.MeasureText(text, ref rect);
                } // End Using paint 

            } // End Using font 

            return rect;
        } // End Function MeasureText 

        public static void DrawText(SKCanvas canvas, string text, SKColor color, string fontName, float fontSize, SKTypefaceStyle fontStyle)
        {
            
            using (SkiaSharp.SKTypeface font = SkiaSharp.SKTypeface.FromFamilyName(fontName, fontStyle))
            {

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    paint.Color = color;
                    // paint.StrokeCap = SKStrokeCap.Round;
                    paint.Typeface = font;
                    paint.TextSize = fontSize;
                    canvas.DrawText(text, 10, 10, paint);

                } // End Using paint 

            } // End Using font 

        } // End Function MeasureText 

    }


  


}
