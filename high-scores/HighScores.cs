using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _list;
    public HighScores(List<int> list)
    {
        _list = list;
    }

    public List<int> Scores()
    {
        return this._list;
    }

    public int Latest()
    {
        return this._list.Last();
    }

    public int PersonalBest()
    {
        return this._list.Max();
    }

    public List<int> PersonalTopThree()
    {
       return this._list.OrderByDescending(score => score).Take(3).ToList();
    }

}