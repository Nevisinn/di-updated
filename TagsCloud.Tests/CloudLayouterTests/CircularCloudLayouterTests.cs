using System.Drawing;
using FluentAssertions;
using TagsCloud.Infrastructure.Extensions;
using TagsCloud.Infrastructure.Services.LayoutAlgorithm.CloudLayouters;
using TagsCloud.Infrastructure.Services.LayoutAlgorithm.Spirals;

namespace TagsCloud.Test.CloudLayouterTests;

//TODO: CircularCloudLayouterTests.cs тесты на краевые случаи
//TODO: CircularCloudLayouterTests.cs логика схранения картинки не должна быть в teardown, нарушается srp
[TestFixture]
public class CloudLayouterTests
{
    private readonly CircularCloudLayouter cloudLayouter;
    private readonly Point center;

    public CloudLayouterTests()
    {
        center = new Point(0, 0);
        cloudLayouter = new CircularCloudLayouter(new ArchimedeanSpiral());
    }

    /*[TearDown]
    public void TearDown()
    {
        var currentContext = TestContext.CurrentContext;
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
            return;

        var workingDirectory = currentContext.WorkDirectory;
        var currentProject = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        var filePath = Path.Combine(currentProject, "Fails", $"{currentContext.Test.Name}.png");
        ImageSaver.Save(filePath, ImageCreator.CreateImage(cloudLayouter.Rectangles, new ImageOptions()));
        TestContext.WriteLine($"Tag cloud visualization saved to file {filePath}");
        TestContext.AddTestAttachment(filePath);
    }*/

    [Test]
    public void PutNextRectangle_ShouldThrowArgumentException_WhenInvalidSize()
    {
        var createZeroSize = () => cloudLayouter.PutNextRectangle(new Size(0, 0));
        var createNegativeSize = () => cloudLayouter.PutNextRectangle(new Size(-10, -10));

        createZeroSize.Should().Throw<ArgumentException>();
        createNegativeSize.Should().Throw<ArgumentException>();
    }

    [Test]
    public void PutNextRectangle_ShouldNotIntersects_WhenSameSize()
    {
        var rectangle1 = cloudLayouter.PutNextRectangle(new Size(10, 10));
        var rectangle2 = cloudLayouter.PutNextRectangle(new Size(10, 10));

        rectangle1.IntersectsWith(rectangle2).Should().BeFalse();
    }

    [Test]
    public void PutNextRectangle_ShouldBeInCenter_WhenPutFirstRectangle()
    {
        var rectangle = cloudLayouter.PutNextRectangle(new Size(10, 10));
        var rectangleCenter = rectangle.Center();

        rectangleCenter.Should().Be(center);
    }

    [Test]
    public void PutNextRectangle_ShouldNotIntersects_WhenPutManyRectangles()
    {
        for (var i = 1; i < 100; i++) cloudLayouter.PutNextRectangle(new Size(i, i));

        foreach (var rectangle1 in cloudLayouter.Rectangles)
        foreach (var rectangle2 in cloudLayouter.Rectangles)
            if (rectangle1 != rectangle2)
                rectangle1.IntersectsWith(rectangle2).Should().BeFalse();
    }

    [Test]
    public void PutNextRectangle_ShouldHaveCorrectSize_WhenPutRectangle()
    {
        var size = new Size(15, 20);

        var rect = cloudLayouter.PutNextRectangle(size);

        rect.Width.Should().Be(size.Width);
        rect.Height.Should().Be(size.Height);
    }
}