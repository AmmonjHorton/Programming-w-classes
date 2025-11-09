using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompt1 = new List<string>();
    private List<string> _prompt2 = new List<string>();
    private List<(string Prompt, string Answer)> _responses = new List<(string, string)>();

    public ReflectingActivity(List<string> prompt1, List<string> prompt2, int countDown, string activityName)
        : base(countDown, activityName)
    {
        _prompt1 = prompt1;
        _prompt2 = prompt2;
    }

    public void StartReflectionSession()
    {
        Console.WriteLine("Take a moment to reflect on each question below.");
        Console.WriteLine("Press Enter after your response to move to the next.");

        int totalTime = GetCountDown();
        DateTime endTime = DateTime.Now.AddSeconds(totalTime);

        while (DateTime.Now < endTime)
        {
            string promptA = GetRandomPrompt(_prompt1);
            DisplayPrompt(promptA);
            Console.Write("> ");
            string answerA = Console.ReadLine();
            _responses.Add((promptA, answerA));

            if (DateTime.Now >= endTime) break;

            string promptB = GetRandomPrompt(_prompt2);
            DisplayPrompt(promptB);
            Console.Write("> ");
            string answerB = Console.ReadLine();
            _responses.Add((promptB, answerB));
        }

        Console.WriteLine("Your reflection session has ended. Take a deep breath and relax.");
        LoadingAnimation();
    }

    public void SaveResultsToCsv(string fileName)
    {
        Directory.CreateDirectory("Results");

        using (StreamWriter writer = new StreamWriter(Path.Combine("Results", fileName), append: true))
        {
            writer.WriteLine($"Activity: {GetName()}, Date: {DateTime.Now}");
            foreach (var entry in _responses)
            {
                writer.WriteLine($"\"{entry.Prompt}\",\"{entry.Answer}\"");
            }
            writer.WriteLine();
        }

        Console.WriteLine($"Your reflections have been saved to Results/{fileName}");
    }
}
