using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class River: Journey
{
    private int _riverSphinxQuestions = 1;

    private int _riverBandits = 1;

    private int _riverBanditsHealth = 25;

    private int _riverBanditsAttack = 15;

    private List<string> _riverStoryLines = new List<string>()
    {
        "You decide to take the river path and you head down a narrow path that leads to the river. \nYou continue on this path until it ends at a small dock that has a small boat tied to it. \nYou untie the boat and push off into the river.",
        "You continue down the river and you see that it is getting dark. \nYou decide to pull the boat over to the side of the river and make camp for the night. \nYou find a nice spot and set up camp. You start a fire and cook some food. \nYou eat and then go to sleep.",
        "In the middle of the night you hear a noise and wake up. \nYou look around and see a group of river bandits standing around your camp. \nThey are looking through your things. \nYou jump up and grab your sword. You yell at them to leave. They laugh and one of them says, \nWe will leave when I am done with you.",
        "The river bandit draws his sword and starts walking towards you. \nYou pull out your weapon and prepare to fight"
    };

    public int GetRiverSphinxQuestions()
    {
        return _riverSphinxQuestions;
    }

    public void SetRiverSphinxQuestions(int number)
    {
        _riverSphinxQuestions = number;
    }

    public string GetBanditStats()
    {
        return $"Bandit Stats: \nHealth: {_riverBanditsHealth}\nAttack: {_riverBanditsAttack}";
    }

    public int GetRiverBandits()
    {
        return _riverBandits;
    }

    public int GetRiverBanditsHealth()
    {
        return _riverBanditsHealth;
    }

    public void SetRiverBanditsHealth(int health)
    {
        _riverBanditsHealth = health;
    }

    public int GetRiverBanditsAttack()
    {
        return _riverBanditsAttack;
    }   

    public void SetRiverBandits(int number)
    {
        _riverBandits = number;
    }

    public void RiverStory(int start, int end)
    {
        for(int i = start; i < end + 1;)
        {
            Console.Clear();
            Console.WriteLine(_riverStoryLines[i]);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            i++;
        }
    }
}