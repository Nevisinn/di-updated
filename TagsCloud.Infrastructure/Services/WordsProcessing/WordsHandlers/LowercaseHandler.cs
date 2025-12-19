using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

public class LowercaseHandler : IWordsHandler
{
    public IWordsHandler? NextHandler { get; set; }

    public List<string> Handle(List<string> words)
    {
        var handledWords = words.Select(w => w.ToLower()).ToList();

        return NextHandler != null ? NextHandler.Handle(handledWords) : handledWords;
    }
}