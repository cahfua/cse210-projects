using System;
using System.Collections.Generic;

public class JournalEntry
{
    private List<Entry> Entries { get; set; } = new List<Entry>();
    public void AddEntry(string content, int mood)
    {
        var entry = new Entry(content, mood);
        Entries.Add(entry);
        Console.WriteLine("✅ Entry added!");
    }

    public void ShowEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine("-----------------------");
        }
    }
}