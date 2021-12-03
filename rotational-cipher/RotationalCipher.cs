using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        return String.Join("", text.Select(c => ShiftLetter(c, shiftKey)).ToArray());
    }

    static char ShiftLetter(char c, int dist)
    {

        if (!IsLowerLetter(c) && !IsUpperLetter(c)) { return c; }

        int zVal = IsUpperLetter(c) ? (int)'Z' : (int)'z';
        int cVal = (int)c;

        // check to see if cVal + dist > zVal
        if ((cVal + dist) > zVal)
        {
            // find distance from character to z
            int zDist = zVal - cVal;

            // subtract zDist from dist to get dist from a
            // subtract 1 for the letter a itself
            int aDist = (dist - zDist) - 1;

            char aVal = IsUpperLetter(c) ? 'A' : 'a';
            return (char)(aVal + aDist);
        }
        else
        {
            return (char)(c + dist);
        }

    }

    static bool IsLetter(char c)
    {
        return IsLowerLetter(c) || IsUpperLetter(c);
    }

    static bool IsLowerLetter(char c)
    {
        return (int)c >= (int)'a' && (int)c <= (int)'z';
    }

    static bool IsUpperLetter(char c)
    {
        return (int)c >= (int)'A' && (int)c <= (int)'Z';
    }
}