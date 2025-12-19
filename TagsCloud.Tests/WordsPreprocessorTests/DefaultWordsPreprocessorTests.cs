/*using FakeItEasy;
using FluentAssertions;
using TagsCloud.App.Abstractions.WordsProcessing;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsPreprocessors;

namespace TagsCloud.Test.WordsPreprocessorTests;

[TestFixture]
public class DefaultWordsPreprocessorTests
{
    private readonly IWordsPreprocessor preprocessor;
    private readonly IWordsHandler handler;

    public DefaultWordsPreprocessorTests()
    {
        handler = new LowercaseHandler();
        preprocessor = new DefaultWordsPreprocessor();
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
    public void Handle_ShouldThrowArgumentNullException_WhenHandlerIsNull()
    {
        var createPreprocessor = () => new DefaultWordsPreprocessor(null);

        createPreprocessor.Should().Throw<ArgumentNullException>();
    }
}*/

