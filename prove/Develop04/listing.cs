using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private int _listNumber;
    private List<(string Prompt, string Answer)> _responses = new List<(string, string)>();

    public ListingActivity(List<string> prompts, int countDown, string activityName)
        : base(countDown, activityName)
    {
        _prompts = prompts;
    }

    public List<string> GetPrompts()
    {
        return _prompts;
    }

    public int Increment()
    {
        _listNumber++;
        return _listNumber;
    }

    public void StartListingSession()
    {
        Console.WriteLine("Start listing your thoughts. Press Enter after each item.");

        string currentPrompt = GetRandomPrompt(_prompts);
        DisplayPrompt(currentPrompt);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetCountDown());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(answer))
            {
                GetRecordedAnswers().Add(answer);
                _responses.Add((currentPrompt, answer));
                Increment();
            }
            else
            {
                // Empty line means skip to next input attempt
                continue;
            }
        }

        Console.WriteLine($"You listed {_listNumber} items total!");
        LoadingAnimation();
    }

    public void SaveResultsToCsv(string fileName)
    {
        // Ensure the Results directory exists
        Directory.CreateDirectory("Results");

        // Save each prompt-answer pair to a CSV file
        using (StreamWriter writer = new StreamWriter(Path.Combine("Results", fileName), append: true))
        {
            writer.WriteLine($"Activity: {GetName()}, Date: {DateTime.Now}");
            foreach (var entry in _responses)
            {
                writer.WriteLine($"\"{entry.Prompt}\",\"{entry.Answer}\"");
            }
            writer.WriteLine(); // blank line for readability
        }

        Console.WriteLine($"Your listing results have been saved to Results/{fileName}");
    }
}
