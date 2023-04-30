using Microsoft.AspNetCore.Mvc;
using WordCount.API.Services;

namespace WordCount.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordCountController : ControllerBase
{
    private readonly WordCounterService _wordCounterService;

    public WordCountController(WordCounterService wordCounterService)
    {
        _wordCounterService = wordCounterService;
    }

    [HttpPost(Name = "PostWords")]
    public async Task<WordCountResult> Post(IFormFile input)
    {
        using var streamReader = new StreamReader(input.OpenReadStream());
        var content = await streamReader.ReadToEndAsync();
        var result = _wordCounterService.CountWords(content);

        return new WordCountResult(result.Count, result.OrderByDescending(x => x.Value).Select(keyValue => new WordCount(keyValue.Key, keyValue.Value)));
    }
}

public record WordCount(string Word, int Count);
public record WordCountResult(int UniqueWords, IEnumerable<WordCount> WordCounts);