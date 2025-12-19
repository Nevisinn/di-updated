using System.Drawing;
using TagsCloud.App.Models;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;

namespace TagsCloud.Infrastructure.Services.ImageGeneration;

public class ImageCreator
{
    public static Bitmap CreateImage
    (
        Dictionary<string, Size> wordsSizes,
        Dictionary<string, int> wordsCounts,
        List<Rectangle> rectangles,
        ImageOptions imageOptions
    )
    {
        var bitmap = new Bitmap(imageOptions.ImageSize.Width, imageOptions.ImageSize.Height);
        using var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(imageOptions.BackgroundColor);
        graphics.TranslateTransform(imageOptions.ImageSize.Width / 2f, imageOptions.ImageSize.Height / 2f);
        var brush = imageOptions.ColorScheme.GetColorScheme(imageOptions);
        var words = wordsSizes.Keys.ToList();

        for (var i = 0; i < rectangles.Count; i++)
        {
            var word = words[i];
            var tmpFont = new Font(imageOptions.Font.Name, wordsCounts[word] + imageOptions.Font.Size);

            graphics.DrawString(word, tmpFont, brush, rectangles[i]);
        }

        return bitmap;
    }
}