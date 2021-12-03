using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{

    public static List<string> NewList() => new List<string>();

    public static List<string> GetExistingLanguages() => new List<string>() {"C#", "Clojure", "Elm"};

    public static List<string> AddLanguage(List<string> languages, string language) => languages.Concat(new[] {language}).ToList<string>();

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) => Enumerable.Reverse(languages).ToList<string>();

    public static bool IsExciting(List<string> languages) => languages.Count > 0 && 
                                                            (languages[0] == "C#" || 
                                                            (languages[1] == "C#" && (languages.Count == 2 || languages.Count == 3)));

    public static List<string> RemoveLanguage(List<string> languages, string language) => languages.Where(lang => lang != language).ToList<string>();

    public static bool IsUnique(List<string> languages) => languages.Select(lang => (lang, 1))
                                                                    .GroupBy(l => l.lang)
                                                                    .Where(g => g.Count() > 1)
                                                                    .Select(g => g.Key)
                                                                    .ToList<string>().Count == 0;
}
