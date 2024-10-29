using System;

class Program
{
    static void Main(string[] args)
    {
        Activity running = new RunningActivity("29 Oct 2024", 30, 3.0f);
        Activity cycling = new CyclingActivity("30 Oct 2024", 15, 4.5f);
        Activity swimming = new SwimmingActivity("31 Oct 2024", 45, 20);

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary(activity.GetName()));
        }
    }
}