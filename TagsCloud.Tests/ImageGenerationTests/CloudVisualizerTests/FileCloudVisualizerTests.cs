/*using System.Drawing;
using System.Drawing.Imaging;
using FakeItEasy;
using FluentAssertions;
using TagsCloud.Domain.Models;
using TagsCloud.Infrastructure.Services.ImageGeneration;
using TagsCloud.Infrastructure.Services.ImageGeneration.CloudVisualizers;
using TagsCloud.Infrastructure.Services.LayoutAlgorithm.CloudLayouters;
using TagsCloud.Infrastructure.Services.LayoutAlgorithm.Spirals;
using TagsCloud.Infrastructure.Services.WordsProcessing;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsPreprocessors;

namespace TagsCloud.Test.ImageGenerationTests.CloudVisualizerTests;

[TestFixture]
public class FileCloudVisualizerTests //TODO: FileCloudVisualizerTests.cs проверить не только существование файла, но и корректность
{

    private FileCloudVisualizer visualizer;
    private ProgramOptions options;
    private string filePath;

    private List<string> words =
    [
        "csharp",
        "architecture",
        "design",
    ];

    public FileCloudVisualizerTests()
    {
        options = new ProgramOptions();
        filePath = Path.Combine(Path.GetTempPath(), "test", $"{options.ImageFormat}");
        var center = new Point(0, 0);
        var cloudLayouter = new CircularCloudLayouter(center, new ArchimedeanSpiral(center));
        visualizer = new FileCloudVisualizer(options, cloudLayouter, new DefaultWordsPreprocessor(new WordsHandler()),
            new WordsMeasurer() );
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    [Test]
    public void Visualize_ShouldCreateFile()
    {
        visualizer.Visualize(words);

        File.Exists(filePath).Should().BeTrue();
    }

    [Test]
    public void Visualize_ShouldCreateFileWithCorrectExtension()
    {
        visualizer.Visualize(words);

        File.Exists(filePath).Should().BeTrue();
        Path.GetExtension(filePath)
            .Should()
            .Be("." + options.ImageFormat.ToString().ToLower());
    }

    [Test]
    public void Visualize_ShouldCreateNonEmptyFile()
    {
        visualizer.Visualize(words);

        var fileInfo = new FileInfo(filePath);

        fileInfo.Exists.Should().BeTrue();
        fileInfo.Length.Should().BeGreaterThan(0);
    }

    [Test]
    public void Visualize_ShouldCreateImageWithCorrectResolution()
    {
        visualizer.Visualize(words);

        using var bitmap = new Bitmap(filePath);

        bitmap.Width.Should().Be(options.ImageSize.Width);
        bitmap.Height.Should().Be(options.ImageSize.Height);
    }

}*/

