using System.Text.Json;

namespace Buckshot_Roulette_Devilslayer.Language
{
    public static class LanguageService
    {
        public static LanguageChoice GetLanguage(string languagesString)
        {
            LanguageChoice language = LanguageChoice.Default;
            do
            {
                string? languageText = Console.ReadLine();
                if (string.IsNullOrEmpty(languageText))
                {
                    Console.WriteLine($"Please choose a language -> {languagesString}");
                    continue;
                }

                if (!Enum.TryParse(languageText, out language))
                {
                    Console.WriteLine($"Invalid language, please choose from -> {languagesString}");
                }

            } while (language == LanguageChoice.Default);

            return language;
        }

        public static Dictionary<string, string>? GetTextDictionary(LanguageChoice language)
        {
            string languageFile = $"{language}.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Text", languageFile);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The language file '{filePath}' was not found.");
                return null;
            }

            string jsonContent = File.ReadAllText(filePath);
            var textOptions = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            // Return the text for the selected option
            return textOptions;
        }
    }

    public enum TextOptions{
        Intro,
        LineBracket,
        ThankAndLeave,
        ChooseOption
    }
    public enum LanguageChoice
    {
        Default,
        EN,
        IT
    }
}
