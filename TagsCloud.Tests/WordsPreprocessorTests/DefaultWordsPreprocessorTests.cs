using FakeItEasy;
using FluentAssertions;
using TagsCloud.App.Abstractions.WordsProcessing;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsPreprocessors;

namespace TagsCloud.Test.WordsPreprocessorTests;

[TestFixture]
public class DefaultWordsPreprocessorTests
{
    [SetUp]
    public void SetUp()
    {
        handler = A.Fake<IWordsHandler>();
        preprocessor = new DefaultWordsPreprocessor(handler);
    }

    private IWordsHandler handler;
    private DefaultWordsPreprocessor preprocessor;

    [Test]
    public void Process_ShouldCallHandlerWithGivenWords()
    {
        var words = new List<string> { "Hello", "Kontur" };
        A.CallTo(() => handler.Handle(words)).Returns(words);

        preprocessor.Process(words);

        A.CallTo(() => handler.Handle(words)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void Process_ShouldReturnResultFromHandler()
    {
        var inputWords = new List<string> { "Hello" };
        var outputWords = new List<string> { "hello" };
        A.CallTo(() => handler.Handle(inputWords)).Returns(outputWords);

        var result = preprocessor.Process(inputWords);

        result.Should().BeEquivalentTo(outputWords);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHandlerIsNull()
    {
        var createPreprocessor = () => new DefaultWordsPreprocessor(null);

        createPreprocessor.Should().Throw<ArgumentNullException>();
    }
}