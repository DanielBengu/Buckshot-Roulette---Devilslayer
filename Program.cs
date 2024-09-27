using Buckshot_Roulette_Devilslayer.Language;

namespace Buckshot_Roulette_Devilslayer.Main
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Buckshot Roulette - Devil Slayer";
            string[] languagesArray = ["EN", "IT"];
            string languagesString = string.Join("/", languagesArray);

            Console.WriteLine($"Hello! Choose a language -> {languagesString}");

            LanguageChoice language = LanguageService.GetLanguage(languagesString);
            Dictionary<string, string>? _textDict = LanguageService.GetTextDictionary(language);
            if( _textDict == null) 
            {
                Console.WriteLine("Unknown error during language setting, please restart and choose another language");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Language chosen: {language}");
            Console.WriteLine(_textDict[TextOptions.Intro.ToString()]);
            Console.WriteLine(_textDict[TextOptions.LineBracket.ToString()]);

            HandleGame(_textDict);

            Console.WriteLine(_textDict[TextOptions.ThankAndLeave.ToString()]);
            Console.ReadKey();
        }

        static void HandleGame(Dictionary<string, string> _textDict)
        {
            bool keepPlaying = true;

            while(keepPlaying)
            {
                Console.WriteLine(_textDict[TextOptions.ChooseOption.ToString()]);
                keepPlaying = false;
            }
        }
    }
}