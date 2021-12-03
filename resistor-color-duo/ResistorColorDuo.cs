using System;
using System.Linq;

public static class ResistorColorDuo
{
    public static int Value(string[] colors)
    {
        string[] resistorColors = new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

        var bands = colors.Take(2).Select(color => Array.IndexOf(resistorColors, color));
        var colorDuoParsed = Int32.TryParse(string.Join("", bands), out int duo);
        return duo;
    }
}
