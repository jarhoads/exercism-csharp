using System;

public static class ReverseString
{
    // I'm sure there are also better ways to do this but I don't remember
    // this a brute force version
    public static string Reverse(string input)
    {
        string reversed = "";
        for (int i=(input.Length-1); i>=0; i--) { reversed += input[i]; }

        return reversed;
    }
}