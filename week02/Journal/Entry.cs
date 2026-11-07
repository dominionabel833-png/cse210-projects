using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    // Parameterless constructor (needed when loading from a file)
    public Entry()
    {
    }

    // Constructor with parameters (used when writing a new entry)
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Public properties so Journal.cs can read and write them safely
    public string Date 
    { 
        get { return _date; } 
        set { _date = value; } 
    }

    public string PromptText 
    { 
        get { return _promptText; } 
        set { _promptText = value; } 
    }

    public string EntryText 
    { 
        get { return _entryText; } 
        set { _entryText = value; } 
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }

    public string ToFileString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }
}