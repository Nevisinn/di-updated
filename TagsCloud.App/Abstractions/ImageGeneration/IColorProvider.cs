using System.Drawing;

namespace TagsCloud.App.Abstractions.ImageGeneration;

public interface IColorProvider
{
    public Color[] GetColors(string[] names);
    public Color GetColor(string name);
}