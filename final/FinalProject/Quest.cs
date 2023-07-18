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

    private int rollDie()
    {
        Random r = new Random();
        int number = r.Next(1, 20);
        return number;
    }

    private int rollSphinxDie()
    {
        Random r = new Random();
        int number = r.Next(0, 2);
        return number;
    }

    private int rollMonsterDie()
    {
        Random r = new Random();
        int number = r.Next(0, 2);
        return number;
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
            //Paladin
            case 1:
                Console.Clear();
                Console.WriteLine("You have selected the Paladin as your character.");
                Character p = new Paladin(1);
                string paladinStats = p.HeroStats();
                Console.WriteLine();
                Console.WriteLine(paladinStats);
                Console.WriteLine();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                DisplayHelper dh1 = new DisplayHelper();
                dh1.DisplayStartingMessages();

                int paladinPath = 0;
                bool pathSelection1 = false;
                while(pathSelection1 == false)
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
                        pathSelection1 = true;
                        paladinPath = pathSelect;
                    }
                }

                switch(paladinPath)
                {
                    //River Path
                    case 1:
                        Console.Clear();
                        Character p1 = new Paladin(1);
                        River r1 = new River();
                        r1.RiverStory(0, 3);

                        bool riverCombat3 = true;
                        while(riverCombat3)
                        {
                            Console.Clear();
                            p1.CombatStats(1);
                            int enemyHealth = r1.GetRiverBanditsHealth();
                            int enemyAttack = r1.GetBanditsAttack();
                            Console.WriteLine($"Bandit Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            
                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = p1.combat(1, roll, enemyHealth);
                            r1.SetDamage(damage);
                            enemyHealth = r1.GetRiverBanditsHealth();                        

                            if(enemyHealth == 0)
                            {
                                riverCombat3 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The bandit attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The bandit rolled a {roll}.");
                                int enemyStrike = r1.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    p1.CombatDamage(1, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The bandit missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                        }
                        Console.Clear();              
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        r1.RiverStory(4, 7);

                        bool sphinxQuestion1 = true;
                        while(sphinxQuestion1 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            
                            string input1 = Console.ReadLine();
                            bool validInput1 = int.TryParse(input1, out int sphinxSelect3);

                            if(validInput1 == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput1 == true && sphinxSelect3 <1 || validInput1 == true && sphinxSelect3 >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect3}. Please enter a number between 1 and 2 and try again.");
                            }
                            else if(validInput1 == true && sphinxSelect3 > 0 && sphinxSelect3 < 3)
                            {
                                if(sphinxSelect3 == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion1 = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    
                                    int roll = rollSphinxDie();
                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        Console.Clear();
                                        r1.GetSphinxChallenge(roll);
                                        Console.WriteLine();
                                        Console.Write("Enter your choice: ");
                                        string userChoice = Console.ReadLine();
                                        bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                        if(validUserChoice == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer < 1 || validUserChoice == true && sphinxAnswer >3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                        {
                                            Console.Clear();
                                            //Replace the 0 with the roll variable
                                            bool check = r1.CheckAnswer(0, sphinxAnswer);
                                            if(check == true)
                                            {
                                                string reward = r1.GetPowerUpType();
                                                Console.WriteLine("You have chosen wisely!");
                                                p1.PowerUpOrPenalty(reward);
                                                runSphinx = false;
                                            }
                                            else
                                            {
                                                string penalty = r1.GetPenalty();
                                                Console.WriteLine("You have chosen poorly!");
                                                p1.PowerUpOrPenalty(penalty);
                                                runSphinx = false;
                                            }
                                        }
                                    }
                                }
                                p1.CombatStats(1);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                sphinxQuestion1 = false;
                            }    
                        }
                        r1.RiverStory(8, 10);
                        /////////////////////////////////////////////////////////
                        //TODO: add the monster section here
                        /////////////////////////////////////////////////////////
                        break;
                    //Mountain Path
                    case 2:
                        Console.Clear();
                        Character mp = new Paladin(1);
                        Mountain m1 = new Mountain();
                        m1.MountainStory(0, 6);

                        bool sphinxQuestion = true;
                        while(sphinxQuestion == true)
                        {
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int sphinxSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                            }
                            else if(validInput == true && sphinxSelect < 1 || validInput == true && sphinxSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                            }
                            else if(validInput == true && sphinxSelect > 0 || validInput == true && sphinxSelect <3)
                            {
                                if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();

                                    int roll = rollSphinxDie();
                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        Console.Clear();
                                        m1.GetSphinxChallenge(roll);
                                        Console.WriteLine();
                                        Console.Write("Enter your choice: ");
                                        string userChoice = Console.ReadLine();
                                        bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                        if(validUserChoice == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer < 1 || validUserChoice == true && sphinxAnswer >3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                        {
                                            Console.Clear();
                                            //Replace the 0 with the roll variable
                                            bool check = m1.CheckAnswer(0, sphinxAnswer);

                                            if(check == true)
                                            {
                                                string reward = m1.GetPowerUpType();
                                                Console.WriteLine("You have chosen wisely!");
                                                mp.PowerUpOrPenalty(reward);
                                                runSphinx = false;
                                            }
                                            else
                                            {
                                                string penalty = m1.GetPenalty();
                                                Console.WriteLine("You have chosen poorly!");
                                                mp.PowerUpOrPenalty(penalty);
                                                runSphinx = false;
                                            }
                                        }

                                    }
                                    sphinxQuestion = false;
                                }  
                            }
                        }
                        /////////////////////////////////////////////
                        mp.CombatStats(1);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        m1.MountainStory(7, 8);

                        bool trollFight = true;
                        while(trollFight == true)
                        {
                            Console.Clear();
                            mp.CombatStats(1);
                            int enemyHealth = m1.GetTrollHealth();
                            int enemyAttack = m1.GetTrollAttack();
                            Console.WriteLine($"Troll Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            Console.WriteLine();

                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = mp.combat(1, roll, enemyHealth);
                            
                            m1.SetDamage(damage);
                            enemyHealth = m1.GetTrollHealth();

                            if(enemyHealth == 0)
                            {
                                trollFight = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The troll attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The troll rolled a {roll}.");
                                int enemyStrike = m1.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    mp.CombatDamage(1, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The troll missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }

                            }
                        }
                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        m1.MountainStory(9, 10);
                        ////////////////////////////////////////////////////////// TODO: add the monster section here


                        ////////////////////////////////////////////

                        break;
                    //Forest Path
                    case 3:

                        Console.Clear();
                        Character fp = new Paladin(1);
                        Forest f1 = new Forest();
                        f1.ForestStory(0, 10);

                        int sphinxRoll = rollSphinxDie();
                        bool sphinxQuestion3 = true;
                        while(sphinxQuestion3 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int sphinxSelect);

                            if(validInput ==  false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && sphinxSelect < 1 || validInput == true && sphinxSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && sphinxSelect >0 || validInput == true && sphinxSelect <3)
                            {
                                if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion3 = false;   
                                }
                                else
                                {
                                    Console.Clear();
                                    f1.GetSphinxChallenge(sphinxRoll);
                                    Console.WriteLine();
                                    Console.Write("Enter your choice: ");
                                    string userChoice = Console.ReadLine();
                                    bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                    if(validUserChoice == false)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid input. Please enter a number and try again.");
                                        Console.WriteLine();
                                    }
                                    else if(validUserChoice == true && sphinxAnswer <1 || validUserChoice == true && sphinxAnswer >3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                        Console.WriteLine();
                                    }
                                    else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer <4)
                                    {
                                        Console.Clear();
                                        //Replace the 0 with the roll variable
                                        bool check = f1.CheckAnswer(0, sphinxAnswer);
                                        if(check == true)
                                        {
                                            string reward = f1.GetPowerUpType();
                                            Console.WriteLine("You have chosen wisely!");
                                            fp.PowerUpOrPenalty(reward);
                                            sphinxQuestion3 = false;
                                        }
                                        else
                                        {
                                            string penalty = f1.GetPenalty();
                                            Console.WriteLine("You have chosen poorly!");
                                            fp.PowerUpOrPenalty(penalty);
                                            sphinxQuestion3 = false;
                                        }
                                    }
                                }
                            }

                        }
                        fp.CombatStats(1);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f1.ForestStory(11, 13);

                        bool goblinFight = true;
                        while(goblinFight == true)
                        {
                            Console.Clear();
                            fp.CombatStats(1);
                            int enemyHealth = f1.GetGoblinHealth();
                            int enemyAttack = f1.GetGoblinAttack();
                            Console.WriteLine($"Goblin Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            Console.WriteLine();

                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = fp.combat(1, roll, enemyHealth);

                            f1.SetDamage(damage);
                            enemyHealth = f1.GetGoblinHealth();

                            if(enemyHealth == 0)
                            {
                                goblinFight = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The goblin attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The goblin rolled a {roll}.");
                                int enemyStrike = f1.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    fp.CombatDamage(1, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The goblin missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();  
                                }
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        f1.ForestStory(13, 18);

                        fp.HealthPenalty(10);
                        fp.CombatStats(1);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f1.ForestStory(19, 21);


                        /////////////////////////////////////////
                        //TODO: add the monster section here
                        /////////////////////////////////////////
                        break;
                }

                break;
            //Elf
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
                    //River Path
                    case 1:
                        Console.Clear();
                        Character e2 = new Elf(2);
                        River r2 = new River();
                        r2.RiverStory(0, 3);

                        bool riverCombat3 = true;
                        while(riverCombat3)
                        {
                            Console.Clear();
                            e2.CombatStats(2);
                            int enemyHealth = r2.GetRiverBanditsHealth();
                            int enemyAttack = r2.GetBanditsAttack();
                            Console.WriteLine($"Bandit Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            
                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = e2.combat(3, roll, enemyHealth);
                            
                            r2.SetDamage(damage);
                            enemyHealth = r2.GetRiverBanditsHealth();                       

                            if(enemyHealth == 0)
                            {
                                riverCombat3 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The bandit attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The bandit rolled a {roll}.");
                                int enemyStrike = r2.EnemyAttack(enemyAttack, roll);

                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    e2.CombatDamage(3, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The bandit missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                        }
                        Console.Clear();              
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        r2.RiverStory(4, 7);

                        bool sphinxQuestion2 = true;
                        while(sphinxQuestion2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            
                            string input2 = Console.ReadLine();
                            bool validinput2 = int.TryParse(input2, out int sphinxSelect2);

                            if(validinput2 == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validinput2 == true && sphinxSelect2 <1 || validinput2 == true && sphinxSelect2 >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect2}. Please enter a number between 1 and 2 and try again.");
                            }
                            else if(validinput2 == true && sphinxSelect2 > 0 && sphinxSelect2 < 3)
                            {
                                if(sphinxSelect2 == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion2 = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    
                                    int roll = rollSphinxDie();
                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        Console.Clear();
                                        r2.GetSphinxChallenge(roll);
                                        Console.WriteLine();
                                        Console.Write("Enter your choice: ");
                                        string userChoice = Console.ReadLine();
                                        bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                        if(validUserChoice == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer < 1 || validUserChoice == true && sphinxAnswer >3)
                                        {   
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                        {
                                            Console.Clear();
                                            //Replace the 0 with the roll variable
                                            bool check = r2.CheckAnswer(0, sphinxAnswer);
                                            if(check == true)
                                            {
                                                string reward = r2.GetPowerUpType();
                                                Console.WriteLine("You have chosen wisely!");
                                                e2.PowerUpOrPenalty(reward);
                                                runSphinx = false;
                                            }
                                            else
                                            {
                                                string penalty = r2.GetPenalty();
                                                Console.WriteLine("You have chosen poorly!");
                                                e2.PowerUpOrPenalty(penalty);
                                                runSphinx = false;
                                            }
                                        }
                                    }
                                    e2.CombatStats(2);
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    sphinxQuestion2 = false;
                                }
                            }
                        }
                        r2.RiverStory(8, 10);
                        break;
                    //Mountain Path
                    case 2:
                        Console.Clear();
                        Character me = new Elf(2);
                        Mountain m2 = new Mountain();
                        m2.MountainStory(0, 6);

                        bool sphinxQuestion = true;
                        while(sphinxQuestion == true)
                        {
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int sphinxSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                            }
                            else if(validInput == true && sphinxSelect < 1 || validInput == true && sphinxSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                            }
                            else if(validInput == true && sphinxSelect > 0 || validInput == true && sphinxSelect <3)
                            {
                                if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();

                                    int roll = rollSphinxDie();
                                    bool runSphinx = true;
                                    while(runSphinx== true)
                                    {
                                        Console.Clear();
                                        m2.GetSphinxChallenge(roll);
                                        Console.WriteLine();
                                        Console.Write("Enter your choice: ");
                                        string userChoice = Console.ReadLine();
                                        bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                        if(validUserChoice == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer < 1 || validUserChoice == true && sphinxAnswer >3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                        {
                                            Console.Clear();
                                            //Replace the 0 with the roll variable
                                            bool check = m2.CheckAnswer(0, sphinxAnswer);

                                            if(check == true)
                                            {
                                                string reward = m2.GetPowerUpType();
                                                Console.WriteLine("You have chosen wisely!");
                                                me.PowerUpOrPenalty(reward);
                                                runSphinx = false;
                                            }
                                            else
                                            {
                                                string penalty = m2.GetPenalty();
                                                Console.WriteLine("You have chosen poorly!");
                                                me.PowerUpOrPenalty(penalty);
                                                runSphinx = false;
                                            }
                                        }
                                    }
                                    sphinxQuestion = false;
                                }  
                            }
                        }
                        me.CombatStats(2);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        m2.MountainStory(7, 8);

                        bool trollFight = true;
                        while(trollFight == true)
                        {
                            Console.Clear();
                            me.CombatStats(2);
                            int enemyHealth = m2.GetTrollHealth();
                            int enemyAttack = m2.GetTrollAttack();
                            Console.WriteLine($"Troll Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            Console.WriteLine();

                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = me.combat(2, roll, enemyHealth);
                            
                            m2.SetDamage(damage);
                            enemyHealth = m2.GetTrollHealth();

                            if(enemyHealth == 0)
                            {
                                trollFight = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The troll attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The troll rolled a {roll}.");
                                int enemyStrike = m2.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    me.CombatDamage(2, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The troll missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }

                            }
                        }
                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        m2.MountainStory(9, 11);

                        /////////////////////////////////////////////
                        //TODO: add the monster section here
                        /////////////////////////////////////////////


                        break;
                    //Forest Path
                    case 3:
                        Console.Clear();
                        Character fe = new Elf(2);
                        Forest f2 = new Forest();
                        f2.ForestStory(0, 10);

                        int sphinxRoll = rollSphinxDie();
                        bool sphinxQuestion3 = true;
                        while(sphinxQuestion3 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int sphinxSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && sphinxSelect <1 || validInput == true && sphinxSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && sphinxSelect >0 || validInput == true && sphinxSelect <3)
                            {
                                if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion3 = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();

                                    int roll = rollSphinxDie();
                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        //Replace the 0 with the roll variable
                                        f2.GetSphinxChallenge(0);
                                        Console.WriteLine();
                                        Console.Write("Enter your choice: ");
                                        string userChoice = Console.ReadLine();
                                        bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                        if(validUserChoice == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer < 1 || validUserChoice == true && sphinxAnswer >3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                        {
                                            Console.Clear();
                                            //Replace the 0 with the roll variable
                                            bool check = f2.CheckAnswer(0, sphinxAnswer);
                                            if(check == true)
                                            {
                                                string reward = f2.GetPowerUpType();
                                                Console.WriteLine("You have chosen wisely!");
                                                fe.PowerUpOrPenalty(reward);
                                                runSphinx = false;
                                            }
                                            else
                                            {
                                                string penalty = f2.GetPenalty();
                                                Console.WriteLine("You have chosen poorly!");
                                                fe.PowerUpOrPenalty(penalty);
                                                runSphinx = false;
                                            }
                                        }
                                    }
                                    sphinxQuestion3 = false;
                                }
                            }
                        }
                        fe.CombatStats(2);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f2.ForestStory(11, 13);

                        bool goblinFight = true;
                        while(goblinFight == true)
                        {
                            Console.Clear();
                            fe.CombatStats(2);
                            int enemyHealth = f2.GetGoblinHealth();
                            int enemyAttack = f2.GetGoblinAttack();
                            Console.WriteLine($"Goblin Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            Console.WriteLine();

                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = fe.combat(2, roll, enemyHealth);

                            f2.SetDamage(damage);
                            enemyHealth = f2.GetGoblinHealth();

                            if(enemyHealth == 0)
                            {
                                goblinFight = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The goblin attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The goblin rolled a {roll}.");
                                int enemyStrike = f2.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    fe.CombatDamage(2, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The goblin missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();  
                                }
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f2.ForestStory(13, 18);
                        
                        fe.HealthPenalty(10);
                        fe.CombatStats(2);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f2.ForestStory(19, 21);


                        /////////////////////////////////////////
                        //TODO: add the monster section here
                        /////////////////////////////////////////
                        break;
                }
                break;
            //Wizard
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
                    Character w1 = new Wizard(3);
                    River r3 = new River();
                    r3.RiverStory(0, 3);

                    bool riverCombat3 = true;
                    while(riverCombat3)
                    {
                        Console.Clear();
                        w1.CombatStats(3);
                        int enemyHealth = r3.GetRiverBanditsHealth();
                        int enemyAttack = r3.GetBanditsAttack();
                        Console.WriteLine($"Bandit Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            
                        Console.WriteLine("You must roll a 10 or higher to land a hit...");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to roll the 20 sided die...");
                        Console.ReadKey();

                        int roll = rollDie();
                        Console.WriteLine($"You rolled a {roll}.");
                        int damage = w1.combat(3, roll, enemyHealth);
                            
                        r3.SetDamage(damage);
                        enemyHealth = r3.GetRiverBanditsHealth();                        

                        if(enemyHealth == 0)
                        {
                            riverCombat3 = false;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("The bandit attacks!");
                            Console.WriteLine();
                            roll = rollDie();
                            Console.WriteLine($"The bandit rolled a {roll}.");
                            int enemyStrike = r3.EnemyAttack(enemyAttack, roll);
                            Console.WriteLine();

                            if(enemyStrike >0)
                            {
                                w1.CombatDamage(3, enemyStrike);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("The bandit missed!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                        }

                    }
                    Console.Clear();              
                    Console.WriteLine("You have won the fight!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    r3.RiverStory(4, 7);

                    bool sphinxQuestions3 = true;
                    while(sphinxQuestions3 == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Do you wish to answer the sphinx's questions?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        Console.WriteLine();
                        Console.Write("Enter your selection: ");
                            
                        string input3 = Console.ReadLine();
                        bool validInput3 = int.TryParse(input3, out int sphinxSelect3);

                        if(validInput3 == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                            Console.WriteLine();
                        }
                        else if(validInput3 == true && sphinxSelect3 <1 || validInput3 == true && sphinxSelect3 >2)
                        {
                            Console.Clear();
                            Console.WriteLine($"You entered {sphinxSelect3}. Please enter a number between 1 and 2 and try again.");
                        }
                        else if(validInput3 == true && sphinxSelect3 > 0 && sphinxSelect3 < 3)
                        {
                            if(sphinxSelect3 == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                Console.WriteLine();
                                sphinxQuestions3 = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                    
                                int roll = rollSphinxDie();
                                bool runSphinx = true;
                                while(runSphinx == true)
                                {
                                    Console.Clear();
                                    r3.GetSphinxChallenge(roll);
                                    Console.WriteLine();
                                    Console.Write("Enter your choice: ");
                                    string userChoice = Console.ReadLine();
                                    bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                    if(validUserChoice == false)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid input. Please enter a number and try again.");
                                        Console.WriteLine();
                                    }
                                    else if(validUserChoice == true && sphinxAnswer < 1 || validUserChoice == true && sphinxAnswer >3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                        Console.WriteLine();
                                    }
                                    else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                    {   
                                        Console.Clear();
                                        //Replace the 0 with the roll variable
                                        bool check = r3.CheckAnswer(0, sphinxAnswer);
                                        if(check == true)
                                        {
                                            string reward = r3.GetPowerUpType();
                                            Console.WriteLine("You have chosen wisely!");
                                            w1.PowerUpOrPenalty(reward);
                                            runSphinx = false;
                                        }
                                        else
                                        {
                                            string penalty = r3.GetPenalty();
                                            Console.WriteLine("You have chosen poorly!");
                                            w1.PowerUpOrPenalty(penalty);
                                            runSphinx = false;
                                        }
                                    }
                                }
                                w1.CombatStats(3);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                sphinxQuestions3 = false;
                            }
                        }
                    }
                    r3.RiverStory(8, 10);
                    
                    Monster mon1 = new Monster();
                    mon1.MonsterStory(0, 2);

                    bool towerStory = true;
                    while(towerStory == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Do you enter the tower and fight the monster?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        Console.WriteLine();
                        Console.Write("Enter your selection: ");
                        string input = Console.ReadLine();
                        bool validInput = int.TryParse(input, out int towerSelect);

                        if(validInput == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                            Console.WriteLine();
                        }
                        else if(validInput == true && towerSelect <1 || validInput == true && towerSelect >2)
                        {
                            Console.Clear();
                            Console.WriteLine($"You entered {towerSelect}. Please enter a number between 1 and 2 and try again.");
                            Console.WriteLine();
                        }
                        else if(validInput == true && towerSelect > 0 || validInput == true && towerSelect < 3)
                        {
                            if(towerSelect == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("You have chosen not to enter the tower.");
                                Console.WriteLine();
                                Console.WriteLine("You decided that it is too risky to enter the tower and decide to head home.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.WriteLine();
                                Console.WriteLine("Thank you for playing Hero Quest! See you next time!");
                                Console.WriteLine();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.Clear();
                                //int monsterRoll = rollMonsterDie();
                                mon1.SetMonster();
                                bool monsterFight = true;
                                while(monsterFight == true)
                                {
                                    Console.Clear();
                                    w1.CombatStats(3);
                                    string monsterName = mon1.GetMonsterType();
                                    int monsterHealth = mon1.GetMonsterHealth();
                                    int monsterAttack = mon1.GetMonsterAttack();
                                    string monsterWeapon = mon1.GetMonsterWeapon();
                                    Console.WriteLine($"{monsterName} Stats:\nHealth: {monsterHealth}\nWeapon: {monsterWeapon}\nAttack: {monsterAttack}");

                                    Console.WriteLine();
                                    Console.WriteLine("You must roll a 5 or higher to land a hit...");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to roll the 20 sided die...");
                                    Console.ReadKey();
                                    int roll = rollDie();
                                    Console.WriteLine($"You rolled a {roll}.");

                                    int damage = w1.CombatWithMonster(roll, 3);

                                    if(damage > 0)
                                    {
                                        mon1.SetMonsterDamage(damage);
                                    }

                                    monsterHealth = mon1.GetMonsterHealth();

                                    if(monsterHealth == 0)
                                    {
                                        monsterFight = false;
                                        towerStory = false;
                                    }
                                    else
                                    {
                                        roll = rollDie();
                                        int monsterStrike = mon1.MonsterCombat(roll);
                                        Console.WriteLine();

                                        if(monsterStrike >0)
                                        {
                                            w1.CombatDamage(3, monsterStrike);
                                        }
                                    }

                                }
                            }
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("You have won the fight!");
                    Console.WriteLine();
                    w1.CombatStats(3);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    mon1.MonsterStory(3, 5);
                    Console.WriteLine();
                    Console.WriteLine("Thank you for playing Hero Quest! See you next time!");
                    Console.WriteLine();
                    Environment.Exit(0);

                    break;
                    //Mountain Path
                    case 2:
                        Console.Clear();
                        Character mw = new Wizard(3);
                        Mountain m3 = new Mountain();
                        m3.MountainStory(0, 6);

                        bool sphinxQuestion = true;
                        while(sphinxQuestion == true)
                        {
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int sphinxSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                            }
                            else if(validInput == true && sphinxSelect < 1 || validInput == true && sphinxSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                            }
                            else if(validInput == true && sphinxSelect > 0 || validInput == true && sphinxSelect <3)
                            {
                                if(sphinxSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();

                                    int roll = rollSphinxDie();
                                    bool runSphinx = true;
                                    while(runSphinx == true)
                                    {
                                        Console.Clear();
                                        m3.GetSphinxChallenge(roll);
                                        Console.WriteLine();
                                        Console.Write("Enter your choice: ");
                                        string userChoice = Console.ReadLine();
                                        bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                        if(validUserChoice == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a number and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer <1 || validUserChoice == true && sphinxAnswer >3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                            Console.WriteLine();
                                        }
                                        else if(validUserChoice == true && sphinxAnswer >0 || validUserChoice == true && sphinxAnswer < 4)
                                        {
                                            Console.Clear();
                                            //Replace the 0 with the roll variable
                                            bool check = m3.CheckAnswer(0, sphinxAnswer);

                                            if(check == true)
                                            {
                                                string reward = m3.GetPowerUpType();
                                                Console.WriteLine("You have chosen wisely!");
                                                mw.PowerUpOrPenalty(reward);
                                                runSphinx = false;
                                            }
                                            else
                                            {
                                                string penalty = m3.GetPenalty();
                                                Console.WriteLine("You have chosen poorly!");
                                                mw.PowerUpOrPenalty(penalty);
                                                runSphinx = false;
                                            }
                                        }
                                    }

                                    sphinxQuestion = false;
                                }  
                            }
                        }

                        mw.CombatStats(3);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        m3.MountainStory(7, 8);

                        bool trollFight = true;
                        while(trollFight == true)
                        {
                            Console.Clear();
                            mw.CombatStats(3);
                            int enemyHealth = m3.GetTrollHealth();
                            int enemyAttack = m3.GetTrollAttack();
                            Console.WriteLine($"Troll Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            Console.WriteLine();

                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = mw.combat(3, roll, enemyHealth);

                            m3.SetDamage(damage);
                            enemyHealth = m3.GetTrollHealth();

                            if(enemyHealth == 0)
                            {
                                trollFight = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The troll attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The troll rolled a {roll}.");
                                int enemyStrike = m3.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    mw.CombatDamage(3, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The troll missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }

                            }
                        }

                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        m3.MountainStory(9, 11);

                        Monster mon2 = new Monster();
                        mon2.MonsterStory(0, 2);

                        bool towerStory2 = true;
                        while(towerStory2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you enter the tower and fight the monster?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int towerSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && towerSelect <1 || validInput == true && towerSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {towerSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && towerSelect >0 || validInput == true && towerSelect <3)
                            {
                                if(towerSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to enter the tower.");
                                    Console.WriteLine();
                                    Console.WriteLine("You decided that it is too risky to enter the tower and decide to head home.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    Console.WriteLine();
                                    Console.WriteLine("Thank you for playing Hero Quest! See you next time!");
                                    Console.WriteLine();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    mon2.SetMonster();
                                    bool monsterFight = true;
                                    while(monsterFight == true)
                                    {
                                        Console.Clear();
                                        mw.CombatStats(3);
                                        string monsterName = mon2.GetMonsterType();
                                        int monsterHealth = mon2.GetMonsterHealth();
                                        int monsterAttack = mon2.GetMonsterAttack();
                                        string monsterWeapon = mon2.GetMonsterWeapon();
                                        Console.WriteLine($"{monsterName} Stats:\nHealth: {monsterHealth}\nWeapon: {monsterWeapon}\nAttack: {monsterAttack}");

                                        Console.WriteLine();
                                        Console.WriteLine("You must roll a 5 or higher to land a hit...");
                                        Console.WriteLine();
                                        Console.WriteLine("Press any key to roll the 20 sided die...");
                                        Console.ReadKey();
                                        int roll = rollDie();
                                        Console.WriteLine($"You rolled a {roll}.");

                                        int damage = mw.CombatWithMonster(roll, 3);

                                        if(damage > 0)
                                        {
                                            mon2.SetMonsterDamage(damage);
                                        }

                                        monsterHealth = mon2.GetMonsterHealth();

                                        if(monsterHealth == 0)
                                        {
                                            monsterFight = false;
                                            towerStory2 = false;
                                        }
                                        else
                                        {
                                            roll = rollDie();
                                            int monsterStrike = mon2.MonsterCombat(roll);
                                            Console.WriteLine();

                                            if(monsterStrike > 0)
                                            {
                                                mw.CombatDamage(3, monsterStrike);
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        mw.CombatStats(3);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        mon2.MonsterStory(3, 5);
                        Console.WriteLine();
                        Console.WriteLine("Thank you for playing Hero Quest! See you next time!");
                        Console.WriteLine();
                        Environment.Exit(0);

                        break;
                    //Forest Path
                    case 3:
                        Console.Clear();
                        Character fw = new Wizard(3);
                        Forest f3 = new Forest();
                        f3.ForestStory(0, 10);

                        int sphinxRoll = rollSphinxDie();
                        bool sphinxQuestion3 = true;
                        while(sphinxQuestion3 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you wish to answer the sphinx's questions?");
                            Console.WriteLine();
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int sphinxSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && sphinxSelect <1 || validInput == true && sphinxSelect > 2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {sphinxSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && sphinxSelect >0 || validInput == true && sphinxSelect <3)
                            {
                                Console.Clear();
                                if(sphinxSelect == 2)
                                {
                                    Console.WriteLine("You have chosen not to answer the sphinx's questions.");
                                    Console.WriteLine();
                                    sphinxQuestion3 = false;
                                }
                                else
                                {
                                    //Replace the 0 with the roll variable
                                    f3.GetSphinxChallenge(0);
                                    Console.WriteLine();
                                    Console.Write("Enter your choice: ");
                                    string userChoice = Console.ReadLine();
                                    bool validUserChoice = int.TryParse(userChoice, out int sphinxAnswer);

                                    if(validUserChoice == false)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid input. Please enter a number and try again.");
                                        Console.WriteLine();
                                    }
                                    else if(validUserChoice == true && sphinxAnswer <1 || validUserChoice == true && sphinxAnswer >3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"You entered {sphinxAnswer}. Please enter a number between 1 and 3 and try again.");
                                        Console.WriteLine();
                                    }
                                    else if(validUserChoice == true && sphinxAnswer >0 ||validUserChoice == true && sphinxAnswer < 4)
                                    {
                                        Console.Clear();
                                        //Replace the 0 with the roll variable
                                        bool check = f3.CheckAnswer(0, sphinxAnswer);
                                        if(check == true)
                                        {
                                            string reward = f3.GetPowerUpType();
                                            Console.WriteLine("You have chosen wisely!");
                                            fw.PowerUpOrPenalty(reward);
                                            sphinxQuestion3 = false;
                                        }
                                        else
                                        {
                                            string penalty = f3.GetPenalty();
                                            Console.WriteLine("You have chosen poorly!");
                                            fw.PowerUpOrPenalty(penalty);
                                            sphinxQuestion3 = false;
                                        }
                                    }
                                }
                            }
                        }
                        fw.CombatStats(3);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f3.ForestStory(11, 13);

                        bool goblinFight = true;
                        while(goblinFight == true)
                        {
                            Console.Clear();
                            fw.CombatStats(3);
                            int enemyHealth = f3.GetGoblinHealth();
                            int enemyAttack = f3.GetGoblinAttack();
                            Console.WriteLine($"Goblin Stats:\nHealth: {enemyHealth}\nAttack: {enemyAttack}");
                            Console.WriteLine();

                            Console.WriteLine("You must roll a 10 or higher to land a hit...");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to roll the 20 sided die...");
                            Console.ReadKey();

                            int roll = rollDie();
                            Console.WriteLine($"You rolled a {roll}.");
                            int damage = fw.combat(3, roll, enemyHealth);

                            f3.SetDamage(damage);
                            enemyHealth = f3.GetGoblinHealth();

                            if(enemyHealth == 0)
                            {
                                goblinFight = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The goblin attacks!");
                                Console.WriteLine();
                                roll = rollDie();
                                Console.WriteLine($"The goblin rolled a {roll}.");
                                int enemyStrike = f3.EnemyAttack(enemyAttack, roll);
                                Console.WriteLine();

                                if(enemyStrike >0)
                                {
                                    fw.CombatDamage(3, enemyStrike);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("The goblin missed!");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();  
                                }
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f3.ForestStory(13, 18);

                        fw.HealthPenalty(10);
                        fw.CombatStats(3);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        f3.ForestStory(19, 21);

                        Monster mon3 = new Monster();
                        mon3.MonsterStory(0, 2);

                        bool towerStory3 = true;
                        while(towerStory3 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you enter the tower and fight the monster?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            Console.WriteLine();
                            Console.Write("Enter your selection: ");
                            string input = Console.ReadLine();
                            bool validInput = int.TryParse(input, out int towerSelect);

                            if(validInput == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && towerSelect <1 || validInput == true && towerSelect >2)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {towerSelect}. Please enter a number between 1 and 2 and try again.");
                                Console.WriteLine();
                            }
                            else if(validInput == true && towerSelect > 0 || validInput == true && towerSelect < 3)
                            {
                                if(towerSelect == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have chosen not to enter the tower.");
                                    Console.WriteLine();
                                    Console.WriteLine("You decided that it is too risky to enter the tower and decide to head home.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    Console.WriteLine();
                                    Console.WriteLine("Thank you for playing Hero Quest! See you next time!");
                                    Console.WriteLine();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    mon3.SetMonster();
                                    bool monsterFight = true;
                                    while(monsterFight == true)
                                    {
                                        Console.Clear();
                                        fw.CombatStats(3);
                                        string monsterName = mon3.GetMonsterType();
                                        int monsterHealth = mon3.GetMonsterHealth();
                                        int monsterAttack = mon3.GetMonsterAttack();
                                        string monsterWeapon = mon3.GetMonsterWeapon();
                                        Console.WriteLine($"{monsterName} Stats:\nHealth: {monsterHealth}\nWeapon: {monsterWeapon}\nAttack: {monsterAttack}");

                                        Console.WriteLine();
                                        Console.WriteLine("You must roll a 5 or higher to land a hit...");
                                        Console.WriteLine();
                                        Console.WriteLine("Press any key to roll the 20 sided die...");
                                        Console.ReadKey();
                                        int roll = rollDie();
                                        Console.WriteLine($"You rolled a {roll}.");

                                        int damage = fw.CombatWithMonster(roll, 3);

                                        if(damage > 0)
                                        {
                                            mon3.SetMonsterDamage(damage);
                                        }

                                        monsterHealth = mon3.GetMonsterHealth();

                                        if(monsterHealth == 0)
                                        {
                                            monsterFight = false;
                                            towerStory3 = false;
                                        }
                                        else
                                        {
                                            roll = rollDie();
                                            int monsterStrike = mon3.MonsterCombat(roll);
                                            Console.WriteLine();

                                            if(monsterStrike >0)
                                            {
                                                fw.CombatDamage(3, monsterStrike);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("You have won the fight!");
                        Console.WriteLine();
                        fw.CombatStats(3);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        mon3.MonsterStory(3, 5);
                        Console.WriteLine();
                        Console.WriteLine("Thank you for playing Hero Quest! See you next time!");
                        Console.WriteLine();
                        Environment.Exit(0);
                        
                        break;
                }
                    break;
        }
    }
}
 