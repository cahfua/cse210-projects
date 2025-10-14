using System;

namespace ExerciseTracking
{
    public class CyclingActivity : Activity
    {
        private double _speedMph;

        public CyclingActivity(DateTime date, int minutes, double speedMph)
            : base(date, minutes)
        {
            _speedMph = speedMph;
        }

        public override double GetDistance()
        {
            return _speedMph * (Minutes / 60.0);
        }

        public override double GetSpeed() => _speedMph;
        public override double GetPace()
        {
            return 60.0 / Math.Max(_speedMph, 1e-9);
        }
    }
}