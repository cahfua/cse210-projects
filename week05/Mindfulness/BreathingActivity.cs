using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void Run()
    {
        Start();

        int total = GetDurationSeconds();
        int cycleIn = 4;
        int cycleOut = 4;

        DateTime end = DateTime.Now.AddSeconds(total);
        while (DateTime.Now < end)
        {
            Console.WriteLine("Breathe in...");
            Countdown(cycleIn, "In");
            ProgressBar(Math.Min(cycleIn, Math.Max(1, cycleIn)), grow: true);

            if (DateTime.Now >= end) break;

            Console.WriteLine("Breathe out...");
            Countdown(cycleOut, "Out");
            ProgressBar(Math.Min(cycleOut, Math.Max(1, cycleOut)), grow: false);
        }

        End();
        SessionLogger.Log(GetName(), GetDurationSeconds(), notes: $"Cycles ~ {total / (cycleIn + cycleOut)}");
    }
}