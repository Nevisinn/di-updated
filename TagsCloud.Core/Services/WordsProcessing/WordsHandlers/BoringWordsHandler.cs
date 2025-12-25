namespace TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;

public class BoringWordsHandler : IWordsHandler
{
    private readonly HashSet<string> boringWords;

    public BoringWordsHandler(HashSet<string> boringWords)
    {
        this.boringWords = boringWords;
    }

    public IWordsHandler? NextHandler { get; set; }

    public List<string> Handle(List<string> words)
    {
        ValidateBoringWords();

        var handledWords = new List<string>();

        foreach (var word in words)
            if (!boringWords.Contains(word))
                handledWords.Add(word);

        return NextHandler != null ? NextHandler.Handle(handledWords) : handledWords;
    }

    private void ValidateBoringWords()
    {
        if (boringWords == null) throw new ArgumentException("Список скучных слов не может быть null");

        foreach (var boringWord in boringWords)
        {
            if (string.IsNullOrEmpty(boringWord))
                throw new ArgumentException("Каждое скучное слово должно быть непустой строкой и " +
                                            "не содержать спецсимволов и цифр");

            foreach (var c in boringWord)
                if (!char.IsLetter(c))
                    throw new ArgumentException("Каждое скучное слово должно быть непустой строкой и " +
                                                "не содержать спецсимволов и цифр");
        }
    }
}