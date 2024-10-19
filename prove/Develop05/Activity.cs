public class Activity
{
    protected string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of {_name} Activity");
        ShowSpinner(2);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            // Determine how many backspaces are needed based on the length of the number
            int digitCount = i.ToString().Length;
            for (int j = 0; j < digitCount; j++)
            {
                Console.Write("\b \b"); // Backspace for each digit
            }
        }
    }

    public void DisplayStartingInstructions()
    {
        // Prompt user for duration
        Console.Write("How long in seconds, would you like for your session? ");
        _duration = Convert.ToInt32(Console.ReadLine());

        Console.Clear(); // Clear the console

        Console.WriteLine("Get Ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }
}