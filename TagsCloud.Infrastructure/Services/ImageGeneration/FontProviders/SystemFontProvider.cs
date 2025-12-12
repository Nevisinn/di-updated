using System.Drawing;
using TagsCloud.App.Abstractions.ImageGeneration;

namespace TagsCloud.Infrastructure.Services.ImageGeneration.FontProviders;

public class SystemFontProvider : IFontProvider
{
    public Font GetFont(string fontName, float size)
    {
        return new Font(fontName, size);
    }
}