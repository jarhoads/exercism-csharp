using System;
using System.Collections.Generic;
using System.Text;

public static class Identifier
{
    public static readonly List<char> controls = new List<char>() { '\0', '\t', '\n' };
    public static readonly List<char> greeks = new List<char>() { '\u03B1', '\u03B2', '\u03B3', '\u03B4', '\u03B5', '\u03B6', '\u03B7', '\u03B8', '\u03B9', '\u03BA', '\u03BB', '\u03BC', '\u03BD', '\u03BE', '\u03BF', '\u03C0', '\u03C1', '\u03C2', '\u03C3', '\u03C4', '\u03C5', '\u03C6', '\u03C7', '\u03C8', '\u03C9' };
    
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier)) {  return string.Empty; }
        
        StringBuilder clean = new StringBuilder();
        bool kebab = false;

        for (int i=0; i<identifier.Length; i++)
        {
            if (identifier[i] == ' ') { clean.Append('_'); }
            else if (controls.Contains(identifier[i])) { clean.Append("CTRL"); }
            else if (identifier[i] == '-') { kebab = true; }
            else if (kebab) { kebab = false; clean.Append(identifier[i].ToString().ToUpper()); }
            else if (greeks.Contains(identifier[i])) { clean.Append(""); }
            else if (Char.IsDigit(identifier[i])) { clean.Append(""); }
            else if (!Char.IsLetter(identifier[i])) { clean.Append(""); }
            else { clean.Append(identifier[i]); }
        }
        return clean.ToString();
    }
}
