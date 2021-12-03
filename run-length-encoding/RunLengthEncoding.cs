using System;

// I don't like the way I did this 
// and I plan on coming back to it
public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input.Length == 0) { return ""; }

        var prev = input[0];
        var run = 0;
        var result = "";

        for (int i=0; i<input.Length; i++)
        {
            if (prev == input[i]) { run++; }
            else 
            { 
                result += ResultUpdate(run, prev); 
                prev = input[i]; 
                run = 1;
            }
        }

        result += ResultUpdate(run, prev);

        return result;

    }

    public static string ResultUpdate(int run, char prev) => (run > 1) ? $"{run}{prev}" : $"{prev}";

    public static string Decode(string input)
    {
        if (input.Length == 0) { return ""; }

        var decoded = "";
        var num = "";
        for (int c=0; c<input.Length; c++)
        {
            if (Char.IsNumber(input[c]))
            {
                num += input[c].ToString();
            }
            else
            {
                if (num.Length == 0)
                {
                    decoded += input[c].ToString();
                }
                else
                {
                    decoded += BuildRun(num, input[c]);
                    num = "";
                }
            }
        }

        return decoded;
    }

    private static string BuildRun(string num, char c)
    {
        var run = "";
        if (int.TryParse(num, out int times))
        {
            for (int i=0; i<times; i++)
            {
                run += c.ToString();
            }
        }

        return run;
    }
}
