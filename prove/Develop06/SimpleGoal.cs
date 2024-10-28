public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("Goal already completed");
            return;
        }

        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {GetPoints()} points");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"[{(_isComplete ? 'x' : ' ')}] {GetShortName()} ({GetDescription()})";
    }

    // Static factory method to create with completion status
    public static SimpleGoal CreateWithCompletionStatus(string shortName, string description, int points, bool isComplete)
    {
        SimpleGoal goal = new SimpleGoal(shortName, description, points);
        goal._isComplete = isComplete;
        return goal;
    }
}