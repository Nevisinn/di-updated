using System.Drawing;
using TagsCloud.App.Models;

namespace TagsCloud.App.Abstractions.ImageGeneration;

public interface IColorSchemeProvider
{
    public Brush GetColorScheme(ImageOptions imageOptions);
}