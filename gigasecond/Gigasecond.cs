using System;

public static class Gigasecond
{
    private const long GigaSecondSeconds = 1000000000L;
    public static DateTime Add(DateTime moment) => moment.AddSeconds(GigaSecondSeconds);
    
}