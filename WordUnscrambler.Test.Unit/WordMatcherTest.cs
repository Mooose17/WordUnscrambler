namespace WordUnscrambler.Test.Unit;

public class WordMatcherTest
{

    private readonly WordMatcher _wordMatcher = new WordMatcher();
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ScrambledWordMatchesGivenWordInTheList()
    {
        string[] words = { "cat", "chair", "more" };
        string[] scrambledWords = { "omre" };

        var matchedWords = _wordMatcher.Match(scrambledWords, words);
        
        Console.WriteLine(matchedWords);
        
        Assert.IsTrue(matchedWords.Count == 1);
        Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
        Assert.IsTrue(matchedWords[0].Word.Equals("more"));
    }
}