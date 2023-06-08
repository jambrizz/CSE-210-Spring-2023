using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public int SplitTime(int time)
    {
        int pairs = 0;
        bool endLoop = false;
        while (endLoop == false)
        {
          /////////////////////////////
          //TODO: fix this algorithm to split up the time in equal parts//
          ////////////////////////////  
        }
        /*
        for (int i = 0; i < time; i++)
        {
            if (time % 2 == 0)
            {
                pairs = time / 2;
            }
            else
            {
                pairs = (time - 1) / 2;
            }
        }*/
        return pairs;
    }

    public string DisplayBreathingExcercise(int time, int pairs)
    {
        return "";   
    }

    //TODO: add a method to split up the time into equals parts for breath in and out
}