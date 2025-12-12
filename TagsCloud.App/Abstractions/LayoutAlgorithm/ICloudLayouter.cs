using System.Drawing;

namespace TagsCloud.App.Abstractions.LayoutAlgorithm;

public interface ICloudLayouter
{
    public Rectangle PutNextRectangle(Size rectangleSize);
}