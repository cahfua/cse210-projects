using System;
using System.Collections.Generic;
using System.Linq;

/* 
    In my program I have added 3 inteactive memorization modes the user will be able to choose from:

    1. Erase the verse: This will gradually hide random words each time the user presses Enter
    2. Verse puzzles: This will jumble the scripture verse and allow the user to practice by unscrambling the verse and placing it in the correct order
    3. Fill in the blanks: This will hide a few words at random
*/

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        Console.WriteLine("Choose a memorization method:");
        Console.WriteLine("1. Erase the verse");
        Console.WriteLine("2. Verse puzzles");
        Console.WriteLine("3. Fill in the blanks");
        Console.Write("Enter choice (1-3): ");
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            RunEraseTheVerse(scripture);
        }
        else if (choice == "2")
        {
            RunVersePuzzles(scripture);
        }
        else if (choice == "3")
        {
            RunFillInTheBlanks(scripture);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    static void RunEraseTheVerse(Scripture scripture)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string? input = Console.ReadLine();

            scripture.HideRandomWords(3);
            Console.Clear();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden. Program ended.");
                break;
            }
        }
    }

    static void RunVersePuzzles(Scripture scripture)
    {
        Console.Clear();
        List<Word> words = scripture.GetWords();
        List<string> scrambled = words.Select(w => w.GetActualText()).OrderBy(w => Guid.NewGuid()).ToList();

        Console.WriteLine("Scrambled verse:");
        Console.WriteLine(string.Join(" ", scrambled));
        Console.WriteLine("\nTry to put the verse back in order!");
        Console.WriteLine("Original verse:\n");
        Console.WriteLine(scripture.GetDisplayText());
    }

    static void RunFillInTheBlanks(Scripture scripture)
    {
        Console.Clear();
        List<Word> words = scripture.GetWords();
        Random rand = new Random();
        HashSet<int> blanks = new HashSet<int>();

        while (blanks.Count < 3)
        {
            blanks.Add(rand.Next(words.Count));
        }

        Console.WriteLine("Fill in the blanks exercise:");
        for (int i = 0; i < words.Count; i++)
        {
            if (blanks.Contains(i))
                Console.Write(new string('_', words[i].GetActualText().Length) + " ");
            else
                Console.Write(words[i].GetActualText() + " ");
        }

        Console.WriteLine("\n\nCan you recall the missing words?");
    }
}