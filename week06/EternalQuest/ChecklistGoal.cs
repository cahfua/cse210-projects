public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount < 1 ? 1 : targetCount;
        _bonus = bonus < 0 ? 0 : bonus;
        _currentCount = 0;
        _isComplete = false;
    }

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonus, bool isComplete)
        : base(name, description, points)
    {
        _targetCount = targetCount < 1 ? 1 : targetCount;
        _currentCount = currentCount < 0 ? 0 : currentCount;
        _bonus = bonus < 0 ? 0 : bonus;
        _isComplete = isComplete;
    }

    public override void RecordEvent(GoalManager gm)
    {
        if (_isComplete)
        {
            gm.WriteLine("That checklist goal is already complete. No points awarded.");
            return;
        }

        gm.AddScore(GetPoints());
        _currentCount++;

        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            if (_bonus > 0)
            {
                gm.AddScore(_bonus);
                gm.WriteLine($"✓ Finished \"{GetName()}\"! Bonus +{_bonus} pts.");
            }
            else
            {
                gm.WriteLine($"✓ Finished \"{GetName()}\"!");
            }
        }
        else
        {
            gm.WriteLine($"Progress for \"{GetName()}\": {_currentCount}/{_targetCount}");
        }
    }

    public override bool IsComplete() => _isComplete;
    public override string GetDetailsString()
        => $"{GetName()} ({GetDescription()}) -- Progress: {_currentCount}/{_targetCount}";
    public override string GetStringRepresentation()
        => $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_currentCount}|{_bonus}|{_isComplete}";
}