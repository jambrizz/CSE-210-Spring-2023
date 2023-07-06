using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

public class Animations
{
    private int _time;

    private List<string> _spinnerAnimation = new List<string>()
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

    public void Spinner()
    {
        CursorVisible = false;
        Console.Write("Loading Game... ");
        foreach (string item in _spinnerAnimation)
        {
            Console.Write(item);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
        CursorVisible = true;
    }

    public void MonsterAnimation()
    {

    }

    public void Sprite()
    {
        
    }   
}