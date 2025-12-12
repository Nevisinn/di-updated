using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

public class LowercaseHandler : IWordsHandler
{
    public List<string> Handle(List<string> words)
    {
        throw new NotImplementedException();
    }

    public IWordsHandler SetNext(IWordsHandler handler)
    {
        throw new NotImplementedException();
    }
}