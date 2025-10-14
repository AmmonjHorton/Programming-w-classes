using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

//I can't lie, I used A.I. for this because I don't understand CSV in C# and A.I. recommended this format
public class CsvStorage : IStorage
{
    private readonly string _path;
    private readonly Encoding _encoding = new UTF8Encoding(true);

    public CsvStorage(string path)
    {
        _path = path;
    }

    public IReadOnlyList<JournalEntry> ReadAll()
    {
        var result = new List<JournalEntry>();
        if (!File.Exists(_path))
            return result;

        foreach (var line in File.ReadAllLines(_path, _encoding))
        {
            var cols = ParseCsvLine(line);
            if (cols.Count >= 4)
            {
                DateTime ts = DateTime.TryParse(cols[0], out var t) ? t : DateTime.UtcNow;
                var entry = new JournalEntry
                {
                    Timestamp = ts,
                    Title = cols[1],
                    Rating = cols[2],
                    Prompt = cols[3],
                    Content = cols.Count > 4 ? cols[4] : string.Empty
                };
                result.Add(entry);
            }
        }

        return result;
    }

    public void Append(JournalEntry entry)
    {
        var dir = Path.GetDirectoryName(_path);
        if (string.IsNullOrEmpty(dir))
            dir = ".";
        Directory.CreateDirectory(dir);

        var line = SerializeEntry(entry);
        File.AppendAllText(_path, line + Environment.NewLine, _encoding);
    }

    public void WriteAll(IEnumerable<JournalEntry> entries)
    {
        var dir = Path.GetDirectoryName(_path);
        if (string.IsNullOrEmpty(dir)) dir = ".";
        Directory.CreateDirectory(dir);
        using (var writer = new StreamWriter(_path, false, _encoding))
        {
            foreach (var e in entries)
                writer.WriteLine(SerializeEntry(e));
        }
    }

    private string SerializeEntry(JournalEntry e)
    {
        string[] fields = new[] {
            e.Timestamp.ToString("o", CultureInfo.InvariantCulture),
            Escape(e.Title),
            Escape(e.Rating),
            Escape(e.Prompt),
            Escape(e.Content)
        };
        return string.Join(",", fields);
    }

    private static string Escape(string s)
    {
        if (s == null) return "";
        bool mustQuote = s.Contains(',') || s.Contains('"') || s.Contains('\n') || s.Contains('\r');
        string esc = s.Replace("\"", "\"\"");
        return mustQuote ? $"\"{esc}\"" : esc;
    }

    private static List<string> ParseCsvLine(string line)
    {
        var result = new List<string>();
        if (line == null) return result;
        var cur = new System.Text.StringBuilder();
        bool inQuotes = false;
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        cur.Append('"'); i++;
                    }
                    else inQuotes = false;
                }
                else cur.Append(c);
            }
            else
            {
                if (c == '"') inQuotes = true;
                else if (c == ',') { result.Add(cur.ToString()); cur.Clear(); }
                else cur.Append(c);
            }
        }
        result.Add(cur.ToString());
        return result;
    }
}
