namespace TagsCloud.App.Abstractions.WordsProcessing;

public interface IWordsPreprocessor
{
    public List<string> Process(List<string> words);
}