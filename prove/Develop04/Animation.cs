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

    //TODO: add parameters to the AnimationDisplay methods to allow for custom cursor positions
    public void AnimationDisplayStandard()
    {
        //CursorVisible hides the cursor
        CursorVisible = false;
        foreach (string item in _animation)
        {
            //SetCursorPosition sets the cursor position to the specified coordinates (x, y)
            SetCursorPosition(0, 3);
            Console.Write(item);
            Thread.Sleep(200);
        }
        //CursorVisible shows the cursor after the animation is done
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