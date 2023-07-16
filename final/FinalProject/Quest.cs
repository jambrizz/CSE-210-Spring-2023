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
                        break;
                    //Forest Path
                    case 3:
                        break;
                }

                break;
            //Elf
            case 2:
                Console.Clear();
                Console.WriteLine("You have selected the Wizard as your character.");
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

                        break;
                    //Forest Path
                    case 3:
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
                    /////////////////////////////////////////////////////////
                    //TODO: add the monster section here
                    /////////////////////////////////////////////////////////
                    break;
                    //Mountain Path
                    case 2:

                        break;
                    //Forest Path
                    case 3:

                        break;
                }
                    break;
        }
    }
}
 