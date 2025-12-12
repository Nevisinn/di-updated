namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IWordsProvider
{
    public List<string> ReadFile(string path);
}