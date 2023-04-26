using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int magicNumber = new Random().Next(1, 100);
        Console.WriteLine();
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        bool keepGuessing = true;
        int count = 0;

        do
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            bool isNumber = int.TryParse(guess, out int guessNumber);
            count++;

            if (isNumber == false)
            {
                Console.WriteLine();
                Console.Write("That is not a number! Try again.");
                guess = Console.ReadLine();
                isNumber = int.TryParse(guess, out guessNumber);
            }

            if(guessNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if(guessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it!");
                if(count == 1)
                {
                    Console.WriteLine($"It took you {count} guess.");
                }
                else
                {
                    Console.WriteLine($"It took you {count} guesses.");
                }
                //keepGuessing = false;
                Console.WriteLine();
                Console.WriteLine("Do you want to keep playing? (y/n)");
                string answer = Console.ReadLine().ToLower();

                if(answer == "n")
                {
                    keepGuessing = false;
                    Console.WriteLine("Thank you for playing! Goodbye.");
                }
                else if(answer == "y")
                {
                    Console.Clear();
                    count = 0;
                    magicNumber = new Random().Next(1, 100);
                    Console.WriteLine("I'm thinking of a number between 1 and 100.");
                }
                else
                {
                    Console.WriteLine("That is not a valid answer. Please type 'y' for yes or 'n' for no.");
                    answer = Console.ReadLine().ToLower();
                }
            } 
        }
        while (keepGuessing == true);
        
    }
}