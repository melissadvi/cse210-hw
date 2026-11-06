using System;
public class Entry
{
    public DateTime _date;
    public string _prompt;
    public string _entry;

    public void Display()
    {
        Console.WriteLine($"Date: {_date.ToShortDateString()} - Prompt: {_prompt}");
        Console.WriteLine(_entry);
        Console.WriteLine();

    }
    public void AddNewEntry(DateTime date, string prompt, string entry)
    {
        _date = date;
        _prompt = prompt;
        _entry = entry;
    }
}