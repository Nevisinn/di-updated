using System.Drawing;

namespace TagsCloud.Infrastructure.Services.LayoutAlgorithm.CloudLayouters;

public interface ICloudLayouter
{
    public Rectangle PutNextRectangle(Size rectangleSize);
    public void Reset();
}