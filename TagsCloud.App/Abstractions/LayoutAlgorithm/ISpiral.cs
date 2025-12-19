using System.Drawing;

namespace TagsCloud.App.Abstractions.LayoutAlgorithm;

public interface ISpiral
{
    public Point GetNextPoint();
    public void Reset();
}