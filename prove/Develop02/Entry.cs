// Define a public class named 'Entry' to represent a journal entry.
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Additional fields to exceed requirements
    public string Mood { get; set; }
    public string Tags { get; set; }


    // Constructor for the 'Entry' class that takes a prompt and a response.
    // It sets the 'Prompt' and 'Response' properties and automatically assigns the current date.

    public Entry(string prompt, string response, string mood, string tags)
    {
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tags = tags;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    // Override the default 'ToString' method to format the entry information as a string.
    // This method will return a string with the entry's date, prompt, and response.
    public override string ToString()
    {
        return $"Date: {Date} - Mood: {Mood} - Tags: {Tags} - Prompt: {Prompt}\n{Response}\n";
    }
}