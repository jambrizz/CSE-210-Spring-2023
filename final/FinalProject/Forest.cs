using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Forest: Journey
{
    private int _forestGoblins = 1;

    private int _forestGoblinHealth = 20;

    private int _forestGoblinAttack = 10;

    private List<string> _forestStoryLines = new List<string>()
    {

    };

    public string GetGoblinStats()
    {
        return "Goblin Health: " + _forestGoblinHealth + "\nGoblin Attack: " + _forestGoblinAttack;
    }

    public int GetGoblinAttack()
    {
        return _forestGoblinAttack;
    }

    public int GetGoblinHealth()
    {
        return _forestGoblinHealth;
    }

    public void SetGoblinHealth(int health)
    {
        _forestGoblinHealth = health;
    }

    public void ForestStory(int start, int end)
    {
        for(int i = start; i < end + 1;)
        {
            Console.Clear();
            Console.WriteLine(_forestStoryLines[i]);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            i++;
        }
    }
}