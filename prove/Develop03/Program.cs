// I added the functionality of loading scriptures from a library
// in order to exceed requirements

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a library of scriptures (Exceeding requirements)
        List<(Reference, string)> scriptureLibrary = new List<(Reference, string)>
        {
            (new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            (new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
            (new Reference("Psalm", 23, 1, 2), "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters."),
            (new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose.")
        };

        // Select a random scripture from the library
        Random random = new Random();
        int index = random.Next(scriptureLibrary.Count); // Get a random index
        var selectedScripture = scriptureLibrary[index]; // Get the reference and text tuple

        // Create a Scripture object with the selected scripture
        Scripture scripture = new Scripture(selectedScripture.Item1, selectedScripture.Item2);

        // Loop until the scripture is fully hidden
        while (!scripture.IsCompletelyHidden())
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide random words
            scripture.HideRandomWords(3); // Hide 3 random words each time
        }

        // Final message when the scripture is fully hidden
        Console.Clear();
        Console.WriteLine("Good job! You've now memorized the scripture.");
    }
}
