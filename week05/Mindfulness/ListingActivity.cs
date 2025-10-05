using System;
using System.Collections.Generic;
using System.Linq;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Queue<string> _promptQueue;
    private readonly Random _rand = new();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _promptQueue = Shuffle(_prompts);
    }

    public override void Run()
    {
        Start();

        if (_promptQueue.Count == 0) _promptQueue = Shuffle(_prompts);
        string prompt = _promptQueue.Dequeue();

        Console.WriteLine("\nList items for the prompt:");
        Console.WriteLine($"  -> {prompt}");
        Countdown(5, "Begin listing in");

        var items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDurationSeconds());
        Console.WriteLine("\nType an item and press ENTER (keep going until time runs out):");

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} item(s).");
        End();
        SessionLogger.Log(GetName(), GetDurationSeconds(), notes: $"Items: {items.Count}; Prompt: {prompt}");
    }

    private Queue<T> Shuffle<T>(IEnumerable<T> src)
    {
        var list = src.ToList();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
        return new Queue<T>(list);
    }
}