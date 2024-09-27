class Program
{
    static void Main()
    {
        string[] languagesArray = ["EN", "IT"];
        string languagesString = string.Join("/", languagesArray);

        Console.WriteLine($"Hello! Choose a language -> {languagesString}");

        LanguageChoice language = GetLanguage(languagesString);
        Console.WriteLine($"Language chosen: {language}");

        Console.ReadKey();
    }

    static LanguageChoice GetLanguage(string languagesString)
    {
        LanguageChoice language = LanguageChoice.Default;
        string? languageText = string.Empty;
        do
        {
            languageText = Console.ReadLine();
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

    enum LanguageChoice
    {
        Default,
        EN,
        IT
    }
}
