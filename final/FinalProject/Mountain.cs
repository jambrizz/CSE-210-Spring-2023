using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Mountain: Journey
{
    private int _mountainTrollHealth = 30;

    private int _mountainTrollAttack = 20;

    private List<string> _mountainStoryLines = new List<string>()
    {

    };

    public string GetTrollStats()
    {
        return "Troll Health: " + _mountainTrollHealth + "\nTroll Attack: " + _mountainTrollAttack;
    }

    public int GetTrollHealth()
    {
        return _mountainTrollHealth;
    }

    public int GetTrollAttack()
    {
        return _mountainTrollAttack;
    }

    public void SetTrollHealth(int health)
    {
        _mountainTrollHealth = health;
    }

    public void SetMountainTrollHealth(int health)
    {
        _mountainTrollHealth = health;
    }

    public void MountainStory(int start, int end)
    {
        for(int i = start; i < end + 1;)
        {
            Console.Clear();
            Console.WriteLine(_mountainStoryLines[i]);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            i++;
        }
    }

}