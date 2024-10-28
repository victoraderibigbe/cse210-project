public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"You have completed {_amountCompleted}/{_target}.");

        if (_amountCompleted >= _target)
        {
            AddPoints(_bonus);
            Console.WriteLine($"Congratulations! You have earned {_bonus} bonus!");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{GetShortName()}: {GetDescription()} - {_amountCompleted}/{_target} completed, {_bonus} bonus points";
    }

    public override string GetStringRepresentation()
    {
        return $"[{(_amountCompleted >= _target ? 'x' : ' ')}] {GetShortName()} ({GetDescription()}) -- Currently Completed: ({_amountCompleted}/{_target})";
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    // Factory method to create ChecklistGoal with initial amount completed
    public static ChecklistGoal CreateWithAmountCompleted(string shortName, string description, int points, int target, int bonus, int amountCompleted)
    {
        var goal = new ChecklistGoal(shortName, description, points, target, bonus);
        goal._amountCompleted = amountCompleted; // Set the private field directly
        return goal;
    }
}