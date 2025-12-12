using FluentAssertions;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

namespace TagsCloud.Test.WordsPreprocessorTests.WordsHandlersTests;

[TestFixture]
public class BoringWordsHandlerTests
{
    [SetUp]
    public void SetUp()
    {
        text = ["Hello", "KONTUR", "test"];
    }

    private List<string> text;

    [Test]
    public void Handle_ShouldExcludeBoringWords()
    {
        var boringWordsHandler = new BoringWordsHandler(["test"]);

        var handledText = boringWordsHandler.Handle(text);

        handledText.Should().Equal("hello", "kontur");
    }

    [Test]
    public void Handle_ShouldNotExcludeWithEmptyBoringWords()
    {
        var boringWordsHandler = new BoringWordsHandler([]);

        var handledText = boringWordsHandler.Handle(text);

        handledText.Should().Equal("hello", "kontur", "test");
    }
}