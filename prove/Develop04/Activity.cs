using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    }

    public void GetDone()
    {

    }

    public string GetActivityName()
    {
        return _activityName;
    }

    public int GetActivityTime()
    {
        return _activityTime;
    }
}