using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience for other situations?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Queue<string> _promptQueue;
    private Queue<string> _questionQueue;
    private readonly Random _rand = new();

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _promptQueue = MakeShuffledQueue(_prompts);
        _questionQueue = MakeShuffledQueue(_questions);
    }

    public override void Run()
    {
        Start();

        if (_promptQueue.Count == 0) _promptQueue = MakeShuffledQueue(_prompts);
        string prompt = _promptQueue.Dequeue();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"  -> {prompt}");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions...");
        Countdown(3, "First question in");

        DateTime end = DateTime.Now.AddSeconds(GetDurationSeconds());
        int asked = 0;

        while (DateTime.Now < end)
        {
            if (_questionQueue.Count == 0) _questionQueue = MakeShuffledQueue(_questions);
            string q = _questionQueue.Dequeue();
            Console.WriteLine($"> {q}");
            PauseWithSpinner(6);
            asked++;
        }

        End();
        SessionLogger.Log(GetName(), GetDurationSeconds(), notes: $"Questions: {asked}; Prompt: {prompt}");
    }

    private Queue<T> MakeShuffledQueue<T>(IEnumerable<T> source)
    {
        var list = source.ToList();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
        return new Queue<T>(list);
    }
}