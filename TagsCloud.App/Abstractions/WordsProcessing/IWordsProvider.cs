namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IWordsProvider
{
    public string FileFormat { get; }
    public List<string> ReadFile(string path);
}