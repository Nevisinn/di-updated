using TagsCloud.App.Abstractions.WordsProcessing;

namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

public class WordsHandler : IWordsHandler
{
    public IWordsHandler? NextHandler { get; set; }

    public List<string> Handle(List<string> words)
    {
        if (words.Any(word => word.Any(c => !char.IsLetter(c))))
            throw new ArgumentException("Слова могут состоять только из букв");

        return NextHandler != null ? NextHandler.Handle(words) : words;
    }
}