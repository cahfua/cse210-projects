using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;

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

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Mood}|{entry.Content}");
            }
        }
        Console.WriteLine($"📁 Journal save to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("⚠️ No saved journal file found.");
            return;
        }

        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 3)
            {
                string date = parts[0];
                int mood = int.Parse(parts[1]);
                string content = parts[2];

                Entry entry = new Entry(content, mood);
                entry.Date = date;
                Entries.Add(entry);
            }
        }
        Console.WriteLine($"📖 Journal loaded from {filename}");
    }
}