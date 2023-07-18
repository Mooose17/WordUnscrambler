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
    [Test]
    public void ScrambledWordMatchesGivenWordsInTheList()
    {
        string[] words = { "cat", "chair", "more" };
        string[] scrambledWords = { "omre", "act" };

        var matchedWords = _wordMatcher.Match(scrambledWords, words);
        
        Console.WriteLine(matchedWords);
        
        Assert.IsTrue(matchedWords.Count == 2);
        Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
        Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("act"));
        Assert.IsTrue(matchedWords[0].Word.Equals("more"));
        Assert.IsTrue(matchedWords[1].Word.Equals("cat"));
    }
}