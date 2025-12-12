using System.Drawing;

namespace TagsCloud.App.Abstractions.ImageGeneration;

public interface IFontProvider
{
    public Font GetFont(string fontName, float size);
}