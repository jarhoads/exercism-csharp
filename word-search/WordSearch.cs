using System;
using System.Collections.Generic;

public class WordSearch
{
    private readonly (int, int) DefaultValue = (0, 0);
    private readonly string[] rows;
    public WordSearch(string grid) => rows = grid.Split('\n');

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        return getWordsNew(wordsToSearchFor);
    }

    private Dictionary<string, ((int, int), (int, int))?> getWordsNew(string[] wordsToSearchFor)
    {
        var matches = new Dictionary<string, ((int, int), (int, int))?>();
        foreach (var word in wordsToSearchFor)
        {
            var beginLetter = word[0];
            var endLetter = word[word.Length - 1];

            var result = searchGrid(beginLetter, endLetter, word);

            if (result.Item1 == (0, 0) || result.Item2 == (0, 0))
            {
                // check reversed string
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                var wordReversed = new string(charArray);
                beginLetter = wordReversed[0];
                endLetter = wordReversed[wordReversed.Length - 1];

                var reverseResult = searchGrid(beginLetter, endLetter, wordReversed);
                result = (reverseResult.Item2, reverseResult.Item1);
            }

            addMatches(word, result, matches);
        }

        return matches;
    }

    private ((int, int), (int, int)) searchGrid(char beginLetter, char endLetter, string word)
    {
        (int beginX, int beginY) begin = (0, 0);
        (int endX, int endY) end = (0, 0);
        int currY = 1;
        foreach (var row in rows)
        {
            for (int i = 0; i < row.Length; i++)
            {
                var letter = row[i];
                if (letter == beginLetter)
                {

                    begin.beginX = (i+1);
                    begin.beginY = currY;
                    end = findEnd(endLetter, begin, word);
                    if (end != (0, 0)) { return (begin, end); }
                }
            }
            
            currY++;
        }
        
        return (begin, end);
    }

    private (int, int) findEnd(char endLetter, (int beginX, int beginY) begin, string word)
    {
        var totalCols = rows[0].Length;

        var horizontal = CheckHorizontal(begin, word, totalCols, endLetter);
        if (horizontal != DefaultValue) { return horizontal; }

        var vertical = CheckVertical(begin, word, totalCols, endLetter);
        if (vertical != DefaultValue) { return vertical; }

        var diagonalFwd = CheckDiagonalFwd(begin, word, totalCols, endLetter);
        if (diagonalFwd != DefaultValue) { return diagonalFwd; }

        var diagonalBkwd = CheckDiagonalBkwd(begin, word, totalCols, endLetter);
        if (diagonalBkwd != DefaultValue) { return diagonalBkwd; }

        return (0, 0);
    }

    private string EndLetter(int beginX, int endY)
    {
        var yRow = rows[endY - 1];
        var letter = yRow.Substring(beginX - 1, 1);

        return letter;
    }

    private (int, int) CheckHorizontal((int beginX, int beginY) begin, string word, int totalCols, char endLetter)
    {
        var endX = begin.beginX + word.Length - 1;
        var endY = begin.beginY;

        if (endX > totalCols) { return (0, 0); }
        var endGridLetter = EndLetter(endX, endY);

        if (endGridLetter == $"{endLetter}")
        {
            // check for matching word
            var checkWord = rows[endY - 1].Substring(begin.beginX - 1, word.Length);
            if (checkWord == word) { return (endX, endY); }
        }

        return (0, 0);
    }

    private (int, int) CheckVertical((int beginX, int beginY) begin, string word, int totalCols, char endLetter)
    {
        var beginRow = begin.beginY - 1;
        var endY = beginRow + word.Length;

        if (endY > rows.Length) { return (0, 0); }
        var endGridLetter = EndLetter(begin.beginX, endY);

        if (endGridLetter == $"{endLetter}")
        {
            // check for matching word
            var checkWord = "";
            for (int i = beginRow; i < endY; i++) {
                checkWord += rows[i].Substring((begin.beginX-1), 1);
            }
            if (checkWord == word) { return (begin.beginX, endY); }
        }

        return (0, 0);
    }

    private (int, int) CheckDiagonalFwd((int beginX, int beginY) begin, string word, int totalCols, char endLetter)
    {
        var endX = (begin.beginX - word.Length) + 1;
        var endY = begin.beginY + word.Length - 1;

        if (endX < 1 || endY > rows.Length || endY < 1) { return (0, 0); }
        var endGridLetter = EndLetter(endX, endY);

        if (endGridLetter == $"{endLetter}")
        {
            // check for matching word
            var checkWord = "";
            var totalLetters = word.Length;
            var wordX = begin.beginX - 1;
            var wordY = begin.beginY - 1;
            for (int i = 0; i < totalLetters; i++)
            {
                checkWord += rows[wordY].Substring(wordX, 1);
                wordX--;
                wordY++;
            }
            if (checkWord == word) { return (endX, endY); }
        }

        return (0, 0);
    }

    private (int, int) CheckDiagonalBkwd((int beginX, int beginY) begin, string word, int totalCols, char endLetter)
    {
        var endX = begin.beginX + word.Length - 1;
        var endY = begin.beginY + word.Length - 1;

        if (endX > totalCols || endY > rows.Length) { return (0, 0); }
        var endGridLetter = EndLetter(endX, endY);
        if (endGridLetter == $"{endLetter}")
        {
            var checkWord = "";
            var totalLetters = word.Length;
            var wordX = begin.beginX - 1;
            var wordY = begin.beginY - 1;
            for (int i = 0; i < totalLetters; i++)
            {
                checkWord += rows[wordY].Substring(wordX, 1);
                wordX++;
                wordY++;
            }
            if (checkWord == word) { return (endX, endY); }
        }
        return (0, 0);
    }




    private void addMatches(string item, ((int, int), (int, int)) result, Dictionary<string, ((int, int), (int, int))?> matches)
    {
        if (result.Item1 == DefaultValue || result.Item2 == DefaultValue)
        {
            if (!matches.ContainsKey(item)) { matches.Add(item, null); }
        }
        else
        {
            if (matches.ContainsKey(item)) { if (matches[item] == null) { matches[item] = result; } }
            else { matches.Add(item, result); }
        }
    }

}