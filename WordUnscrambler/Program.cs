using System.Reflection.Metadata;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class WordUnscrambler
    {

        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        
        
        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine("Please enter option - F for file, M for Manual");
                    var option = Console.ReadLine() ?? String.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.EnterScrambledWordsOptionNotRecognised);
                            break;
                    }

                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? String.Empty);
                    

                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) && 
                             !continueDecision.Equals(Constants.No,StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }

            static void ExecuteScrambledWordsInFileScenario()
            {
                try
                {
                    var fileName = Console.ReadLine() ?? string.Empty;
                    string[] scrambledWords = _fileReader.Read(fileName);
                    DisplayMatchedUnscrambledWords(scrambledWords);
                }
                catch ( Exception ex)
                {
                    Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
                }
                
                
            }
            static void ExecuteScrambledWordsManualEntryScenario()
            {
                try
                {
                    var manualInput = Console.ReadLine() ?? string.Empty;
                    string[] scrambledWords = manualInput.Split(',');
                    DisplayMatchedUnscrambledWords(scrambledWords);
                }
                catch ( Exception ex)
                {
                    Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
                }
            }

            static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
            {
                string[] wordList = _fileReader.Read(Constants.WordListFileName);

                List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

                if (matchedWords.Any())
                {
                    foreach (var matchedWord in matchedWords)
                    {
                        Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word );
                    }
                }
                else
                {
                    Console.WriteLine(Constants.MatchNotFound);
                }
                
            }
        }
    }
}


