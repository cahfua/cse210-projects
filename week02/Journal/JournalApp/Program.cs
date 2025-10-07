using System;

/*
There are four creative features I added:
1. Random writing prompts are displayed when adding an entry.
2. A mood tracker (1-10) is included for each entry.
3. Stats view: total entries, average mood, best/worst mood,entries by date.
4. Robust Save/Load with safe escaping for delimiters.
 */

class Program
{
    static void Main()
    {
        JournalEntry journal = new JournalEntry();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. View Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Stats");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = Utils.GetRandomPrompt();
                    Console.WriteLine("\n✨ Writing Prompt: " + prompt);
                    Console.Write("Write your entry: ");
                    string content = Console.ReadLine();

                    Console.Write("How is your mood (1-10)? ");
                    int mood;
                    while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 10)
                    {
                        Console.Write("Invalid input. Enter a number between 1 and 10: ");
                    }

                    journal.AddEntry(content, mood, prompt);
                    break;

                case "2":
                    journal.ShowEntries();
                    break;

                case "3": // ADDED: Save
                    Console.Write("Filename to save (e.g., journal.txt): ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "4": // ADDED: Load
                    Console.Write("Filename to load (e.g., journal.txt): ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "5": // ADDED: Stats
                    journal.ShowStats();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}