// To exceed requirements, I added the functionality to track
// the number of times each activity was preformed

using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;

        // Initialize counts for each activity
        int breathingActivityCount = 0;
        int reflectingActivityCount = 0;
        int listingActivityCount = 0;

        while (!quit)
        {
            Console.WriteLine("Menu Options: \n 1. Start breathing activity. \n 2. Start reflecting activity \n 3. Start listing activity \n 4. Quit");
            Console.Write("Select a choice from the menu: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    StartBreathingActivity();
                    breathingActivityCount++;
                    break;
                case 2:
                    StartReflectingActivity();
                    reflectingActivityCount++;
                    break;
                case 3:
                    StartListingActivity();
                    listingActivityCount++;
                    break;
                case 4:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine();

        // Display message indicating the number of times each activity was taken
        if (breathingActivityCount <= 0)
        {
            Console.WriteLine("You did not take the breathing activity");
        }
        else
        {
            Console.WriteLine($"You took breathing activity {breathingActivityCount} time(s)");
        }

        if (reflectingActivityCount <= 0)
        {
            Console.WriteLine("You did not take the reflecting activity");
        }
        else
        {
            Console.WriteLine($"You took reflecting activity {reflectingActivityCount} time(s)");
        }

        if (listingActivityCount <= 0)
        {
            Console.WriteLine("You did not take the listing activity");
        }
        else
        {
            Console.WriteLine($"You took listing activity {listingActivityCount} time(s)");
        }

        // Function to start breathing activity
        void StartBreathingActivity()
        {
            BreathingActivity activity = new BreathingActivity("Breathing", "This activity will help you to breath well and get rid of depression.");

            activity.Run();

        }

        // Function to start reflecting activity
        void StartReflectingActivity()
        {
            ReflectingActivity activity = new ReflectingActivity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

            activity.Run();
        }

        // Function to start listing activity
        void StartListingActivity()
        {
            ListingActivity activity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

            activity.Run();
        }
    }
}