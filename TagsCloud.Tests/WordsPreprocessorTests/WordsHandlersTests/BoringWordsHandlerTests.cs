using FluentAssertions;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

namespace TagsCloud.Test.WordsPreprocessorTests.WordsHandlersTests;

[TestFixture]
public class BoringWordsHandlerTests //TODO: BoringWordsHandlerTests.cs - тесты на null/пустые списки/дубликаты и т.д.
{
    private readonly List<string> text = ["Hello", "KONTUR", "test"];

    [Test]
    public void Handle_ShouldExcludeBoringWords()
    {
        var boringWordsHandler = new BoringWordsHandler(["test"]);

        var handledText = boringWordsHandler.Handle(text);

        handledText.Should().Equal("Hello", "KONTUR");
    }

    [Test]
    public void Handle_ShouldNotExcludeWithEmptyBoringWords()
    {
        var boringWordsHandler = new BoringWordsHandler([]);

        var handledText = boringWordsHandler.Handle(text);

        handledText.Should().Equal("Hello", "KONTUR", "test");
    }

    [Test]
    public void Handle_ShouldThrow_WhenBoringWordIsNull()
    {
        var boringWordsHandler = new BoringWordsHandler([null]);

        var handleText = () => boringWordsHandler.Handle(text);

        handleText.Should().Throw<ArgumentException>("Каждое скучное слово должно быть непустой строкой и " +
                                                     "не содержать спецсимволов");
    }

    [Test]
    public void Handle_ShouldThrow_WhenBoringWordIsEmpty()
    {
        var boringWordsHandler = new BoringWordsHandler([""]);

        var handleText = () => boringWordsHandler.Handle(text);

        handleText.Should().Throw<ArgumentException>("Каждое скучное слово должно быть непустой строкой и " +
                                                     "не содержать спецсимволов и цифр");
    }

    [Test]
    public void Handle_ShouldThrow_WhenBoringWordHaveSpecialSymbols()
    {
        var boringWordsHandler = new BoringWordsHandler(["t#e$x@t"]);

        var handleText = () => boringWordsHandler.Handle(text);

        handleText.Should().Throw<ArgumentException>("Каждое скучное слово должно быть непустой строкой и " +
                                                     "не содержать спецсимволов и цифр");
    }

    [Test]
    public void Handle_ShouldThrow_WhenBoringWordIsDigit()
    {
        var boringWordsHandler = new BoringWordsHandler(["123"]);

        var handleText = () => boringWordsHandler.Handle(text);

        handleText.Should().Throw<ArgumentException>("Каждое скучное слово должно быть непустой строкой и " +
                                                     "не содержать спецсимволов и цифр");
    }

    [Test]
    public void Handle_ShouldThrow_WhenBoringWordsHaveDuplicate()
    {
        var boringWordsHandler = new BoringWordsHandler(["test", "test"]);

        var handledText = boringWordsHandler.Handle(text);

        handledText.Should().Equal("Hello", "KONTUR");
    }

    [Test]
    public void Handle_ShouldThrow_WhenBoringWordsIsNull()
    {
        var boringWordsHandler = new BoringWordsHandler(null);

        var handledText = () => boringWordsHandler.Handle(text);

        handledText.Should().Throw<ArgumentException>("Список скучных слов не может быть null");
    }
}