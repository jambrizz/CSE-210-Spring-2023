using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int magicNumber = new Random().Next(1, 100);
        Console.WriteLine($"{magicNumber}");
        Console.WriteLine();

        bool keepGuessing = true;

        do
        {
            int count = 0;
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            bool isNumber = int.TryParse(guess, out int guessNumber);

            if (isNumber == false)
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                Console.WriteLine();
                Console.Write("What is your guess? ");
                guess = Console.ReadLine();
                isNumber = int.TryParse(guess, out guessNumber);
            }

            if (guessNumber < magicNumber)
            {
                Console.WriteLine("Higher!");
                count++;
            }
            else if (guessNumber > magicNumber)
            {
                Console.WriteLine("Lower!");
                count++;
            }
            else
            {
                Console.WriteLine("You got it!");
                count++;
                ///////////TODO fix the count issue//////////////////
                if(count == 1)
                {
                    Console.WriteLine($"It took you {count} guess.");
                }
                else
                {
                    Console.WriteLine($"It took you {count} guesses.");
                }
                Console.WriteLine();
                Console.Write("Would you like to play again? (y/n) ");
                string playAgain = Console.ReadLine();
                if (playAgain == "y" || playAgain == "Y")
                {
                    Console.Clear();
                    magicNumber = new Random().Next(1, 100);
                    Console.WriteLine($"{magicNumber}");
                    Console.WriteLine();
                }
                else if(playAgain == "n" || playAgain == "N")
                {
                    keepGuessing = false;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter y or n.");
                    Console.WriteLine();
                    Console.Write("Would you like to play again? (y/n) ");
                    playAgain = Console.ReadLine();
                    if (playAgain == "y" || playAgain == "Y")
                    {
                        Console.Clear();
                        magicNumber = new Random().Next(1, 100);
                        Console.WriteLine($"{magicNumber}");
                        Console.WriteLine();
                    }
                    else if (playAgain == "n" || playAgain == "N")
                    {
                        keepGuessing = false;
                    }
                }
            }
        }
        while (keepGuessing == true);
        
    }
}