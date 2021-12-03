using System;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    static readonly List<int> numbers = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 
                                 10, 20, 30, 40, 50, 60, 70, 80, 90,
                                 100, 200, 300, 400, 500, 600, 700, 800, 900,
                                 1000, 2000, 3000};

    static readonly List<string> romans = new List<string> {"", "I", "II", "III", "IV", "V",
                                                      "VI", "VII", "VIII", "IX", "X", 
                                                      "XX", "XXX", "XL", "L", "LX", "LXX",
                                                      "LXXX", "XC", "C","CC","CCC", "CD", 
                                                      "D", "DC", "DCC", "DCCC", "CM",
                                                      "M", "MM", "MMM"};

    static readonly Dictionary<int, string> romanNumbers = new Dictionary<int, string>();

    // build a dictionary to look up roman numeral based on integer
    static RomanNumeralExtension() =>
        numbers.Zip(romans)
               .ToList()
               .ForEach(romanPair => romanNumbers.Add(romanPair.First, romanPair.Second));
    
    public static string ToRoman(this int value)
    {
        return Convert(value);
    }

    private static string Convert(int n){
        
        if(n >= 1000){ return romanNumbers[(int)(1000 * (n / 1000))] + Convert(n % 1000);}
        else if(n >= 100){ return romanNumbers[(int)(100 * (n / 100))] + Convert(n % 100);}
        else if(n >= 10){ return romanNumbers[(int)(10 * (n / 10))] + Convert(n % 10);}
        else if(n > 0){ return romanNumbers[(int)(n)]; }
        else{ return ""; }
    }
}