using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        var sides = TriangleSides(side1, side2, side3);
        var invalid = TriangleInValid(side1, side2, side3);
        return !(invalid) && !(sides.aEqb || sides.bEqc || sides.aEqc);
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        var sides = TriangleSides(side1, side2, side3);
        var invalid = TriangleInValid(side1, side2, side3);
        return !(invalid) && (sides.aEqb || sides.bEqc || sides.aEqc);
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        var sides = TriangleSides(side1, side2, side3);
        var invalid = TriangleInValid(side1, side2, side3);
        return !(invalid) && (sides.aEqb && sides.bEqc && sides.aEqc);
    }

    private static (bool aEqb, bool bEqc, bool aEqc) TriangleSides(double a, double b, double c)
    {
        return (a.CompareTo(b) == 0, b.CompareTo(c) == 0, a.CompareTo(c) == 0);
    }

    private static bool TriangleInValid(double a, double b, double c)
    {
        return (a == 0.0 || b == 0.0 || c == 0.0) ||
               (a >= b + c || b >= a + c || c >= a + b);
    }
}