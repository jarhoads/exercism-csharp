using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int _mask;
    private readonly List<Allergen> _list;

    public Allergies(int mask)
    {
        _mask = mask;
        _list = Enumerable.Range(0, 8)
                          .Where(i => (mask & Convert.ToInt32(Math.Pow(2.0, i))) > 0)
                          .Select(idx => (Allergen)idx)
                          .ToList<Allergen>();
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return _list.Contains(allergen);
    }

    public Allergen[] List()
    {
        return this._list.ToArray();   
    }
}