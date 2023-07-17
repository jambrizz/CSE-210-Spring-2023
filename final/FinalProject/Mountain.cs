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
        "You start the walk the path up the mountain. You keep walking up the mountain and see that the path turns to the left and you cant see where it leads. You keep walking up the path",
        "You reach the bend in the path to the left and are startled by a sleeping troll. \nYou try to sneak past the troll but you step on a twig and the troll wakes up. The troll is angry and starts chasing you!",
        "You run as fast as you can to avoid a fight with the troll since he is twice your size and you are not sure if you can beat him. You step on what looked like a solid boulder but it was actually a loose rock and you fall down the mountain.",
        "By falling down the mountain you manage to escape the troll but you fell down into a cavern. \nThe whole you made as you crashed through the cavern is to high and steep to climb back up. You have no choice but to keep going forward.",
        "You keep walking and seem a blue glowing light and decide to walk towards it. As you get closer you notice that the blue light is coming from blue glowing rocks. \nYou pick up one of the rocks and it starts to glow brighter and brighter. \nYou decide to use the glowing rock to light your way.",
        "You notice a statue covered with a cloth. You remove the cloth and see that it is a sphinx statue. You notice a message written on stone tablet next to the statue. You read the message.",
        "I am the sphinx of the mountain. \nI will ask you a question. If you answer it correctly you will be rewarded. \nIf you answer it incorrectly you will be punished. \nDo you wish to answer my questions?",
        "You keep wondering through the cavern guided by your glowing stone when you start to see what appears to be sunlight. \nYou walk towards the light and see that it is a hole in the cavern wall that leads outside. \nYou climb out of the hole and you stumble accross the same mountain troll that chased you earlier. \nHe is still angry and wants to fight you.",
        "You decide that there is no other way to escape the troll so you decide to fight him. \nYou pull out your weapon and prepare to fight.",
        "You swung your weapon and landed a fatal hit on the troll. \nHe falls to the ground and you finish him off.",
        "You are exhuasted from the fight with the troll and decide to rest for the night. \nYou find a nice spot and set up camp. You start a fire and cook some food. \nYou eat and then go to sleep.",
        "The sun rises and you pack up your things and continue up the mountain. \nYou see off in the distance the castle.",
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

    public void SetDamage(int damage)
    {
        SetTrollHealth(damage);
    }

    private void SetTrollHealth(int health)
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