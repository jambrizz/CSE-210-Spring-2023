using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Quest
{
    private bool _heroAlive;

    private bool _monsterAlive;

    private List<int> questionsAsked;

    private List<int> storyLinesDisplayed;

    public void QuestApp()
    {
        DisplayHelper dh = new DisplayHelper();
        dh.DisplayTitle();
        Animations anim = new Animations();
        anim.Spinner();
        Console.Clear();
        
        int heroSelect = 0;
        bool runMenu = true;
        while(runMenu == true)
        {
            dh.DisplayMenu();
            Console.Write(">: ");
            string input = Console.ReadLine();
            bool validInput = int.TryParse(input, out heroSelect);

            if(validInput == false)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a number and try again.");
                Console.WriteLine();
            }
            else if(validInput == true && heroSelect < 1 || validInput == true && heroSelect > 3)
            {
                Console.Clear();
                Console.WriteLine($"You entered {heroSelect}. Please enter a number between 1 and 3 and try again.");
                Console.WriteLine();
            }
            else if(validInput == true && heroSelect > 0 && heroSelect < 4)
            {
                runMenu = false;
            }
        }
        
        switch(heroSelect)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("You have selected the Paladin as your character.");
                Paladin p = new Paladin(1);
                string stats1 = p.HeroStats();
                Console.WriteLine();
                Console.WriteLine(stats1);
                Console.WriteLine();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                DisplayHelper dh1 = new DisplayHelper();
                dh1.DisplayStartingMessages();

                //////////////////////////////////////////////////
                //TODO: This is where you left off add a select path method
                //////////////////////////////////////////////////

                //Console.WriteLine();
                //Console.WriteLine($"Health: {p.GetHealth()}");
                //Console.WriteLine($"Armor: {p.GetArmor()}");
                //Console.WriteLine($"Shield: {p.GetShieldPower()}");
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("You have selected the Elf as your character.");
                Elf e = new Elf(2);
                string stats2 = e.HeroStats();
                Console.WriteLine();
                Console.WriteLine(stats2);

                //Console.WriteLine();
                //Console.WriteLine($"Health: {e.GetHealth()}");
                //Console.WriteLine($"Armor: {e.GetArmor()}");

                break;
            case 3:
                Console.Clear();
                Console.WriteLine("You have selected the Wizard as your character.");
                Wizard w = new Wizard(3);
                string stats3 = w.HeroStats();
                Console.WriteLine();
                Console.WriteLine(stats3);

                //Console.WriteLine();
                //Console.WriteLine($"Health: {w.GetHealth()}");
                //Console.WriteLine($"Armor: {w.GetArmor()}");
                break;
        }
    }

    // Might not need this method
    public string DisplayHeroStats()
    {
        return "";
    }

    // Might not need this method
    public string DisplayMonsterStats()
    {
        return "";
    }

    private int rollDie()
    {
        Random r = new Random();
        int number = r.Next(1, 20);
        return number;
    }

    public bool HeroDefeated()
    {
        // TODO replace this with a real implementation
        return false;
    }

    public bool MonsterDefeated()
    {
        // TODO replace this with a real implementation
        return false;
    }

    public bool PathComplete()
    {
        // TODO replace this with a real implementation
        return false;
    }

    public bool QuestComplete()
    {
        // TODO replace this with a real implementation
        return false;
    }
}