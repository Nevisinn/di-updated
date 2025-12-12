using System.Drawing;

namespace TagsCloud.App.Abstractions.ImageGeneration;

public interface IColorSchemeProvider
{
    public Brush GetBrush();
}