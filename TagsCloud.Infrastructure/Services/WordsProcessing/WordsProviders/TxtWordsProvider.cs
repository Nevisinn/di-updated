using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsProviders;

public class TxtWordsProvider : IWordsProvider
{
    private readonly IFileValidator fileValidator;

    public TxtWordsProvider(IFileValidator fileValidator)
    {
        this.fileValidator = fileValidator;
    }

    public List<string> ReadFile(string path)
    {
        fileValidator.Validate(path, FileFormat);

        var text = File.ReadAllText(path);
        text = text.Replace("\r", "");

        return text.Split("\n").ToList();
    }

    public string FileFormat => "txt";
}