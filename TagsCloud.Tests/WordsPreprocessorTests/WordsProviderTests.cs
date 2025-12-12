using FluentAssertions;
using TagsCloud.App.Abstractions.WordsProcessing;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsProviders;

namespace TagsCloud.Test.WordsPreprocessorTests;

[TestFixture(typeof(DocWordsProvider))]
[TestFixture(typeof(TxtWordsProvider))]
public class WordsProviderTests<T> where T : IWordsProvider, new()
{
    [SetUp]
    public void SetUp()
    {
        provider = new T();
        var tempFile = Path.Combine(Path.GetTempPath(), "test");
        if (typeof(T) == typeof(TxtWordsProvider))
            filePath = tempFile + ".txt";
        else if (typeof(T) == typeof(DocWordsProvider))
            filePath = tempFile + ".docx";
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    private T provider;
    private string filePath = "";

    [Test]
    public void ReadFile_ShouldReturnExpectedWords()
    {
        var inputText = "Hello\nKontur\ntest";
        var expectedWords = new List<string>
        {
            "Hello", "Kontur", "test"
        };

        File.WriteAllText(filePath, inputText);
        var words = provider.ReadFile(filePath);

        words.Should().BeEquivalentTo(expectedWords);
    }

    [Test]
    public void ReadFile_ShouldThrow_WhenFileNotFound()
    {
        var missingPath = filePath + "missing";

        var readFile = () => provider.ReadFile(missingPath);

        readFile.Should().Throw<FileNotFoundException>();
    }

    [Test]
    public void ReadFile_ShouldThrow_WhenFileIsEmpty()
    {
        File.WriteAllText(filePath, string.Empty);

        var readFile = () => provider.ReadFile(filePath);

        readFile.Should().Throw<InvalidDataException>("Файл пуст");
    }
}