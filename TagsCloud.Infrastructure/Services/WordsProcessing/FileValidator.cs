using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing;

public class FileValidator : IFileValidator
{
    public void Validate(string path, string expectedExtension)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("Файл не найден");

        var ext = Path.GetExtension(path).TrimStart('.').ToLower();
        if (expectedExtension != ext)
            throw new NotSupportedException($"Формат файла {ext} не поддерживается");

        var info = new FileInfo(path);
        if (info.Length == 0)
            throw new InvalidOperationException("Файл пустой");
    }
}