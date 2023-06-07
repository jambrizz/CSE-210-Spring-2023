using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Breathing : Activity
{
    private string _description;
    private string _message1 = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

    private string _message2 = $"";

    private int _seconds;

    
    //Might need to change the constructor
    public Breathing(string activityName, int time) : base(activityName, time)
    {
        _description = "Breathing";
        _seconds = time;
    }

    public Breathing() : base()
    {
        
    }

    public void SetSeconds(int seconds)
    {
        _seconds = seconds;
    }

    public string GetActivityDescription()
    {
        return _description;
    }

    public string GetMessage1()
    {
        return _message1;
    }

    //TODO: add a method to split up the time into equals parts for breath in and out
}