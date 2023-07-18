using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Forest: Journey
{
    private int _forestGoblinHealth = 20;

    private int _forestGoblinAttack = 10;

    private List<string> _forestStoryLines = new List<string>()
    {
        "You decide to walk through the forest. You keep walking and see a path that leads to the right. You decide to follow the path.",
        "You finally reach the edge of the forest and see a sign that is written in a language you dont understand. \nYou make out that it at least says two words but still cant understand what it means. \nYou decide to keep walking.",
        "You start walking into the forest. \nYou notice that the deeper you get in the forest the lest light there is to see your surroundings.",
        "You keep walking and you start getting an erie feeling that you are being watched. \nYou start to hear noises and you start to get scared. \nYou start to run and you trip over a tree root and fall to the ground.",
        "You get back up on your feet and keep running. \nYou see a light in the distance and decide to run towards it. \nYou reach the light and see that it is a campfire. \nYou see a figure sitting next to the campfire. \nYou walk towards the figure and see that it is a pack of Goblins.",
        "The goblins have not noticed you they seem to be distracted by something. \nThey seem to be eating something and you notice that it is a dead body. \nYou decide to sneak past the goblins.",
        "You manage to sneak past the goblins and keep walking through the forest. \nYou see a light in the distance and decide to walk towards it. \nYou reach the light and see that it is a campfire. \nIt was just lit but no signs of anyone around. \nYou decide to rest for a bit but do not feel safe enough to sleep.",
        "Your experience with goblins in the past have taught you that they are very sneaky and like to ambush their prey. \nYou decide to stay awake and keep watch.",
        "You look around and notice a small hollow in a tree. \nYou decide to investigate it.",
        "You see a sphinx statue inside the hollow. \nYou notice a message written on stone tablet next to the statue. You read the message.",
        "I am the sphinx of the forest. \nI will ask you a question. If you answer it correctly you will be rewarded. \nIf you answer it incorrectly you will be punished. \nDo you wish to answer my questions?",
        "You exit the hollow and walk back to the campfire. \nSuddenly you hear a noise behind you. \nYou turn around and see a pack of goblins. \nThey have noticed you and are charging towards you.",
        "You decide to fight the goblins. \nYou draw your sword and prepare for battle.",
        "A goblin reaches you and swings his sword at you. \nYou manage to dodge the attack and counter attack.",
        "You swing your sword and land a fatal hit on the goblin. \nHe falls to the ground and you finish him off.",
        "You are surrounded by the pack of goblins. They are all charging towards you. \nWhen suddenly they stop dead in the tracks and raise their heads and start smelling the hair. \nThey all start running away from you. \nYou are confused by what just happened.",
        "You start to look around and see a thick fog approaching. \nYou decide to run away from the fog. \nYou keep running and the fog keeps following you. \nYou keep running and you see a light in the distance. \nYou run towards the light and see that it is the edge of the forest. \nYou start coughing as you start inhaling some of the fog. \nYou run out of the forest and the fog stops following you.",
        "You drop to the ground and start coughing. \nYou start to feel dizzy and you pass out.",
        "You wake up and realize that you health has been effected by breathing in the fog.",
        "You defiently won't take the same path through the forest again. \nYou continue on your journey.",
        "You find an old sign on the path you pick it up and read what it says. \nYou realize that it is a warning sign that says 'Beware goblins'. \nYou flip the sign over and it says King's Tower over the hill.",
        "You follow the path and see a hill in the distance. \nYou walk up the hill and see a tower in the distance.",
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

    public void SetDamage(int damage)
    {
        SetGoblinHealth(damage);
    }

    private void SetGoblinHealth(int health)
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