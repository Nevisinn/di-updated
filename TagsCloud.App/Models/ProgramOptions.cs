using TagsCloud.App.Abstractions.LayoutAlgorithm;
using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.App.Models;

public class ProgramOptions
{
    public required string FilePath { get; init; }
    public required ImageOptions ImageOptions { get; init; }
    public ICloudLayouter Algorithm { get; init; }
    public IWordsProvider WordsProvider { get; init; }
}