namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IDocumentWriter
{
    public void WriteText(string path, string text);
}