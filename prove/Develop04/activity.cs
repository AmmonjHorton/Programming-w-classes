using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private int _countDown;
    private string _activityName;
    private Random _randomPrompt = new Random();
    private List<string> _recordedAnswers = new List<string>();

    public Activity(int countDown, string activityName)
    {
        _activityName = activityName;
        _countDown = countDown;
    }

    public string GetName()
    {
        return _activityName;
    }

    public int GetCountDown()
    {
        return _countDown;
    }

    public void SetCountDown(int countDown)
    {
        _countDown = countDown;
    }

    public void SetName(string activityName)
    {
        _activityName = activityName;
    }

    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to a relaxing therapy activity!");
        Console.WriteLine("Please select an activity and a time duration (in seconds).");
        Console.WriteLine();
    }

    public void DisplayActivity(string activityName, int countDown)
    {
        Console.WriteLine($"Starting {activityName} for {countDown} seconds...");
        Console.WriteLine();
    }

    public void DisplayGoodbye()
    {
        Console.WriteLine();
        Console.WriteLine("Thank you for participating in today's relaxation session.");
    }

    public void LoadingAnimation()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write("/");

            Thread.Sleep(500);
            Console.Write("\b \b");

            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write(@"\");
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }

    public void CountDownAnimation(int countDown)
    {
        for (int i = countDown; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public string GetRandomPrompt(List<string> prompts)
    {
        int index = _randomPrompt.Next(prompts.Count);
        return prompts[index];
    }

    public string GetAnswer()
    {
        string answer = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(answer))
        {
            _recordedAnswers.Add(answer);
        }
        return answer;
    }

    public List<string> GetRecordedAnswers()
    {
        return _recordedAnswers;
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
    }
}
