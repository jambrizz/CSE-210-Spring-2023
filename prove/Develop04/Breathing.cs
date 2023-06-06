using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Breathing : Activity
{
    private string _description;
    private string _message1;

    private string _message2;

    private int _seconds;

    
    //Might need to change the constructor
    public Breathing(string activityName, int time, string description, string message1, string message2) : base(activityName, time)
    {
        _description = description;
        _message1 = message1;
        _message2 = message2;
    }

    public void SetSeconds(int seconds)
    {
        _seconds = seconds;
    }

    //TODO: add a method to split up the time into equals parts for breath in and out
}