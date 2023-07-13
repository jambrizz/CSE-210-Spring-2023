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
                        Character p1 = new Paladin(1);
                        int playershield = p1.GetShieldPower();
                        int playerArmor = p1.GetArmor();
                        int playerHealth = p1.GetHealth();
                        int playerAttack = p1.GetWeaponPower();
                        River r = new River();
                        r.RiverStory(0, 3);

                        bool riverCombat = true;
                        while(riverCombat == true)
                        {
                            int enemyHealth = r.GetRiverBanditsHealth();
                            int enemyAttack = r.GetRiverBanditsAttack();
                                                        
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
                                        playershield -= enemyAttack;
                                        
                                        if(playershield == 0)
                                        {
                                            p1.CombatDamage("shield", playershield);
                                        }
                                        else if(playershield < 0)
                                        {
                                            playershield = 0;
                                            p1.CombatDamage("shield", playershield);
                                        }
                                        else
                                        {
                                            p1.CombatDamage("shield", playershield);
                                        }
                                    }
                                    else if(playerArmor > 0)
                                    {
                                        playerArmor -= enemyAttack;
                                        
                                        if(playerArmor == 0)
                                        {
                                            p1.CombatDamage("armor", playerArmor);
                                        }
                                        else if(playerArmor < 0)
                                        {
                                            playerArmor = 0;
                                            p1.CombatDamage("armor", 0);
                                        }
                                        else 
                                        {
                                            p1.CombatDamage("armor", playerArmor);
                                        }
                                    }
                                    else
                                    {
                                        playerHealth -= enemyAttack;
                                        if(playerHealth == 0)
                                        {
                                            p1.CombatDamage("health", playerHealth);
                                            HeroDefeated();
                                            riverCombat = false;
                                        }
                                        else if(playerHealth < 0)
                                        {
                                            playerHealth = 0;
                                            p1.CombatDamage("health", playerHealth);
                                            HeroDefeated();
                                            riverCombat = false;
                                        }
                                        else
                                        {
                                            p1.CombatDamage("health", playerHealth);
                                        }
                                    }
                                    Console.WriteLine("The bandit landed a hit!");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                            
                        }
                        Console.Clear();
                        Console.WriteLine("You have won!");
                        Console.WriteLine();
                        Console.WriteLine($"Your updated Stats are\nHealth: {playerHealth}\nArmor: {playerArmor}\nShield: {playershield}");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue the story...");
                        Console.ReadKey();

                        r.RiverStory(4, 7); 

                        bool sphinxQuestions = true;
                        while(sphinxQuestions == true)
                        {
                            Console.WriteLine();    
                            Console.WriteLine("Do you wish to answer the sphinx's questions?"); 
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.Write("Enter your selection: ");
                            string input1 = Console.ReadLine();
                            bool validInput1 = int.TryParse(input1, out int sphinxSelect);
                            
                            if(validInput1 == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput1 == true && sphinxSelect < 1 || validInput1 == true && sphinxSelect > 2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput1 == true && sphinxSelect > 0 && sphinxSelect < 3)
                            {
                                
                                if(sphinxSelect == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Random rn = new Random();
                                    int number = rn.Next(0, 2);

                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        //string riddle = r.GetSphinxRiddle(number);
                                        string test = r.GetSphinxRiddle(0);
                                        Console.WriteLine(test);
                                        r.GetSphinxOptions(0);
                                        Console.WriteLine();
                                        Console.Write("Enter your selection: ");
                                        string input2 = Console.ReadLine();
                                        bool validInput2 = int.TryParse(input2, out int sphinxAnswer);
                                        
                                        if(validInput2 == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validInput2 == true && sphinxAnswer < 1 || validInput2 == true && sphinxAnswer > 3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validInput2 == true && sphinxAnswer > 0 && sphinxAnswer < 4)
                                        {
                                            if(sphinxAnswer == 1)
                                            {
                                                //Console.Clear();
                                                bool check = r.CheckAnswer(0, sphinxAnswer);
                                                if(check == true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen wisely!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    //////////////////////////////////////////////////////////
                                                    //TODO: Add the PowerUpOrPenalty(string text) method here and complete the method in the Character class
                                                    //////////////////////////////////////////////////////////
                                                    runSphinx = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    //////////////////////////////////////////////////////////
                                                    //TODO: Add the PowerUpOrPenalty(string text) method here and complete the method in the Character class
                                                    //////////////////////////////////////////////////////////
                                                    runSphinx = false;
                                                }
                                            }
                                            else if(sphinxAnswer == 2)
                                            {
                                                //Console.Clear();
                                                bool check = r.CheckAnswer(0, sphinxAnswer);
                                                if(check == true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen wisely!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    //////////////////////////////////////////////////////////
                                                    //TODO: Add the PowerUpOrPenalty(string text) method here and complete the method in the Character class
                                                    //////////////////////////////////////////////////////////
                                                    runSphinx = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    //////////////////////////////////////////////////////////
                                                    //TODO: Add the PowerUpOrPenalty(string text) method here and complete the method in the Character class
                                                    //////////////////////////////////////////////////////////
                                                    runSphinx = false;
                                                }
                                            }
                                            else if(sphinxAnswer == 3)
                                            {
                                                //Console.Clear();
                                                bool check = r.CheckAnswer(0, sphinxAnswer);
                                                if(check == true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen wisely!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    //////////////////////////////////////////////////////////
                                                    //TODO: Add the PowerUpOrPenalty(string text) method here and complete the method in the Character class
                                                    //////////////////////////////////////////////////////////
                                                    runSphinx = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    //////////////////////////////////////////////////////////
                                                    //TODO: Add the PowerUpOrPenalty(string text) method here and complete the method in the Character class
                                                    //////////////////////////////////////////////////////////
                                                    runSphinx = false;
                                                }
                                            }  
                                        }
                                    }
                                    sphinxQuestions = false;
                                }
                                else if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    sphinxQuestions = false;
                                }
                            }
                        }                
                        
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

    public void HeroDefeated()
    {
        Console.Clear();
        Console.WriteLine("You have been defeated!");
        Console.WriteLine();
        Environment.Exit(0);
    }

    public void MonsterDefeated()
    {
        Console.Clear();
        Console.WriteLine("Congratulations!");
        Console.WriteLine();
        Console.WriteLine("You have defeated the monster!");
        Console.WriteLine();
        Console.WriteLine("Treasure awaits you at the end of the path!");
        Environment.Exit(0);
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