using System;

static class LogLine
{
    const string ErrorMessage = "[ERROR]:";
    const string WarningMessage = "[WARNING]:";
    const string InfoMessage = "[INFO]:";
    public static string Message(string logLine)
    {
        if (logLine.StartsWith(ErrorMessage))
        {
            return MessageValue(logLine, ErrorMessage);
        }
        else if (logLine.StartsWith(WarningMessage))
        {
            return MessageValue(logLine, WarningMessage);
        }
        else
        {
            return MessageValue(logLine, InfoMessage);
        }
    }

    public static string LogLevel(string logLine)
    {
        if (logLine.StartsWith(ErrorMessage))
        {
            return "error";
        }
        else if (logLine.StartsWith(WarningMessage))
        {
            return "warning";
        }
        else
        {
            return "info";
        }
    }

    public static string Reformat(string logLine)
    {
        if (logLine.StartsWith(ErrorMessage))
        {
            return $"{MessageValue(logLine, ErrorMessage)} (error)";
        }
        else if (logLine.StartsWith(WarningMessage))
        {
            return $"{MessageValue(logLine, WarningMessage)} (warning)";
        }
        else
        {
            return $"{MessageValue(logLine, InfoMessage)} (info)";
        }
    }

    public static string MessageValue(string line, string messsageType) => 
        (line.Length > messsageType.Length) ? line.Substring(messsageType.Length + 1).Trim() : "";
}
