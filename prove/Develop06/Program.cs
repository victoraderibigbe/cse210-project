// To exceed requirements, I added a Leveling system to the program
// This would reward users with levels based on the points 
// they earn, adding an additional layer of motivation.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}