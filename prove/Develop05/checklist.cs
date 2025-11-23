using System;

public class Checklist: Goals
{
public int TargetCount { get; set; }
//This is a thing apparently 
// Apparently it is basically the same thing as havin a getter and setter method with no draw backs \[-_-]/
public int CurrentCount { get; set; }
public int BonusPoints { get; set; }

public Checklist(string goalName, int goalPoints, string goalDescription, int targetCount, int bonusPoints)
    : base (goalName, goalPoints, goalDescription)
{
    TargetCount = targetCount;
    CurrentCount = 0;
    BonusPoints = bonusPoints;

}
public override int RecordEvent()
{
    if (!GetCompletion())
    {
        CurrentCount += 1;
        if (CurrentCount >= TargetCount)
        {
            SetCompletion(true);
            return GetGoalPoints() + BonusPoints;
        }
        else
        {
            return GetGoalPoints();
        }
    }
    return 0;
}
    public override void ResetEvent()
    {
        CurrentCount = 0;
        SetCompletion(false);
    }
    public override void DisplayCompletion()
    {
        if (GetCompletion())
        {
            Console.WriteLine($"[X] {GetGoalName()} -- Currently completed: {CurrentCount}/{TargetCount}");
        }
        else
        {
            Console.WriteLine($"[ ] {GetGoalName()} -- Currently completed: {CurrentCount}/{TargetCount}");
        }
    }
}