using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {


        if (subjects.Length < 1) { return Array.Empty<string>(); }

        // I did this with both linq and a for loop, leaving the 
        // for loop as comments
        var recited = subjects.Select((subject, i) => Message(i, subjects));

        // for (int i=0; i<subjects.Length; i++)
        // {
        //     recited[i] = (i < (subjects.Length - 1)) ? $"For want of a {subjects[i]} the {subjects[i+1]} was lost." :
        //                                               $"And all for the want of a {subjects[0]}.";
        // }

        return recited.ToArray<string>();
    }

    public static string Message(int i, string[] subjects)
    {
        return (i < (subjects.Length - 1)) ? $"For want of a {subjects[i]} the {subjects[i+1]} was lost." : 
                                             $"And all for the want of a {subjects[0]}.";
    }
}