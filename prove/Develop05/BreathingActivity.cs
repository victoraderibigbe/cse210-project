public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    { }

    public void Run()
    {
        // Display starting message to user
        DisplayStartingMessage();

        Thread.Sleep(1000); // Pause for 1 second

        DisplayStartingInstructions();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        bool isFirstIteration = true;

        while (DateTime.Now < endTime)
        {
            if (isFirstIteration)
            {
                // For the first iteration
                Console.Write("Breathe in...");
                ShowCountDown(2);
                Console.WriteLine();
                Console.Write("Now breathe out...");
                ShowCountDown(5);
                Console.WriteLine();
                Console.WriteLine();
                isFirstIteration = false;  // Set flag to false after the first iteration
            }
            else
            {
                // For subsequent iterations
                Console.Write("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine();
                Console.Write("Now breathe out...");
                ShowCountDown(6);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        DisplayEndingMessage(); // Display ending message to the user
    }
}