using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("What is your First Name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is yout Last Name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");

    }
}