using System;
using System.Collections.Generic;

public class Prompt
{
    private Random _random = new Random();
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string RandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}