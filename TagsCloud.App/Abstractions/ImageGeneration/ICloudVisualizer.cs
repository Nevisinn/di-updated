using System.Drawing;

namespace TagsCloud.App.Abstractions.ImageGeneration;

public interface ICloudVisualizer
{
    public void Visualize(List<Rectangle> rectangles);
}