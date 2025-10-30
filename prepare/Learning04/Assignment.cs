using System;

public class Assignment
{
    private string _topic;
    private string _studentName;

    public Assignment(string topic, string studentName)
    {
        _topic = topic;
        _studentName = studentName;
    }
    public string GetSumary()
    {
        return $"{_topic} - {_studentName}";
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }
    
}