
using SkiaSharp;


namespace SkiaCaptcha
{


    internal class Captcha
    {


        public static SKPaint CreatePaint()
        {
            string font = @"";
            font = @"Arial";
            font = @"Liberation Serif";
            font = @"Segoe Script";
            font = @"Consolas";
            font = @"Comic Sans MS";
            font = @"SimSun";
            font = @"Impact";

            return CreatePaint(SKColors.White, font, 40, SKTypefaceStyle.Normal);
        }


        public static SKPaint CreatePaint(SKColor color, string fontName, float fontSize, SKTypefaceStyle fontStyle)
        {
            SkiaSharp.SKTypeface font = SkiaSharp.SKTypeface.FromFamilyName(fontName, fontStyle);

            SKPaint paint = new SKPaint();

            paint.IsAntialias = true;
            paint.Color = color;
            // paint.StrokeCap = SKStrokeCap.Round;
            paint.Typeface = font;
            paint.TextSize = fontSize;

            return paint;
        }


        public static SKPaint CreateLinePaint()
        {
            SKPaint paint = new SKPaint();

            paint.IsAntialias = true;
            paint.Color = SKColors.Blue;
            paint.StrokeCap = SKStrokeCap.Square;
            paint.StrokeWidth = 1;

            return paint;
        }

        internal static byte[] GetCaptcha(string captchaText)
        {
            byte[] imageBytes = null;

            int image2d_x = 0;
            int image2d_y = 0;

            SKRect size;

            int compensateDeepCharacters = 0;

            using (SKPaint drawStyle = CreatePaint())
            {
                compensateDeepCharacters = (int)drawStyle.TextSize / 5;
                if (System.StringComparer.Ordinal.Equals(captchaText, captchaText.ToUpperInvariant()))
                    compensateDeepCharacters = 0;

                size = SkiaHelpers.MeasureText(captchaText, drawStyle);
                image2d_x = (int)size.Width + 10; 
                image2d_y = (int)size.Height + 10 + compensateDeepCharacters;
            }

            using (SKBitmap image2d = new SKBitmap(image2d_x, image2d_y, SKColorType.Bgra8888, SKAlphaType.Premul))
            {
                using (SKCanvas canvas = new SKCanvas(image2d))
                {
                    canvas.DrawColor(SKColors.Black); // Clear 

                    using (SKPaint drawStyle = CreatePaint())
                    {
                        canvas.DrawText(captchaText, 0 + 5, image2d_y - 5 - compensateDeepCharacters, drawStyle);
                    }
                    using (SKImage img = SKImage.FromBitmap(image2d))
                    {

                        using (SKData p = img.Encode(SKEncodedImageFormat.Png, 100))
                        {

                            imageBytes = p.ToArray();
                        } 

                    } 

                } 

            } 

            return imageBytes;
        }

    }

}
