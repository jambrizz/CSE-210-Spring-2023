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

    public void SphinxRiddle()
    {
        Random r = new Random();
        int number = r.Next(0, 2);
        Console.WriteLine(_sphinxRiddles[number]);
        Console.WriteLine();

        if(number == 0)
        {
            int selection = 0;
            bool runRiddle = true;
            while(runRiddle == true)
            {
                Console.WriteLine("1. " + _sphinxRiddle1[0]);
                Console.WriteLine("2. " + _sphinxRiddle1[1]);
                Console.WriteLine("3. " + _sphinxRiddle1[2]);
                Console.WriteLine();
                Console.WriteLine("Enter your answer: ");
                string answer = Console.ReadLine();

                bool isNumber = int.TryParse(answer, out int numberAnswer);
                if(isNumber == false)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number");
                    Console.WriteLine();
                }
                else if(isNumber == true && numberAnswer < 1 || isNumber == true && numberAnswer > 3)
                {
                    Console.Clear();
                    Console.WriteLine($"You entered {numberAnswer}. Please enter a number between 1 and 3");
                    Console.WriteLine();
                }
                else
                {
                    runRiddle = false;
                    selection = numberAnswer - 1;
                }
            }
            ///////////////////////////////////////////////////
            //TODO: This is where I left off. Finish the if statements for the riddle bellow and then add the code for other two riddles.
            ///////////////////////////////////////////////////
            if(selection == 1)
            {
                //TODO: Test this code
                Console.Clear();
                Console.WriteLine(_sphinxRiddle1[selection] + " is the correct answer!");
            }
            else
            {
                //TODO: Test this code
                Console.Clear();
                Console.WriteLine(_sphinxRiddle1[selection] + " is the wrong answer!");
            }

        }
        else if(number == 1)
        {
            Console.WriteLine("1. " + _sphinxRiddle2[0]);
            Console.WriteLine("2. " + _sphinxRiddle2[1]);
            Console.WriteLine("3. " + _sphinxRiddle2[2]);
        }
        else if (number == 2)
        {
            Console.WriteLine("1. " + _sphinxRiddle3[0]);
            Console.WriteLine("2. " + _sphinxRiddle3[1]);
            Console.WriteLine("3. " + _sphinxRiddle3[2]);

        }
        
    }

    

    
}