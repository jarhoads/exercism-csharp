using System;
using System.Collections.Generic;

public static class Rectangles
{
    private const char Corner = '+';
    private const char Side = '|';
    public static int Count(string[] rows)
    {

        if (rows.Length < 2) { return 0; }

        var corners = new List<(int, int)>();
        var sides = new List<(int, int)>();
        for (int row = 0; row < rows.Length; row++)
        {
            for (int i = 0; i < rows[row].Length; i++)
            {
                var c = rows[row][i];
                if (c == Corner) { corners.Add((row, i)); }
                if (c == Side) { sides.Add((row, i)); }
            }
        }

        // count corners with matching columns
        var rect = BuildTopsBottoms(corners);

        int rects = 0;
        for (int i=0; i<rect.Count; i++)
        {
            // check rows above to see if a matching pair of corners exists
            for (int j=(i+1); j<rect.Count; j++)
            {

                // left corner column matches right corner column
                var matchingCorners = (rect[i].Item1.Item2 == rect[j].Item1.Item2) &&
                                        (rect[i].Item2.Item2 == rect[j].Item2.Item2);

                int r1 = rect[i].Item1.Item1;
                int r2 = rect[j].Item2.Item1;
                int c1 = rect[i].Item1.Item2;
                int c2 = rect[i].Item2.Item2;

                var matchingSides = (sides.Contains(((r1+1), c1)) && sides.Contains(((r2+1), c2))) ||
                                    (AllSidesCorners(rows, r1, r2, c1, c2));
            

                if (matchingCorners && matchingSides) { rects++; }
            }
        }

        return rects;
    }

    public static List<((int, int), (int, int))> BuildTopsBottoms(List<(int, int)> corners)
    {
        var rect = new List<((int, int), (int, int))>();
        
        for (int i=0; i<corners.Count; i++)
        {
            // find another corner on the same row
            int r = corners[i].Item1;
            for (int j=(i+1); j<corners.Count; j++)
            {
                if (corners[j].Item1 == r) { 
                    rect.Add((corners[i], corners[j]));
                }


            }
        }

        return rect;
    }

    public static bool AllSidesCorners(string[] map, int r1, int r2, int c1, int c2)
    {
        char Corner = '+';
        char Side = '|';
        // check to see if everything between (r1,c1) and (r2,c2) is
        // either a corner or side
        for (int i=(r1+1); i<r2; i++)
        {
            var c1Char = map[i][c1];
            var c2Char = map[i][c2];
            var bothSidesSideCorner = (c1Char == Corner || c1Char == Side) && (c2Char == Corner || c2Char == Side);
            if (!bothSidesSideCorner) { return false; }
        }
        return true;
    }
}