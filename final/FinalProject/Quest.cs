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
                //Paladin p = new Paladin(1);
                //string stats1 = p.HeroStats();
                Character p = new Paladin(1);
                string stats1 = p.HeroStats();
                Console.WriteLine();
                Console.WriteLine(stats1);
                Console.WriteLine();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                DisplayHelper dh1 = new DisplayHelper();
                dh1.DisplayStartingMessages();

                int path = 0;
                bool pathSelection = false;
                while(pathSelection ==  false)
                {
                    dh1.DisplayTextFile("PathSelection.txt");
                    Console.Write("Enter your selection: ");
                    string input = Console.ReadLine();
                    bool validInput = int.TryParse(input, out int pathSelect);

                    if (validInput == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a number and try again.");
                        Console.WriteLine();
                    }
                    else if(validInput == true && pathSelect < 1 || validInput == true && pathSelect > 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"You entered {pathSelect}. Please enter a number between 1 and 3 and try again.");
                        Console.WriteLine();
                    }
                    else if(validInput == true && pathSelect > 0 && pathSelect < 4)
                    {
                        pathSelection = true;
                        path = pathSelect;
                    }
                }

                switch(path)
                {
                    case 1:
                        Console.Clear();
                        River r = new River();
                        r.RiverStory(0, 3);

                        bool riverCombat = true;
                        while(riverCombat == true)
                        {
                            Character p1 = new Paladin(1);

                            int enemyHealth = r.GetRiverBanditsHealth();
                            int enemyAttack = r.GetRiverBanditsAttack();
                            int playershield = p1.GetShieldPower();
                            int playerArmor = p1.GetArmor();
                            int playerHealth = p1.GetHealth();
                            int playerAttack = p1.GetWeaponPower();
                            
                            Console.Clear();
                            Console.WriteLine($"Your Stats\nHealth: {playerHealth}\nArmor: {playerArmor}\nShield: {playershield}");
                            Console.WriteLine();
                            Console.WriteLine($"{r.GetBanditStats()}");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the die you must get a 10 or higher to land a hit...");
                            Console.ReadKey();
                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");

                            if(roll < 10)
                            {
                                Console.WriteLine("You missed!");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else if(roll >= 10 && roll < 15)
                            {
                                int damage = playerAttack / 3;
                                
                                if (enemyHealth > damage)
                                {
                                    enemyHealth -= damage;
                                }
                                else
                                {
                                    enemyHealth = 0;
                                    riverCombat = false;
                                }

                                r.SetRiverBanditsHealth(enemyHealth);
                                Console.WriteLine("You landed a glancing blow!");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else if(roll >= 15 && roll <= 20)
                            {
                                if(playerAttack > enemyHealth)
                                {
                                    enemyHealth = 0;
                                    riverCombat = false;
                                }
                                r.SetRiverBanditsHealth(enemyHealth);
                                Console.WriteLine("You landed a fatal hit!");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }

                            if(enemyHealth > 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("The bandit attacks!");
                                Console.WriteLine();
                                roll = rollDie();

                                if(roll < 10)
                                {
                                    Console.WriteLine("The bandit missed!");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    if(playershield > 0)
                                    {
                                        //////////////////////////////////////////
                                        //TODO: This is where I left off. Need to figure out how to get the player shield to go down it currently doesn't change when he gets hit.
                                        //////////////////////////////////////////
                                        playershield -= enemyAttack;
                                        p1.CombatDamage("shield", enemyAttack);
                                    }
                                    else if(playerArmor > 0)
                                    {
                                        playerArmor -= enemyAttack;
                                        p1.CombatDamage("armor", enemyAttack);
                                    }
                                    else
                                    {
                                        playerHealth -= enemyAttack;
                                        p1.CombatDamage("health", enemyAttack);
                                    }
                                    Console.WriteLine("The bandit landed a hit!");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                            
                        }

                        //////////////////////////////////////////////////////////////////
                        //TODO: continue the story here
                        //////////////////////////////////////////////////////////////////
                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You have selected the Mountain Path.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("You have selected the Forest Path.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
                

                


                //////////////////////////////////////////////
                //TODO: Create a switch to decide if combat continues or to display a hero dead message or monster dead message
                //////////////////////////////////////////////

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