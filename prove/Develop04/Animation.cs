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

    public void AnimationDisplayCustom(int time)
    {
        while (time > 0)
        {
            foreach (string item in _animation)
            {
                Console.Write(item);
                Thread.Sleep(200);
                Console.Clear();
            }
            time--;
        }
    }
}