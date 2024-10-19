public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description) : base(name, description)
    {
        _count = 0;
        _prompts = new List<string>();
    }

    public void Run()
    {
        // Display starting message to user
        DisplayStartingMessage();

        Thread.Sleep(1000); // Pause for 1 second

        DisplayStartingInstructions();

        Console.WriteLine("List as many responses you can to the following prompt");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(20);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"You listed {_count} item(s)");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("Who are some of your personal heroes?");
        _prompts.Add("What scriptures did you study the scriptures this month?");
        _prompts.Add("What are the names of people you have impacted positively?");

        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[randomIndex]} ---"); // Display a random prompt from the list
    }
}