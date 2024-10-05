public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        // Split the text into words and store them as Word objects
        string[] splitText = text.Split(' ');
        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Count how many words are not hidden
        int unhiddenWords = _words.Count(word => !word.IsHidden());

        // Adjust the numberToHide to ensure it does not exceed the number of unhidden words
        if (numberToHide > unhiddenWords)
        {
            numberToHide = unhiddenWords;
        }

        int hiddenCount = 0;
        while (hiddenCount < numberToHide)
        {
            // Select a random word
            int index = _random.Next(_words.Count);

            // If the word is not hidden, hide it
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }


    // Get the text to display
    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                scriptureText += "_____ "; // Replace hidden words with underscores
            }
            else
            {
                scriptureText += word.GetDisplayText() + " ";
            }
        }

        return scriptureText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        // Check if all words are hidden
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
