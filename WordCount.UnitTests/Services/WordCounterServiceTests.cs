using WordCount.API.Services;

namespace WordCount.UnitTests.Services;

public class WordCounterServiceTests
{
    [Fact]
    public void CountWords_RunForrestRun_Expect2Words()
    {
        // Arrange
        const string input = "Run Forrest Run";
        var target = new WordCounterService();

        // Act
        var actual = target.CountWords(input);

        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal(2, actual["run"]);
        Assert.Equal(1, actual["forrest"]);
    }

    [Fact]
    public void CountWords_RunForrestRun_IgnorePunctuation()
    {
        // Arrange
        const string input = "Run Forrest. Run";
        var target = new WordCounterService();

        // Act
        var actual = target.CountWords(input);

        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal(2, actual["run"]);
        Assert.Equal(1, actual["forrest"]);
    }

    [Fact]
    public void CountWords_RunForrestRun_IgnoreCasing()
    {
        // Arrange
        const string input = "Run Forrest run";
        var target = new WordCounterService();

        // Act
        var actual = target.CountWords(input);

        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal(2, actual["run"]);
        Assert.Equal(1, actual["forrest"]);
    }

    [Fact]
    public void CountWords_RunForrestRun_IgnoreWhitespace()
    {
        // Arrange
        const string input = "Run  Forrest     Run";
        var target = new WordCounterService();

        // Act
        var actual = target.CountWords(input);

        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal(2, actual["run"]);
        Assert.Equal(1, actual["forrest"]);
    }

    [Fact]
    public void CountWords_EmptyString_Expect0Words()
    {
        // Arrange
        const string input = "";
        var target = new WordCounterService();

        // Act
        var actual = target.CountWords(input);

        // Assert
        Assert.Equal(0, actual.Count);
    }
}