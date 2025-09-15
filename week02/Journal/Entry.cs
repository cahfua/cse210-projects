public class Entry
{
    public string Date { get; set; }
    public string Content { get; set; }
    public int Mood { get; set; }

    public Entry(string content, int mood)
    {
        Date = Utils.GetDate();
        Content = content;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"{Date} | Mood: {Mood}/10\n{Content}";
    }
}