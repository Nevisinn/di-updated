using FluentAssertions;
using TagsCloud.App.Abstractions.WordsProcessing;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsProviders;

namespace TagsCloud.Test.WordsPreprocessorTests;

[TestFixture(typeof(DocWordsProvider))]
[TestFixture(typeof(TxtWordsProvider))]
public class WordsProviderTests<T> where T : IWordsProvider, new()
{
    [TearDown]
    public void TearDown()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    private T provider;
    private string filePath;

    public WordsProviderTests()
    {
        provider = new T();
        filePath = Path.Combine(Path.GetTempPath(), "test", provider.FileFormat);
    }

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

    [Test]
    public void ReadFile_ShouldThrow_WhenWordsInLine()
    {
        var inputText = "Hello, Kontur, test";

        File.WriteAllText(filePath, inputText);
        var readFile = () => provider.ReadFile(filePath);

        readFile.Should()
            .Throw<InvalidDataException>("Источником данных должен быть файл со словами по одному в строке.");
    }

    [Test]
    public void ReadFile_ShouldThrow_WhenFilePathIsNull()
    {
        filePath = null;

        var readFile = () => provider.ReadFile(filePath);

        readFile.Should().Throw<ArgumentException>("Путь до файла не валиден");
    }

    [Test]
    public void ReadFile_ShouldThrow_WhenFilePathIsEmpty()
    {
        filePath = "";

        var readFile = () => provider.ReadFile(filePath);

        readFile.Should().Throw<ArgumentException>("Путь до файла не валиден");
    }
}