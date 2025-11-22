using System;

public class Eternal : Goals
{
    public Eternal(string goalName, int goalPoints, string goalDescription)
        : base(goalName, goalPoints, goalDescription)
    {
        
    }

    public override int RecordEvent()
    {
        return GetGoalPoints();
    }

   
}