using System.Drawing;
using TagsCloud.Infrastructure.Models;

namespace TagsCloud.Infrastructure.Services.ImageGeneration.ColorSchemeProviders;

public interface IColorSchemeProvider
{
    public Brush GetColorScheme(ImageOptions imageOptions);
}