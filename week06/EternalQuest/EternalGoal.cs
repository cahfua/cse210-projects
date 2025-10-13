public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public EternalGoal(string name, string description, int points, int timesRecorded)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded < 0 ? 0 : timesRecorded;
    }

    public override void RecordEvent(GoalManager gm)
    {
        gm.AddScore(GetPoints());
        _timesRecorded++;
        gm.WriteLine($"+{GetPoints()} pts recorded for \"{GetName()}\" (eternal).");
    }

    public override string GetStringRepresentation()
        => $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_timesRecorded}";
}