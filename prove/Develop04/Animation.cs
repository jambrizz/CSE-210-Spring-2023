using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    //TODO: fix animation display below it curently does not match the video explanation
    public void AnimationDisplayStandard()
    {
        foreach (string item in _animation)
        {
            Console.Write(item);
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }
    }

    public void AnimationDisplayCustom(int time)
    {
        while (time > 0)
        {
            foreach (string item in _animation)
            {
                Console.Write(item);
                System.Threading.Thread.Sleep(200);
                Console.Clear();
            }
            time--;
        }
    }
}