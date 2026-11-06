using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public int _choice;
    public List<Entry> _entries = new List<Entry>();
    private const string Separator = "  |  ";

    private string GetProjectFolder()
    {
        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        if (!int.TryParse(Console.ReadLine(), out _choice))
        {
            _choice = 0;
            Console.WriteLine("Invalid input. Please enter a number from 1 to 5.\n");
            return;
        }
        OptionPick(_choice);
    }

    public void OptionPick(int option)
    {
        switch (option)
        {
            case 1: Write(); break;
            case 2: Display(); break;
            case 3: Load(); break;
            case 4: Save(); break;
            case 5: break;
            default:
                Console.WriteLine("Invalid option. Please choose 1 to 5.\n");
                break;
        }
    }

    public void Write()
    {
       Prompt prompt = new Prompt();
       string promptText = prompt.RandomPrompt();
       Console.WriteLine(promptText);
       Console.Write(">");
       string response = Console.ReadLine();

       Entry entry = new Entry();
       entry.AddNewEntry(DateTime.Today, promptText, response);
       _entries.Add(entry);
       Console.WriteLine();
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void Load()
    {
        Console.WriteLine("What is the filename? ");
        string filename = Console.ReadLine();

        if (!filename.EndsWith(".txt"))
        {
            filename +=".txt";
        }
        filename = Path.Combine(GetProjectFolder(), filename);

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. \n");
            return;
        }

        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split(Separator, 3, StringSplitOptions.None);
            if(parts.Length < 3 || !DateTime.TryParse(parts[0], out DateTime date)) continue;

            Entry newEntry = new Entry();
            newEntry.AddNewEntry(date, parts[1], parts[2]);
            _entries.Add(newEntry);
        }
        Console.WriteLine("Journal loaded.\n");
    }

    public void Save()
    {
        Console.WriteLine("What is the filename? ");
        string filename = Console.ReadLine();
        if (!filename.EndsWith(".txt"))
        {
            filename +=".txt";
        }
        filename = Path.Combine(GetProjectFolder(), filename);
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"{e._date}{Separator}{e._prompt}{Separator}{e._entry}");
            }
        }
        Console.WriteLine("Journal saved.\n");
    }

    public void Quit()
    {
        Console.WriteLine("Goodbye!");
    }
}