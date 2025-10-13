public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent(GoalManager gm)
    {
        if (_isComplete)
        {
            gm.WriteLine("That simple goal is already complete. No points awarded.");
            return;
        }

        gm.AddScore(GetPoints());
        _isComplete = true;
        gm.WriteLine($"✓ Completed \"{GetName()}\" (+{GetPoints()} pts).");
    }

    public override bool IsComplete() => _isComplete;
    public override string GetStringRepresentation()
        => $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
}