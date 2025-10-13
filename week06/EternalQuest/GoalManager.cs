using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private int _score = 0;
    private readonly List<Goal> _goals = new List<Goal>();
    private int GetLevel() => (_score / 1000) + 1;
    private int GetXpIntoLevel() => _score % 1000;
    private int GetXpToNextLevel() => 1000 - GetXpIntoLevel();

    public void WriteLine(string message) => Console.WriteLine(message);
    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points. Level: {GetLevel()}   (XP: {GetXpIntoLevel()}/{1000}, to next: {GetXpToNextLevel()})");
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void AddScore(int points)
    {
        if (points <= 0) return;
        int beforeLevel = GetLevel();
        _score += points;
        int afterLevel = GetLevel();
        if (afterLevel > beforeLevel)
        {
            Console.WriteLine($"🎉 Level Up! You reached Level {afterLevel}.");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = (Console.ReadLine() ?? "").Trim();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Short Description: ");
        string description = Console.ReadLine() ?? "";
        Console.Write("Points (int): ");
        int points = int.TryParse(Console.ReadLine(), out int p) ? p : 0;
        if (points < 0) points = 0;

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target count (int ≥ 1): ");
                int target = int.TryParse(Console.ReadLine(), out int t) ? t : 1;
                if (target < 1) target = 1;

                Console.Write("Bonus on completion (int ≥ 0): ");
                int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;
                if (bonus < 0) bonus = 0;

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Unknown goal type. No goal created.");
                break;
        }
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet.");
            return;
        }

        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal g = _goals[i];
            string check = g.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {check} {g.GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? (number): ");
        if (!int.TryParse(Console.ReadLine(), out int selection))
        {
            Console.WriteLine("Please enter a number.");
            return;
        }

        int idx = selection - 1;
        if (idx < 0 || idx >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        _goals[idx].RecordEvent(this);
    }

    public void SaveGoals()
    {
        Console.Write("Filename to save to: ");
        string path = Console.ReadLine() ?? "goals.txt";

        try
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(_score);

                foreach (Goal g in _goals)
                {
                    sw.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved to '{path}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Save failed: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Filename to load from: ");
        string path = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(path);
            if (lines.Length == 0)
            {
                Console.WriteLine("File was empty.");
                return;
            }

            string first = lines[0].Trim();
            if (first.Contains("|"))
            {
                string[] header = first.Split('|');
                _score = header.Length > 1 && int.TryParse(header[1], out int s) ? s : 0;
            }
            else
            {
                _score = int.TryParse(first, out int s) ? s : 0;
            }

            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                string type = parts[0];

                string name = parts.Length > 1 ? parts[1] : "";
                string desc = parts.Length > 2 ? parts[2] : "";
                int points = (parts.Length > 3 && int.TryParse(parts[3], out int pp)) ? pp : 0;

                switch (type)
                {
                    case "SimpleGoal":
                        {
                            bool isComplete = parts.Length > 4 && bool.TryParse(parts[4], out bool ic) ? ic : false;
                            _goals.Add(new SimpleGoal(name, desc, points, isComplete));
                            break;
                        }

                    case "EternalGoal":
                        {
                            int times = parts.Length > 4 && int.TryParse(parts[4], out int tr) ? tr : 0;
                            _goals.Add(new EternalGoal(name, desc, points, times));
                            break;
                        }

                    case "ChecklistGoal":
                        {
                            int target = parts.Length > 4 && int.TryParse(parts[4], out int t) ? t : 1;
                            int current = parts.Length > 5 && int.TryParse(parts[5], out int c) ? c : 0;
                            int bonus = parts.Length > 6 && int.TryParse(parts[6], out int b) ? b : 0;
                            bool isComplete = parts.Length > 7 && bool.TryParse(parts[7], out bool ic) ? ic : false;

                            _goals.Add(new ChecklistGoal(name, desc, points, target, current, bonus, isComplete));
                            break;
                        }
                }
            }

            Console.WriteLine($"Loaded from '{path}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load failed: {ex.Message}");
        }
    }
}