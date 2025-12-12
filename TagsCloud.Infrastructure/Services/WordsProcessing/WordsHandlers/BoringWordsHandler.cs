using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

public class BoringWordsHandler : IWordsHandler
{
    private HashSet<string> boringWords;

    public BoringWordsHandler(HashSet<string> boringWords)
    {
        this.boringWords = boringWords;
    }

    public List<string> Handle(List<string> words)
    {
        throw new NotImplementedException();
    }

    public IWordsHandler SetNext(IWordsHandler handler)
    {
        throw new NotImplementedException();
    }
}