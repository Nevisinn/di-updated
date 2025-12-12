using System.Drawing;
using TagsCloud.App.Abstractions.ImageGeneration;

namespace TagsCloud.Infrastructure.Services.ImageGeneration.ColorSchemeProviders;

public class OneColorScheme : IColorSchemeProvider
{
    public Brush GetBrush()
    {
        throw new NotImplementedException();
    }
}