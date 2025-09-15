using System;

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
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n✨ Writing Prompt: " + Utils.GetRandomPrompt());
                    Console.Write("Write your entry: ");
                    string content = Console.ReadLine();

                    Console.Write("How is your mood (1-10)? ");
                    int mood;
                    while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 10)
                    {
                        Console.Write("Invalid input. Enter a number between 1 and 10: ");
                    }

                    journal.AddEntry(content, mood);
                    break;

                case "2":
                    journal.ShowEntries();
                    break;

                case "3":
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