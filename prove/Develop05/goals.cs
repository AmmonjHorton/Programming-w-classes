using System;
public abstract class Goals
{
    private string _goalName;
    private int _goalPoints;
    private string _goalDescription;

    private bool _isComplete = false;

    public Goals(string goalName, int goalPoints, string goalDescription)

    {
        _goalName = goalName;
        _goalPoints = goalPoints;
        _goalDescription = goalDescription;
    }
    public string GetGoalName()
    {
        return _goalName;
    }
    public int GetGoalPoints()
    {
        return _goalPoints;
    }
    public string GetGoalDescription()
    {
        return _goalDescription;
    }
    public void SetCompletion(bool isComplete)
    {
        _isComplete = isComplete;
    }
    public bool GetCompletion()
    {
        return _isComplete;
    }
    public void AskPoints()
    {
        Console.Write("What is the point value of this goal? ");
        _goalPoints = int.Parse(Console.ReadLine());
    }
    public void Display(string goalName, int goalPoints, string goalDescription)
    {
        Console.WriteLine($"Goal: {goalName} \n Description: {goalDescription} \n Points: {goalPoints}");
    }

    public abstract int RecordEvent(); 
    public virtual void DisplayCompletion()
    {
        if (_isComplete)
        {
            Console.WriteLine("[X] " + _goalName);
        }
        else
        {
            Console.WriteLine("[ ] " + _goalName);
        }
    }
    public virtual string ToCsv()
    {
        return $"{_goalName}|{_goalPoints}|{_goalDescription}|{_isComplete}";
    }
    public virtual void ResetEvent()
    {
        SetCompletion(false);
    }
    
        public void SaveGoal(Goals goal)
{
    string filePath = "goals.csv";
    using (StreamWriter writer = new StreamWriter(filePath, append: true))
    {
        writer.WriteLine(goal.ToCsv());
    }
}

}