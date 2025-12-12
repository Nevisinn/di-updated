using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsPreprocessors;

public class DefaultWordsPreprocessor : IWordsPreprocessor
{
    private IWordsHandler wordsHandler;

    public DefaultWordsPreprocessor(IWordsHandler wordsHandler)
    {
        this.wordsHandler = wordsHandler;
    }

    public List<string> Process(List<string> words)
    {
        throw new NotImplementedException();
    }
}