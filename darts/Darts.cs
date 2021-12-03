using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        const double Outter = 10.0;
        const double Middle = 5.0;
        const double Inner = 1.0;

        // get distance
        var dist = Distance(x, y);

        // compare to outter
        var outterRes = dist.CompareTo(Outter);
        if (outterRes > 0) 
        { 
            // distance > outter circle -> 0 points
            return 0; 
        } 
        else if (outterRes < 0) 
        { 
            // distance within outter ring -> check middle and inner rings
            var midRes = dist.CompareTo(Middle);
            if (midRes > 0)
            {
                // between middle - outter rings -> 1 point
                return 1;
            }
            else if (midRes < 0)
            {
                // distance within middle ring -> check inner ring
                var innerRes = dist.CompareTo(Inner);
                if (innerRes > 0)
                {
                    // between inner and middle rings -> 5 points
                    return 5;
                }
                else if (innerRes < 0)
                {
                    // within inner circle -> 10 points
                    return 10;
                }
                else if (innerRes == 0)
                {
                    return 10;
                }
            }
            else if (midRes == 0)
            {
                // on the middle line
                return 5;
            }

        }
        else if (outterRes == 0)
        {
            return 1;
        }

        return 0;

    }

    static double Distance(double x, double y) => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
}
