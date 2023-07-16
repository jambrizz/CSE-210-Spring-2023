using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Journey
{
    private string powerUpType;

    private int powerUpAmount;

    private int _questionsCount;

    private List<string> _sphinxRiddles = new List<string>()
    {
        "This thing all things devours: \nBirds, beasts, trees, flowers; \nGnaws iron, bites steel; \nGrinds hard stones to meal; \nSlays king, ruins town, And beats high mountain down.",
        "What can run but never walks, \nHas a mouth but never talks, \nHas a head but never weeps, \nHas a bed but never sleeps?",
        "What can bring back the dead; \nMake you cry, make you laugh, make you young; \nIs born in an instant, \nYet lasts a life time?",
    };

    private List<string> _sphinxRiddle1 = new List<string>()
    {
        "Man",
        "Time",
        "Lion"
    };

    private List<string> _sphinxRiddle2 = new List<string>()
    {
        "A River",
        "Wind Gust",
        "Roaring Fire"
    };

    private List<string> _sphinxRiddle3 = new List<string>()
    {
        "Genie's wish",
        "Memory",
        "Magic spell"
    };

    List<string> _powerUps = new List<string>()
    {
        "Health",
        "Attack",
        "Defense"
    };

    List<int> _powerUpAmounts = new List<int>()
    {
        30,
        15,
        25
    };

    public void GetSphinxChallenge(int sphinxNumm)
    {
        //Console.WriteLine($"Sphinx Roll {sphinxNumm}");
        int sphinxNum = 0;
        if(sphinxNum == 0)
        {
            //switch 0 for sphinxNum
            string riddle = GetSphinxRiddle(0);
            Console.WriteLine(riddle);
            Console.WriteLine();
            Console.WriteLine("Your options:");
            GetSphinxOptions(0);
        }
        else if(sphinxNum == 1)
        {

        }
        else if(sphinxNum == 2)
        {

        }
        else
        {
            Console.WriteLine("Error");
        }
    }

    private string GetSphinxRiddle(int number)
    {
        //Console.Clear();
        string riddle = _sphinxRiddles[number];
        return riddle;
    }

    private void GetSphinxOptions(int number)
    {
        if(number == 0)
        {
            int count = 1;
            foreach(string option in _sphinxRiddle1)
            {
                Console.WriteLine(count + ". " + option);
                count++;
            }
        }
        else if(number == 1)
        {
            int count = 1;
            foreach(string option in _sphinxRiddle2)
            {
                Console.WriteLine(count + ". " + option);
                count++;
            }
        }
        else if (number == 2)
        {
            int count = 1;
            foreach (string option in _sphinxRiddle3)
            {
                Console.WriteLine(count + ". " + option);
                count++;
            }

        }
    }

    public bool CheckAnswer(int riddle, int selection)
    {
        int answer = selection - 1;
        bool check;
        if(riddle == 0)
        {
            if(answer == 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }
        else if(riddle == 1)
        {
            if(answer == 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }
        else if(riddle == 2)
        {
            if(answer == 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }
        else
        {
            check = false;
        }
        return check;
    }

    public string GetPowerUpType()
    {
        string powerUpType = "";
        Random random = new Random();
        int index = random.Next(0, 2);
        string type = _powerUps[index];
        index = random.Next(0, 2);
        int amount = _powerUpAmounts[index];
        powerUpType = type + "|" + amount;
        return powerUpType;
    }

    public string GetPenalty()
    {
        string penalty = "";
        Random random = new Random();
        int index = random.Next(0, 2);
        string amount = _powerUpAmounts[index].ToString();
        penalty = "Penalty|" + amount;
        return penalty;
    }

    public int EnemyAttack(int enemyAttack, int rolledNumber)
    {
        int damage = 0;
        if(rolledNumber <10)
        {
            Console.WriteLine();
            Console.WriteLine("The enemy missed!");
            Console.WriteLine();
        }
        else if(rolledNumber >= 10 && rolledNumber <=20)
        {
            Console.WriteLine();
            Console.WriteLine("The enemy landed a hit!");
            Console.WriteLine();
            damage = enemyAttack;
        }

        return damage;
    }

}