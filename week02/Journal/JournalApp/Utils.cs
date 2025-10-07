using System;
using System.Collections.Generic;

public static class Utils
{
    private static Random rand = new Random();

    private static List<string> prompts = new List<string>
    {
        "What was the best part of your day?",
        "What's something new you learned today?",
        "Write about something that made you smile.",
        "What challenge did you overcome today?",
        "Who is someone you're grateful for right now?",
        "What's one goal you have for tomorrow?"
    };

    public static string GetDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }

    public static string GetRandomPrompt()
    {
        int index = rand.Next(prompts.Count);
        return prompts[index];
    }

    public static string Escape(string value)
    {
        if (value == null) return "";
        return value.Replace("\\", "\\\\").Replace("|", "\\|");
    }

    public static string Unescape(string value)
    {
        if (value == null) return "";
        return value.Replace("\\|", "|").Replace("\\\\", "\\");
    }
}