using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lowerLetters = string.Join("", word.ToLower().Where(char.IsLetter))
                                 .ToList();

        // I usually use sets for finding distinct/non-repeating elements 
        var chars = new HashSet<char>(lowerLetters);
        return lowerLetters.Count == chars.Count;
    }
}
