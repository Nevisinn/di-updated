namespace TagsCloud.Infrastructure.Services.WordsProcessing.DocumentWriters;

public interface IDocumentWriter
{
    public void WriteText(string path, string text);
}