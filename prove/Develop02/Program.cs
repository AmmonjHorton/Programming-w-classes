using System;

class Program
{
    static void Main(string[] args)
    {
        string path = "journal.csv";
        var storage = new CsvStorage(path);
        var entries = new Entries(storage);

        while (true)
        {
            Console.WriteLine("Menu: 1) Write entry  2) Preview entries  3) Save all  4) Load all  5) Exit");
            Console.Write("Choose an option: ");
            var key = Console.ReadLine();
            if (key == "1") entries.AddEntryLabel();
            else if (key == "2") entries.PreviewEntries();
            else if (key == "3") { entries.SaveAll(); Console.WriteLine("Saved."); }
            else if (key == "4") { /* reload from storage */ var reloaded = new Entries(storage); Console.WriteLine("Reloaded from storage."); }
            else if (key == "5" || string.Equals(key, "exit", StringComparison.OrdinalIgnoreCase)) break;
            else Console.WriteLine("Unknown option.");
        }
    }
}