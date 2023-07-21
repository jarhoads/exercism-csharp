using System;
using System.Collections.Generic;

// TODO: define the 'LogLevel' enum
enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    private static readonly Dictionary<string, LogLevel> LogNames = new Dictionary<string, LogLevel>()
    {
        {"TRC", LogLevel.Trace },
        {"DBG", LogLevel.Debug },
        {"INF", LogLevel.Info },
        {"WRN", LogLevel.Warning },
        {"ERR", LogLevel.Error },
        {"FTL", LogLevel.Fatal },
    };

    public static LogLevel ParseLogLevel(string logLine)
    {
        var tag = logLine.Substring(1, 3);
        return LogNames.ContainsKey(tag) ? LogNames[tag] : LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}
