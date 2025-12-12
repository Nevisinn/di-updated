namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IWordsHandler
{
    public List<string> Handle(List<string> words);
    IWordsHandler SetNext(IWordsHandler handler);
}