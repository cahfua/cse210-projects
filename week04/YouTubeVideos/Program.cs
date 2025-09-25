using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    internal class Program
    {
        private const string HeaderTitle = "Youtube Video Tracker (Week 04: Abstraction)";
        private static readonly ConsoleColor HeaderColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor TitleColor = ConsoleColor.Yellow;
        private static readonly ConsoleColor NameColor = ConsoleColor.Green;

        private static void Main()
        {
            DrawHeader(HeaderTitle);

            var videos = new List<Video>();

            var video1 = new Video("Exploring the Grand Canyon", "TrailBlazer", 582);
            video1.AddComment(new Comment("Alex P.", "Loved the drone shots!"));
            video1.AddComment(new Comment("Sam", "What camera did you use?"));
            video1.AddComment(new Comment("Jess", "This made me want to visit."));
            videos.Add(video1);

            var video2 = new Video("Intro to C# Classes and Objects", "CodeCraft", 735);
            video2.AddComment(new Comment("Taylor", "Finally clicked-thanks!"));
            video2.AddComment(new Comment("Morgan", "Could you cover interfaces next?"));
            video2.AddComment(new Comment("Riley", "Clear explanation and examples"));
            video2.AddComment(new Comment("Lee", "The UML diagram helped a ton."));
            videos.Add(video2);

            var video3 = new Video("Best Budget Laptops in 2025", "TechTinker", 496);
            video3.AddComment(new Comment("Jordan", "Got the second one-no regrets."));
            video3.AddComment(new Comment("Casey", "Please add Linux compatibility!"));
            video3.AddComment(new Comment("Pat", "Benchmark graphs were super useful."));
            videos.Add(video3);

            foreach (var v in videos)
            {
                WriteVideoBlock(v);
            }
        }

        private static void DrawHeader(string text)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine(new string('=', text.Length));
            Console.WriteLine(text);
            Console.WriteLine(new string('=', text.Length));
            Console.ForegroundColor = prev;
            Console.WriteLine();
        }

        private static void WriteVideoBlock(Video video)
        {
            var prev = Console.ForegroundColor;

            Console.ForegroundColor = TitleColor;
            Console.WriteLine(video.Title);
            Console.ForegroundColor = prev;

            Console.WriteLine($"   Author: {video.Author}");
            Console.WriteLine($"  Length: {FormatSeconds(video.LengthInSeconds)}");
            Console.WriteLine($"  Comments: {video.GetCommentCount()}");

            Console.WriteLine("  --- Comments ---");
            foreach (var c in video.GetComments())
            {
                Console.ForegroundColor = NameColor;
                Console.Write($"  {c.CommenterName}: ");
                Console.ForegroundColor = prev;
                Console.WriteLine($"{c.Text}");
            }

            Console.WriteLine();
        }

        private static string FormatSeconds(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }
    }
}