

namespace ScrambledWordConsoleApp
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Enter scrambledword(s) manualy or as a file: F - file/M - manual";
        public const string OptionsOnContinueTheProgram = "Would you like to continue";
        
        public const string EnterScrambledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrambledWordsManually = "Enter word(s) manually (separated by commas if multiple): ";
        
        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recognized.";
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was an error.";
        public const string ErrorProgramWillBeTerminated = "Program will be terminated";
        
        public const string MatchFound = "MATCH FOUND FOR {0}: {1}";
        public const string MatchNotFound = "NO MATCHES HAVE BEEN FOUND";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";
        public const string wordListFileName = "wordlist.txt";
    }
}
