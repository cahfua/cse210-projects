using System;
using System.IO;

public static class SessionLogger
{
    private const string LogFile = "mindfulness_log.txt";

    public static void Log(string activityName, int durationSeconds, string notes = null)
    {
        try
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{activityName}\t{durationSeconds}s\t{notes ?? ""}";
            File.AppendAllLines(LogFile, new[] { line });
        }
        catch
        {

        }
    }
}