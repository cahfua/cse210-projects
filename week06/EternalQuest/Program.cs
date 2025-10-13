using System;
using System.Xml.Serialization;

/* Creativity:
* Program has a level system where the user can gain 1 level per 1000 points (Header will show your level and XP to the next level.)
* Optional seeding via seed for quick demo.
*/

class Program
{
    static void Main(string[] args)
    {
        PrintBanner();
        var manager = new GoalManager();
        if (args != null && Array.Exists(args, a => a.Equals("--seed", StringComparison.OrdinalIgnoreCase)))
        {
            SeedDemoData(manager);
            Console.WriteLine("Seeded demo goals. Type 2 to list them, or 5 to record an event.\n");
        }

        try
        {
            manager.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnexpected error: {ex.Message}");
            Console.WriteLine("Tip: Try saving your goals frequently with option 3.");
        }
    }

    private static void PrintBanner()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("      Eternal Quest (W06 CSE210)        ");
        Console.WriteLine("========================================\n");
        Console.WriteLine("Track Simple, Eternal, and Checklist goals.");
        Console.WriteLine("Earn points, level up, and save/load progress.\n");

    }

    private static void SeedDemoData(GoalManager gm)
    {
        Console.WriteLine("Seed helper: use menu 1 to create:");
        Console.WriteLine(" • Simple:  Name=Marathon, Desc=Run 26.2, Points=1000");
        Console.WriteLine(" • Eternal: Name=Scriptures, Desc=Daily reading, Points=100");
        Console.WriteLine(" • Checklist:  Name=Temple, Desc=Attend, Points=50, Target=10, Bonus=500\n");
    }
}