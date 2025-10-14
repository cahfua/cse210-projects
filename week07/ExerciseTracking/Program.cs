using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class Program
    {
        public static void Main()
        {
            var activities = new List<Activity>
            {
                new RunningActivity(new DateTime(2025, 10, 03), 30, 3.0),
                new CyclingActivity(new DateTime(2025, 10, 05), 45, 16.0),
                new SwimmingActivity(new DateTime(2025, 10, 07), 40, 60)
            };

            foreach (var a in activities)
            {
                Console.WriteLine(a.GetSummary());
            }
        }
    }
}