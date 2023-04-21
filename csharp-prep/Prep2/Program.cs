using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("What was your percentage grade? ");
        string input = Console.ReadLine();
        bool inputAInt = int.TryParse(input, out int grade);

        if(inputAInt == false)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a valid number.");
            input = Console.ReadLine();
            inputAInt = int.TryParse(input, out grade);
        }

        string letter = "";

        if(grade >= 90)
        {
            letter = "A";
        }
        else if(grade >= 80 && grade < 90)
        {
            letter = "B";
        }
        else if(grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if(grade >= 60 && grade < 70)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}.");

        if(grade >= 70)
        {
            Console.WriteLine();
            Console.WriteLine("Congrats! You passed the course!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, you did not pass the course.");
            Console.WriteLine("Better luck next time!");
        }
    }
}