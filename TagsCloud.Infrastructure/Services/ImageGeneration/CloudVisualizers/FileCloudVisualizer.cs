using System.Drawing;
using TagsCloud.App.Abstractions.ImageGeneration;
using TagsCloud.App.Abstractions.LayoutAlgorithm;
using TagsCloud.App.Abstractions.WordsProcessing;
using TagsCloud.App.Models;
using TagsCloud.Infrastructure.Services.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.ImageGeneration.CloudVisualizers;

public class FileCloudVisualizer : ICloudVisualizer
{
    private readonly IWordsPreprocessor wordsPreprocessor;

    public FileCloudVisualizer(IWordsPreprocessor wordsPreprocessor)
    {
        this.wordsPreprocessor = wordsPreprocessor;
    }

    public void VisualizeWordsWithOptions(List<string> words, ProgramOptions options)
    {
        var handledWords = wordsPreprocessor.Process(words);

        var wordsCounts = WordsCounter.GetWordsCounts(handledWords);

        var wordsSizes = WordsMeasurer.GetWordsSizes(wordsCounts, options.ImageOptions.Font);

        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;

        CreateAndSave(wordsSizes, wordsCounts, projectDirectory, options);
    }

    private void CreateAndSave
    (
        Dictionary<string, Size> wordsSizes,
        Dictionary<string, int> wordsCounts,
        string currentDirectoryPath,
        ProgramOptions options)
    {
        var rectangles = PutRectangles(wordsSizes.Values.ToList(), options.Algorithm);
        var image = ImageCreator.CreateImageWithWordsLayout(wordsSizes, wordsCounts, rectangles, options.ImageOptions);
        var imageName = $"cloud_with_{rectangles.Count}_words";

        ImageSaver.Save($"{currentDirectoryPath}/Images/{imageName}.{options.ImageOptions.ImageFormat}", image);

        options.Algorithm.Reset();
    }

    private List<Rectangle> PutRectangles(List<Size> wordsSizes, ICloudLayouter layouter)
    {
        var result = new List<Rectangle>();
        foreach (var size in wordsSizes)
            result.Add(layouter.PutNextRectangle(size));

        return result;
    }
}