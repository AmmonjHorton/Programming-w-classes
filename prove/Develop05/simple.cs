using System;

public class Simple : Goals
{
    public Simple(string goalName, int goalPoints, string goalDescription)
        : base(goalName, goalPoints, goalDescription)
    {
        
    }

    public override int RecordEvent()
    {
        if (!GetCompletion())
        {

            SetCompletion(true);
            return GetGoalPoints();
        }
        
        return 0;
    }

   
}