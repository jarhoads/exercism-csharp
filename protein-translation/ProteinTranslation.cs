using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{

    public static string[] Proteins(string strand)
    {
        var codonProteins = new Dictionary<string, string>()
        {
            ["AUG"] = "Methionine",
            ["UUU"] = "Phenylalanine",
            ["UUC"] = "Phenylalanine",
            ["UUA"] = "Leucine",
            ["UUG"] = "Leucine",
            ["UCU"] = "Serine",
            ["UCC"] = "Serine",
            ["UCA"] = "Serine",
            ["UCG"] = "Serine",
            ["UAU"] = "Tyrosine",
            ["UAC"] = "Tyrosine",
            ["UGU"] = "Cysteine",
            ["UGC"] = "Cysteine",
            ["UGG"] = "Tryptophan",
            ["UAA"] = "STOP",
            ["UAG"] = "STOP",
            ["UGA"] = "STOP"
        };
        
        const int CodonSize = 3;

        var proteins = String.Join(',', Codons(strand, CodonSize).Select(codon => codonProteins[codon]));

        var stop = proteins.IndexOf("STOP");
        
        if (stop > -1) { proteins = (stop == 0) ? "" : proteins.Substring(0, (stop - 1)); }
        
        return (proteins.Length == 0) ? Array.Empty<string>() : proteins.Split(',');
    }

    public static IEnumerable<string> Codons(string str, int codonSize) 
    {
        for (int i = 0; i < str.Length; i += codonSize) 
        {
            yield return str.Substring(i, Math.Min(codonSize, str.Length-i));
        }
    }
}