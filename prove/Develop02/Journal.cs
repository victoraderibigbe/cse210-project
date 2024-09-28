// Define a public class 'Journal' to manage multiple journal entries.
public class Journal
{
    // Private list to store all the journal entries.
    private List<Entry> entries = new List<Entry>();

    // Private list of prompts (questions) to randomly present to the user when writing a new entry.
    private List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Who made me smile today, and why?",
        "What challenge did I overcome today, and how did I handle it?",
        "What is something new I learned today?",
        "What am I most grateful for today?",
        "If I could share one piece of advice with my future self, what would it be?"
    };

    // Method to allow the user to write a new journal entry.
    // It randomly selects a prompt, takes the user's response, and adds a new entry to the journal.
    public void Write()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine($"Your response: ");
        string response = Console.ReadLine();

        // Additional prompts for mood and tags for exceeding requirements
        Console.WriteLine("How do I feel today (Mood)? ");
        string mood = Console.ReadLine();
        Console.WriteLine("Relevant tags (comma-separated): ");
        string tags = Console.ReadLine();
        entries.Add(new Entry(prompt, response, mood, tags));
    }

    // Method to display all journal entries.
    public void Display()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        else
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    // Method to save the journal entries to a file.
    // The user specifies the filename to save the journal to.
    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Mood}|{entry.Tags}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully");
    }

    // Method to load journal entries from a specified file.
    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        else
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(filename); // Read all lines from the file into an array of strings.
            foreach (string line in lines)
            {
                // Split each line into parts using the '|' delimiter (Date|Prompt|Response).
                string[] parts = line.Split('|');

                // If the line has exactly 5 parts (date, mood, tags, prompt, response), create a new Entry and add it to the 'entries' list.
                if (parts.Length == 5)
                {
                    entries.Add(new Entry(parts[1], parts[2], parts[3], parts[4]) { Date = parts[0] });
                }
            }
            Console.WriteLine("Journal loaded successfully");
        }
    }
}