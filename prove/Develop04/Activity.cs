using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using Timer = System.Threading.Timer;


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

    public void GetReady()
    {
        Console.WriteLine("Get ready...");
        Animation animation = new Animation();
        animation.AnimationDisplayStandard();

    }

    public void GetDone()
    {
        Console.WriteLine("Well done!");
        Animation animation = new Animation();
        animation.AnimationDisplayStandard();
    }

    public string DisplayStartingMessage()
    {
        return $"Welcome to the {_activityName} Activity.";
    }

    public string DisplayEndingMessage()
    {
        return $"You have completed another {_activityTime} seconds of the {_activityName} Activity.";
    }

    public int GetActivityTime()
    {
        return _activityTime;
    }

    /******************************************************/
    /********* Time related methods & attributes **********/
    /******************************************************/
    

    public object GetDateTime()
    {
        return DateTime.Now;
    }

    public object AddSeconds(int seconds)
    {
        return DateTime.Now.AddSeconds(seconds);
    }

    public void CountDown(int time)
    {
        CursorVisible = false;
       for (int i = time; i > 0; i--)
       {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b \b");
            //Console.Write("\b \b");
       }
       CursorVisible = true;
    }
}