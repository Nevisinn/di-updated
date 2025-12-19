using Microsoft.Office.Interop.Word;
using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsProviders;

public class DocxWordsProvider : IWordsProvider
{
    private readonly FileValidator fileValidator;

    public DocxWordsProvider(FileValidator fileValidator)
    {
        this.fileValidator = fileValidator;
    }

    public List<string> ReadFile(string path)
    {
        fileValidator.Validate(path, FileFormat);

        var app = new ApplicationClass();
        var document = app.Documents.Open(path);
        var text = document.Content.Text;

        return text.Split('\n').ToList();
    }

    public string FileFormat => "docx";
}