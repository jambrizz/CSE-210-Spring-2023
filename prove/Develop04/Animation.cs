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

    public void AnimationDisplay()
    {
        foreach (string item in _animation)
        {
            Console.Write(item);
            System.Threading.Thread.Sleep(200);
            Console.Clear();
        }
    }
}