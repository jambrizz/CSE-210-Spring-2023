using System;

public class Assignment
{
    protected string _studentName;

    protected string _topic;

    public string GetStudentName()
    {
        return $"by {_studentName}";
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    public void SetStudentName(string studentName)
    {
        _studentName = studentName;
    }

    public void SetTopic(string topic)
    {
        _topic = topic;
    }

    public void SetAssignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
}