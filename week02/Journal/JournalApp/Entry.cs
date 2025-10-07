public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }
    public int Mood { get; set; }

    public Entry(string content, int mood, string prompt)
    {
        Date = Utils.GetDate();
        Prompt = prompt;
        Content = content;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"{Date} | Mood: {Mood}/10\nPrompt: {Prompt}\n{Content}";
    }
}