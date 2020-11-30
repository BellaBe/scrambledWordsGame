using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrambledWordConsoleApp
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        
        static void Main(string[] args)
        {
            try
            {
                bool continueGame = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambleWordsFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambleWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;
                    }
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinueTheProgram);
                        continueDecision = Console.ReadLine() ?? string.Empty;
                    } while (
                    !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueGame = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                
                } while (continueGame);
            }
            catch (Exception ex)
            {

                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }            
        }

        private static void ExecuteScrambleWordsManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambleWords);
        }

        private static void ExecuteScrambleWordsFileScenario()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambleWords = fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambleWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            string[] wordList = fileReader.Read(Constants.wordListFileName);
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambleWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else{
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
