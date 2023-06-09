using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Breathing : Activity
{
    private string _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    private string _message1 = $"Breath in... ";

    private string _message2 = $"Breath out... ";

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

    //TODO: Fix the method below to display the breathing exercise it currently does not display the messages
    public void DisplayBreathingExcercise(int time1, int time2)
    {
        bool runBreathing = ActivityTimer(time1);
        while (runBreathing == true)
        {
            
            Console.Write($"{_message1}");
            CountDown(time2);
            Console.WriteLine();
            Console.Write($"{_message2}");
            CountDown(time2);
            Console.WriteLine();
        }
    }

}