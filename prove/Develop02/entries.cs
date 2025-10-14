using System;
using System.IO;
using System.Collections.Generic;

public class JournalEntry
{
    public DateTime Timestamp { get; set; }
    public string Prompt { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

public interface IStorage
{
    IReadOnlyList<JournalEntry> ReadAll();
    void Append(JournalEntry entry);
    void WriteAll(IEnumerable<JournalEntry> entries);
}

public class Entries
{
    private readonly List<JournalEntry> entries = new List<JournalEntry>();
    private readonly IStorage _storage;
    private static readonly Random _rng = new Random();

    // optional storage injection
    public Entries(IStorage storage = null)
    {
        _storage = storage;
        if (_storage != null)
        {
            var loaded = _storage.ReadAll();
            if (loaded != null)
                entries.AddRange(loaded);
        }
    }

    // Add an entry by prompting the user for title, rating, and content; automatically selects a prompt
    public void AddEntryLabel()
    {
        Console.Write("What is the title of your entry? ");
        string title = Console.ReadLine() ?? string.Empty;

        Console.Write("How would you rate your day? ");
        string rating = Console.ReadLine() ?? string.Empty;

        // pick a prompt from the global Prompt list
        string prompt = string.Empty;
        if (Prompt.promptList != null && Prompt.promptList.Count > 0)
        {
            prompt = Prompt.promptList[_rng.Next(Prompt.promptList.Count)];
            Console.WriteLine(prompt);
        }

        Console.Write("Write your entry: ");
        string content = Console.ReadLine() ?? string.Empty;

        var entry = new JournalEntry
        {
            Timestamp = DateTime.Now,
            Title = title,
            Rating = rating,
            Prompt = prompt,
            Content = content
        };

        entries.Add(entry);

        // persist if storage available
        _storage?.Append(entry);
    }

    public void PreviewEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Timestamp:yyyy-MM-dd} - {entry.Title} - {entry.Rating}");
            if (!string.IsNullOrEmpty(entry.Prompt))
                Console.WriteLine($"Prompt: {entry.Prompt}");
            if (!string.IsNullOrEmpty(entry.Content))
                Console.WriteLine($"Entry: {entry.Content}");
            Console.WriteLine();
        }
    }

    public IReadOnlyList<JournalEntry> GetEntries() => entries.AsReadOnly();

    public void SaveAll()
    {
        if (_storage == null) return;
        _storage.WriteAll(entries);
    }
}