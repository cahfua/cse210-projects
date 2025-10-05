using System;

/// Creativity: session log -> 'mindfulness_log.txt' (timestamp, activity, duration).
/// No-repeat randomization of prompts/questions per session, then reshuffle.
/// Breathing progress bar (grow/shrink) alongside countdown/spinner.

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflecting Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("0) Quit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                "0" => null,
                _ => null
            };

            if (choice == "0") break;

            if (activity == null)
            {
                Console.WriteLine("Invalid choice. Press ENTER to continue...");
                Console.ReadLine();
                continue;
            }

            activity.Run();

            Console.WriteLine("\nPress ENTER to return to the menu...");
            Console.ReadLine();
        }

        Console.WriteLine("Goodbye!");
    }
}