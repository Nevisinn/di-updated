using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using TagsCloud.Domain.Models;
using TagsCloud.Infrastructure.Services.ImageGeneration;
using TagsCloud.Infrastructure.Services.ImageGeneration.CloudVisualizers;

namespace TagsCloud.Test.ImageGenerationTests.CloudVisualizerTests;

[TestFixture]
public class FileCloudVisualizerTests
{
    [SetUp]
    public void SetUp()
    {
        filePath = Path.Combine(Path.GetTempPath(), "test", $"{options.ImageFormat}");

        creator = A.Fake<ImageCreator>();
        A.CallTo(() => creator.CreateImage)
            .Invokes(ctx => File.WriteAllText(filePath, "test"));
        options = A.Fake<ImageOptions>();

        visualizer = new FileCloudVisualizer(creator, options);
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    private FileCloudVisualizer visualizer;
    private ImageCreator creator;
    private ImageOptions options;
    private string filePath;

    [Test]
    public void Visualize_ShouldCreateFile()
    {
        var rectangles = new List<Rectangle> { new(0, 0, 10, 10) };

        visualizer.Visualize(rectangles);

        File.Exists(filePath).Should().BeTrue();
        A.CallTo(() => creator.CreateImage).MustHaveHappenedOnceExactly();
    }
}