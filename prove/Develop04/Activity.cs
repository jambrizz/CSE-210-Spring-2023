using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Activity
{
    private string _activityName;
    private int _activityTime;

    private string _message;

    public Activity(string activityName, int time)
    {
        _activityName = activityName;
        _activityTime = time;
    }

    public Activity(string activityName)
    {
        _activityName = activityName;
    }

    public Activity(int time)
    {
        _activityTime = time;
    }

    public Activity()
    {

    }

    public void SetActivityName(string activityName)
    {
        _activityName = activityName;
    }

    public void SetActivityTime(int time)
    {
        _activityTime = time;
    }

    public void CountDown(int time)
    {

    }

    public void GetReady()
    {
        Console.WriteLine("Get ready...");
        Animation animation = new Animation();
        animation.AnimationDisplayStandard();
    }

    public void GetDone()
    {

    }

    public string GetActivityName()
    {
        return $"Welcome to the {_activityName} Activity.";
    }

    public int GetActivityTime()
    {
        return _activityTime;
    }
}