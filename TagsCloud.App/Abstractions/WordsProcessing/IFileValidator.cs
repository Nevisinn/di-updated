namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IFileValidator
{
    public void Validate(string path, string expectedExtension);
}