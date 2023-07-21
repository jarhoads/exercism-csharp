using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    public const string letters = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input) => letters.All(input.ToLower().Contains);
    
}
