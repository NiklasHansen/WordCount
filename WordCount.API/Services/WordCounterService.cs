namespace WordCount.API.Services;

public class WordCounterService
{
    public IReadOnlyDictionary<string, int> CountWords(string input)
    {
        var wordDict = new Dictionary<string, int>();

        var words = input.ToLower().Replace('.', ' ').Split(' ').Where(w => !string.IsNullOrWhiteSpace(w));
        foreach (var word in words)
        {
            var count = 0;
            if (wordDict.TryGetValue(word, out var oldCount))
            {
                count = oldCount;
            }

            count += 1;
            wordDict[word] = count;
        }

        return wordDict;
    }
}