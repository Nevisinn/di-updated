using System.Drawing;

namespace TagsCloud.Domain.Models;

public class ImageOptions
{
    public Color BackgroundColor { get; init; } = Color.Black;
    public Size ImageSize { get; init; } = new(1000, 1000);
    public Color RectangleBorderColor { get; init; } = Color.CornflowerBlue;
    public Color RectangleFillColor { get; init; } = Color.MidnightBlue;
    public ImageFormat ImageFormat { get; init; } = ImageFormat.Png;
}