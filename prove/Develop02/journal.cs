using System;
using System.Collections.Generic;

public class Journal
{
    private readonly IStorage _storage;
    public Journal(IStorage storage) { _storage = storage; }

    public JournalEntry CreateEntry(string title, string rating, string content = "", string prompt = "")
    {
        var e = new JournalEntry
        {
            Timestamp = DateTime.UtcNow,
            Title = title,
            Rating = rating,
            Content = content,
            Prompt = prompt
        };
        _storage.Append(e);
        return e;
    }

    public IReadOnlyList<JournalEntry> List() => _storage.ReadAll();
}


