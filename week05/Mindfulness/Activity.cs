using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetDurationSeconds() => _durationSeconds;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {GetName()} ---");
        Console.WriteLine(GetDescription());
        Console.Write("\nEnter duration (seconds): ");
        var raw = Console.ReadLine();
        if (!int.TryParse(raw, out _durationSeconds) || _durationSeconds <= 0)
        {
            _durationSeconds = 30;
            Console.WriteLine("Invalid input. Using default: 30 seconds.");
        }

        Console.WriteLine("\nGet ready to begin...");
        PauseWithSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nGreat job! Wrapping up...");
        PauseWithSpinner(2);
        Console.WriteLine($"You completed the {GetName()} for {GetDurationSeconds()} seconds.");
        PauseWithSpinner(2);
    }

    protected void PauseWithSpinner(int seconds)
    {
        char[] frames = new[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            System.Threading.Thread.Sleep(120);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void Countdown(int seconds, string label = "Starting in")
    {
        for (int s = seconds; s > 0; s--)
        {
            Console.Write($"\r{label}: {s}  ");
            Thread.Sleep(1000);
        }
        Console.Write("\r                  \r");
    }

    protected void ProgressBar(int seconds, bool grow = true)
    {
        int width = 20;
        int stepDelayMs = (int)Math.Max(50, (seconds * 1000.0 / width));
        int from = grow ? 0 : width;
        int to = grow ? width : 0;
        int dir = grow ? 1 : -1;

        for (int i = from; grow ? i <= to : i >= to; i += dir)
        {
            string bar = new string('=', Math.Max(0, i)).PadRight(width, ' ');
            Console.Write($"\r[{bar}]");
            Thread.Sleep(stepDelayMs);
        }
        Console.Write("\r" + new string(' ', width + 2) + "\r");
    }

    public abstract void Run();
}