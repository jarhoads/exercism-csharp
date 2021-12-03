using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        return FindIndex(input, value, 0, input.Length - 1);
    }

    public static int FindIndex(int[] input, int value, int low, int hi)
    {
        if (hi < low ) { return -1; }

        int mid = (hi + low) / 2;

        if (value > input[mid]) { return FindIndex(input, value, mid + 1, hi); }
        else if (value < input[mid]) { return FindIndex(input, value, low, mid - 1); }
        else { return mid; }

    }
}