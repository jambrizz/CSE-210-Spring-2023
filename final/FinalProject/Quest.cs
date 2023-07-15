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
                                    playershield = p1.GetShieldPower();
                                    playerArmor = p1.GetArmor();
                                    playerHealth = p1.GetHealth();
                                    playerAttack = p1.GetWeaponPower();

                                    Console.WriteLine(playershield);
                                    Console.WriteLine(playerArmor);
                                    Console.WriteLine(playerHealth);
                                    Console.WriteLine(playerAttack);

                                    string newstats = p1.HeroStats();
                                    Console.WriteLine(newstats);

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
                                                    
                                                    Console.Clear();
                                                    string reward = r.GetPowerUpType();                                                    
                                                    p1.PowerUpOrPenalty(reward);
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    runSphinx = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    string penalty = r.GetPenalty();                                                    
                                                    p1.PowerUpOrPenalty(penalty);

                                                    Console.Clear();
                                                    newstats = p1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(newstats);
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
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
                                                    
                                                    Console.Clear();
                                                    string reward = r.GetPowerUpType();
                                                    p1.PowerUpOrPenalty(reward);
                                                    newstats = p1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(newstats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    runSphinx = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string penalty = r.GetPenalty();
                                                    p1.PowerUpOrPenalty(penalty);

                                                    newstats = p1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(newstats);
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
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

                                                    Console.Clear();                               
                                                    string reward = r.GetPowerUpType();
                                                    p1.PowerUpOrPenalty(reward);
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    runSphinx = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    string penalty = r.GetPenalty();                                                    
                                                    p1.PowerUpOrPenalty(penalty);

                                                    newstats = p1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(newstats);
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

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
                        //////////////////////////////////////////////
                        r.RiverStory(8, 10);
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
                Character e = new Elf(2);
                string elfStats = e.HeroStats();
                Console.WriteLine();
                Console.WriteLine(elfStats);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                DisplayHelper dh2 = new DisplayHelper();
                dh2.DisplayStartingMessages();

                int elfPath = 0;
                bool pathSelection2 = false;
                while(pathSelection2 == false)
                {
                    dh2.DisplayTextFile("PathSelection.txt");
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
                        pathSelection2 = true;
                        elfPath = pathSelect;
                    }
                }

                switch(elfPath)
                {
                    case 1:
                        Console.Clear();
                        Character e1 = new Elf(2);
                        int playerArmor = e1.GetArmor();
                        int playerHealth = e1.GetHealth();
                        int playerAttack = e1.GetWeaponPower();
                        int playerBow = e1.GetElfBowPower();

                        River r2 = new River();
                        r2.RiverStory(0, 3);

                        bool riverCombat2 = true;
                        while(riverCombat2 == true)
                        {
                            int enemyHealth = r2.GetRiverBanditsHealth();
                            int enemyAttack = r2.GetRiverBanditsAttack();

                            Console.Clear();
                            Console.WriteLine($"Your Stats\nHealth: {playerHealth}\nArmor: {playerArmor}\nBow: {playerBow}");
                            Console.WriteLine();
                            Console.WriteLine($"{r2.GetBanditStats()}");
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
                            if(roll >= 10 && roll < 15)
                            {
                                int damage = playerAttack / 2;
                                
                                if (enemyHealth > damage)
                                {
                                    enemyHealth -= damage;
                                }
                                else
                                {
                                    enemyHealth = 0;
                                    riverCombat2 = false;
                                }

                                r2.SetRiverBanditsHealth(enemyHealth);
                                Console.WriteLine("You landed a glancing blow!");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else if(roll >= 15 && roll <= 20)
                            {
                                if(playerBow > enemyHealth)
                                {
                                    enemyHealth = 0;
                                    riverCombat2 = false;
                                }
                                
                                r2.SetRiverBanditsHealth(enemyHealth);
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
                                    if(playerArmor > 0)
                                    {
                                        playerArmor -= enemyAttack;
                                        
                                        if(playerArmor == 0)
                                        {
                                            e1.CombatDamage("armor", playerArmor);
                                        }
                                        else if(playerArmor < 0)
                                        {
                                            playerArmor = 0;
                                            e1.CombatDamage("armor", 0);
                                        }
                                        else 
                                        {
                                            e1.CombatDamage("armor", playerArmor);
                                        }
                                    }
                                    else
                                    {
                                        playerHealth -= enemyAttack;
                                        if(playerHealth == 0)
                                        {
                                            e1.CombatDamage("health", playerHealth);
                                            HeroDefeated();
                                            riverCombat2 = false;
                                        }
                                        else if(playerHealth < 0)
                                        {
                                            playerHealth = 0;
                                            e1.CombatDamage("health", playerHealth);
                                            HeroDefeated();
                                            riverCombat2 = false;
                                        }
                                        else
                                        {
                                            e1.CombatDamage("health", playerHealth);
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
                        Console.WriteLine($"Your updated Stats are\nHealth: {playerHealth}\nArmor: {playerArmor}\nBow: {playerBow}");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue the story...");
                        Console.ReadKey();

                        r2.RiverStory(4, 7);

                        bool sphinxQuestions2 = true;
                        while(sphinxQuestions2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.Write("Enter your selection: ");
                            string input2 = Console.ReadLine();
                            bool validInput2 = int.TryParse(input2, out int sphinxSelect);

                            if(validInput2 == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput2 == true && sphinxSelect < 1 || validInput2 == true && sphinxSelect > 2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput2 == true && sphinxSelect > 0 && sphinxSelect < 3)
                            {
                                if(sphinxSelect == 1)
                                {
                                    playerArmor = e1.GetArmor();
                                    playerHealth = e1.GetHealth();
                                    playerAttack = e1.GetWeaponPower();

                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();

                                    Random rn = new Random();
                                    int number = rn.Next(0, 2);

                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        //////////////////////////////////////////////////////
                                        //TODO: switch out the parameter 0 in the GetSphinxRiddle method with the number variable
                                        //////////////////////////////////////////////////////
                                        
                                        string question = r2.GetSphinxRiddle(0);
                                        Console.WriteLine(question);
                                        r2.GetSphinxOptions(0);
                                        Console.WriteLine();
                                        Console.Write("Enter your selection: ");
                                        string sphinxInput2 = Console.ReadLine();
                                        bool validSphinxInput2 = int.TryParse(sphinxInput2, out int sphinxAnswer2);

                                        if(validSphinxInput2 == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validSphinxInput2 == true && sphinxAnswer2 < 1 || validSphinxInput2 == true && sphinxAnswer2 > 3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer2}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validSphinxInput2 == true && sphinxAnswer2 >= 1 || validSphinxInput2 == true && sphinxAnswer2 < 4)
                                        {
                                            if(sphinxAnswer2 == 1)
                                            {
                                                bool check = r2.CheckAnswer(0, sphinxAnswer2);
                                                if(check == true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen wisely!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string reward = r2.GetPowerUpType();
                                                    e1.PowerUpOrPenalty(reward);
                                                    elfStats = e1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(elfStats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    runSphinx = false;
                                                    sphinxQuestions2 = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string penalty = r2.GetPenalty();
                                                    e1.PowerUpOrPenalty(penalty);
                                                    elfStats = e1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(elfStats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    runSphinx = false;
                                                    sphinxQuestions2 = false;
                                                }
                                            }
                                            else if(sphinxAnswer2 == 2)
                                            {
                                                bool check = r2.CheckAnswer(0, sphinxAnswer2);
                                                if(check == true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen wisely!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string reward = r2.GetPowerUpType();
                                                    e1.PowerUpOrPenalty(reward);
                                                    elfStats = e1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(elfStats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    runSphinx = false;
                                                    sphinxQuestions2 = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string penalty = r2.GetPenalty();
                                                    e1.PowerUpOrPenalty(penalty);
                                                    elfStats = e1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(elfStats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    runSphinx = false;
                                                    sphinxQuestions2 = false;
                                                }
                                            }
                                            else if(sphinxAnswer2 == 3)
                                            {
                                                bool check = r2.CheckAnswer(0, sphinxAnswer2);
                                                if(check == true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen wisely!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string reward = r2.GetPowerUpType();
                                                    e1.PowerUpOrPenalty(reward);
                                                    elfStats = e1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(elfStats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    runSphinx = false;
                                                    sphinxQuestions2 = false;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You have chosen poorly!");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    Console.Clear();
                                                    string penalty = r2.GetPenalty();
                                                    e1.PowerUpOrPenalty(penalty);
                                                    elfStats = e1.HeroStats();
                                                    Console.WriteLine();
                                                    Console.WriteLine(elfStats);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    runSphinx = false;
                                                    sphinxQuestions2 = false;
                                                }
                                            }
                                        }
                                    }

                                }
                                else if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    sphinxQuestions2 = false;
                                }
                            }
                        }
                     
                        r2.RiverStory(8, 10);

                        //////////////////////////////////////////////
                        //TODO: add the monster section here
                        //////////////////////////////////////////////

                        break;
                    case 2:
                        
                        break;
                    case 3:
                            
                        break;
                }

                break;
            case 3:
                Console.Clear();
                Console.WriteLine("You have selected the Wizard as your character.");
                Character w = new Wizard(3);
                string wizardStats = w.HeroStats();
                Console.WriteLine();
                Console.WriteLine(wizardStats);
                Console.WriteLine();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                DisplayHelper dh3 = new DisplayHelper();
                dh3.DisplayStartingMessages();

                int wizardPath = 0;
                bool pathSelection3 = false;
                while(pathSelection3 == false)
                {
                    dh3.DisplayTextFile("PathSelection.txt");
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
                        pathSelection3 = true;
                        wizardPath = pathSelect;
                    }
                }

                switch(wizardPath)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("You have selected the River Path.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
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