namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IWordsHandler
{
    public IWordsHandler? NextHandler { get; set; }
    public List<string> Handle(List<string> words);
}