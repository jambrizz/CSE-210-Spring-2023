using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

public class Animation
{
    List<string> _animation = new List<string>()
    {
        "|",
        "/",
        "-",
        "\\",
        "|",
        "/",
        "-",
        "\\",
        "|",
        "/",
        "-",
        "\\",
        "|",
        "/",
        "-",
        "\\"
    };

    
    public void AnimationDisplayStandard()
    {
        CursorVisible = false;
        foreach (string item in _animation)
        {
            Console.Write(item);
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
        Console.WriteLine();
        CursorVisible = true;
    }

    public void DisplaySpinnerCustomTime(int time)
    {
        CursorVisible = false;
        Activity activity = new Activity();
        object newTime = activity.AddSeconds(time);
        bool run = true;
        while (run == true)
        {
            foreach (string item in _animation)
            {
                Console.Write(item);
                Thread.Sleep(200);
                Console.Write("\b \b");
            }
            object currentTime = DateTime.Now;
            int timeIsUp = DateTime.Compare((DateTime)currentTime, (DateTime)newTime);
            if (timeIsUp == 1 || timeIsUp == 0)
            {
                run = false;
            }
        }
        Console.WriteLine();
        CursorVisible = true;
    }
}