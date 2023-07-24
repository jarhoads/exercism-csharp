using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        // replace non-characters with spaces
        var words = phrase.Replace("-", " ")
                          .Replace(",", "")
                          .Replace("'", "")
                          .Replace("_", "");

        // generate the letters
        var letters = words.Split(" ")
                           .Where(word => !string.IsNullOrWhiteSpace(word))
                           .Select(word => word.Substring(0, 1).ToUpper());

        return string.Join("", letters);
        
    }
}