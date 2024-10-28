public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    private int _currentLevel = 1;

    private int _pointsToNextLevel = 100; // Points required for Level 1

    private Dictionary<int, int> _levelThresholds = new Dictionary<int, int>
    {
        {1, 100},
        {2, 250},
        {3, 500},
        {4, 1000},
    };

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points");
            Console.WriteLine($"Your current level is: {_currentLevel}");
            Console.WriteLine($"You have {_pointsToNextLevel - _score} points to next level");

            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    CheckLevelUp(); // Check for level-up after recording event
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(1000);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }
    }

    public void CreateGoal()
    {
        Console.Write("The Types of Goals are:");
        Console.WriteLine("\n 1. Simple Goal \n 2. Eternal Goal \n 3. Checklist Goal");
        Console.Write("Which type of Goal would you like to create? ");
        int goalType = Convert.ToInt32(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int target = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = Convert.ToInt32(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int goalIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex <= _goals.Count)
        {
            _goals[goalIndex].RecordEvent();
            _score += _goals[goalIndex].GetPoints();
            Console.WriteLine($"You now have {_score} points");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(filename))
        {
            // Write the player's score, level, and points to the next level at the top
            sw.WriteLine(_score);
            sw.WriteLine(_currentLevel); // Save the current level
            sw.WriteLine(_pointsToNextLevel); // Save points required for the next level

            // Write each goal in the specified format
            foreach (Goal goal in _goals)
            {
                string goalType = goal.GetType().Name;
                string details;

                if (goal is SimpleGoal simpleGoal)
                {
                    details = $"{goalType}:{simpleGoal.GetShortName()},{simpleGoal.GetDescription()},{simpleGoal.GetPoints()},{simpleGoal.IsComplete()}";
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    details = $"{goalType}:{eternalGoal.GetShortName()},{eternalGoal.GetDescription()},{eternalGoal.GetPoints()}";
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    details = $"{goalType}:{checklistGoal.GetShortName()},{checklistGoal.GetDescription()},{checklistGoal.GetPoints()},{checklistGoal.GetBonus()},{checklistGoal.GetTarget()},{checklistGoal.GetAmountCompleted()}";
                }
                else
                {
                    continue; // Skip unknown goal types
                }

                sw.WriteLine(details);
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }


    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        // First line contains the score
        _score = int.Parse(lines[0]);

        // Second line contains the current level
        _currentLevel = int.Parse(lines[1]);

        // Third line contains the points required for the next level
        _pointsToNextLevel = int.Parse(lines[2]);

        // Clear existing goals before loading
        _goals.Clear();

        // Iterate over each goal line (skip the first three lines with score, level, and points to next level)
        for (int i = 3; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");

            if (parts.Length < 2) continue; // Skip if the format is invalid

            string goalType = parts[0];
            string[] goalData = parts[1].Split(",");

            switch (goalType)
            {
                case "SimpleGoal":
                    LoadSimpleGoal(goalData);
                    break;
                case "EternalGoal":
                    LoadEternalGoal(goalData);
                    break;
                case "ChecklistGoal":
                    LoadChecklistGoal(goalData);
                    break;
                default:
                    Console.WriteLine("Unknown goal type in file.");
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }


    // Helper method to load a SimpleGoal
    private void LoadSimpleGoal(string[] data)
    {
        if (data.Length != 4) return; // Ensure correct format

        string name = data[0];
        string description = data[1];
        int points = int.Parse(data[2]);
        bool isComplete = bool.Parse(data[3]);

        // Use the factory method to create the goal with the specified completion status
        SimpleGoal goal = SimpleGoal.CreateWithCompletionStatus(name, description, points, isComplete);
        _goals.Add(goal);
    }


    // Helper method to load an EternalGoal
    private void LoadEternalGoal(string[] data)
    {
        if (data.Length != 3) return; // Ensure correct format

        string name = data[0];
        string description = data[1];
        int points = int.Parse(data[2]);

        EternalGoal goal = new EternalGoal(name, description, points);
        _goals.Add(goal);
    }

    // Helper method to load a ChecklistGoal
    private void LoadChecklistGoal(string[] data)
    {
        if (data.Length != 6) return; // Ensure correct format

        string name = data[0];
        string description = data[1];
        int points = int.Parse(data[2]);
        int bonus = int.Parse(data[3]);
        int target = int.Parse(data[4]);
        int amountCompleted = int.Parse(data[5]);

        // Use the factory method to create the ChecklistGoal with the specified amount completed
        ChecklistGoal goal = ChecklistGoal.CreateWithAmountCompleted(name, description, points, target, bonus, amountCompleted);
        _goals.Add(goal);
    }

    // Method to check for level-up based on current score
    public void CheckLevelUp()
    {
        if (_score >= _pointsToNextLevel)
        {
            _currentLevel++;
            _pointsToNextLevel = _levelThresholds.ContainsKey(_currentLevel) ? _levelThresholds[_currentLevel] : _pointsToNextLevel + 500; // Increment threshold

            Console.WriteLine($"Congratulations! You've reached Level {_currentLevel}!");

            // Optionally add a reward for leveling up
            ApplyLevelBonus();
        }
    }

    // Method to apply bonus points or rewards when leveling up
    private void ApplyLevelBonus()
    {
        int bonus = _currentLevel * 10; // For example, 10 points per level
        _score += bonus;
        Console.WriteLine($"You've earned a bonus of {bonus} points for reaching Level {_currentLevel}!");
    }
}