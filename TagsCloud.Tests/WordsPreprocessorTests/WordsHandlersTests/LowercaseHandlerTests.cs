using FluentAssertions;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

namespace TagsCloud.Test.WordsPreprocessorTests.WordsHandlersTests;

[TestFixture]
public class LowercaseHandlerTests
{
    private readonly List<string> text = ["Hello", "KONTUR", "test"];

    [Test]
    public void Handle_ShouldConvertAllWordsToLowercase()
    {
        var lowercaseHandler = new LowercaseHandler();

        var handledText = lowercaseHandler.Handle(text);

        handledText.Should().Equal("hello", "kontur", "test");
    }
}