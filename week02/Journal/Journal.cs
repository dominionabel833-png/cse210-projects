using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Member variables use _underscoreCamelCase
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts.Length == 3)
            {
                Entry newEntry = new Entry();
                newEntry.Date = parts[0];
                newEntry.PromptText = parts[1];
                newEntry.EntryText = parts[2];

                _entries.Add(newEntry);
            }
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }
}