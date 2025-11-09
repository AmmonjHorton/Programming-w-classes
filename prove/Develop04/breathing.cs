using System;
using System.Threading;

public class BreathingActivity : Activity
{
    private int _phaseDuration;

    public BreathingActivity(int countDown, string activityName)
    : base(countDown, activityName)
    {
    // Divide evenly into 4 phases; round down so total time fits properly
    _phaseDuration = Math.Max(1, countDown / 4);
    }


    public int GetPhaseDuration()
    {
        return _phaseDuration;
    }

  
    public void DisplayBreathing(int phaseDuration)
    {
        Console.WriteLine("Breathe in...");
        CountDownAnimation(phaseDuration);

        Console.WriteLine("Now breathe out...");
        CountDownAnimation(phaseDuration);

        Console.WriteLine("Breathe in...");
        CountDownAnimation(phaseDuration);

        Console.WriteLine("Now breathe out...");
        CountDownAnimation(phaseDuration);
    }

    public void StartBreathingSession()
    {
    Console.WriteLine("Follow the guided breathing...");

    int totalTime = GetCountDown();
    DateTime endTime = DateTime.Now.AddSeconds(totalTime);

    while (DateTime.Now < endTime)
    {
        DisplayBreathing(_phaseDuration);
    }

    Console.WriteLine("Excellent — your breathing session has ended.");
    LoadingAnimation();
    }

}
