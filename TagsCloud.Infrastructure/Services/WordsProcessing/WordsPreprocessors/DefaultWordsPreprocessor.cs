using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsPreprocessors;

public class DefaultWordsPreprocessor : IWordsPreprocessor
{
    private readonly IEnumerable<IWordsHandler> wordsHandlers;

    public DefaultWordsPreprocessor(IEnumerable<IWordsHandler> wordsHandlers)
    {
        this.wordsHandlers = wordsHandlers;
    }

    public List<string> Process(List<string> words)
    {
        var handlersList = wordsHandlers.ToList();

        for (var i = 0; i < handlersList.Count - 1; i++)
            handlersList[i].NextHandler = handlersList[i + 1];

        return handlersList.First().Handle(words);
    }
}