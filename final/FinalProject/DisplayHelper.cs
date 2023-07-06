using System;
using System.Text;
using System.IO;

public class DisplayHelper
{
    public void DisplayTitle()
    {
        Console.Clear();
        string filename = "title.txt";
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    public void DisplayMenu()
    {
        Console.Clear();
        string filename = "Menu.txt";
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }
}