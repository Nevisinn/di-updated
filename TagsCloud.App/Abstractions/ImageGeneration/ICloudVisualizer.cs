using TagsCloud.App.Models;

namespace TagsCloud.App.Abstractions.ImageGeneration;

public interface ICloudVisualizer
{
    public void VisualizeWordsWithOptions(List<string> words, ProgramOptions options);
}