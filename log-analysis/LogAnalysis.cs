using System;

public static class LogAnalysis 
{
    const string ErrorMessage = "[ERROR]:";
    const string WarningMessage = "[WARNING]:";
    const string InfoMessage = "[INFO]:";
    
    public static string SubstringAfter(this string str, string after)
    {
        int afterIdx = str.IndexOf(after);
        return str.Substring(afterIdx + after.Length);
    }

    public static string SubstringBetween(this string str, string begin, string end)
    {
        int beginIdx = str.IndexOf(begin) + begin.Length;
        int endIdx = str.IndexOf(end);
        int betweenLength = (endIdx - beginIdx);

        return str.Substring(beginIdx, betweenLength);
    }

    public static string Message(this string str)
    {

        if (str.StartsWith(ErrorMessage))
        {
            return MessageValue(str, ErrorMessage);
        }
        else if (str.StartsWith(WarningMessage))
        {
            return MessageValue(str, WarningMessage);
        }
        else
        {
            return MessageValue(str, InfoMessage);
        }
    }

    public static string MessageValue(string line, string messsageType) => 
        (line.Length > messsageType.Length) ? line.Substring(messsageType.Length + 1).Trim() : "";

    public static string LogLevel(this string str)
    {
        if (str.StartsWith(ErrorMessage))
        {
            return "ERROR";
        }
        else if (str.StartsWith(WarningMessage))
        {
            return "WARNING";
        }
        else
        {
            return "INFO";
        }
    }
}