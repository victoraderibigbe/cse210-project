using System;

class Program
{
    // Main method is the entry point of the application.
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Victor Journal App!");

        // Create a new instance of the 'Journal' class to manage journal entries.
        Journal journal = new Journal();
        string userInput = "";

        // Loop until the user selects option 5 to quit the application.
        while (userInput != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do? ");
            userInput = Console.ReadLine();

            // Handle different user inputs using a switch statement.
            switch (userInput)
            {
                case "1":
                    journal.Write();
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Enter the filename to load the journal: ");
                    string loadFile = Console.ReadLine();
                    journal.Load(loadFile);
                    break;
                case "4":
                    Console.Write("Enter the filename to save the journal: ");
                    string saveToFile = Console.ReadLine();
                    journal.Save(saveToFile);
                    break;
                case "5":
                    Console.WriteLine("Thank you for using Victor Journal App!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}