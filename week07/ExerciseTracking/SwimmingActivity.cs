using System;

namespace ExerciseTracking
{
    public class SwimmingActivity : Activity
    {
        private int _laps;
        private const double MilesPerLap = 50.0 / 1000.0 * 0.62;
        public SwimmingActivity(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * MilesPerLap;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60.0;
        }

        public override double GetPace()
        {
            return Minutes / Math.Max(GetDistance(), 1e-9);
        }
    }
}