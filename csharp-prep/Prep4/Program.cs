using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        bool runProgram = true;
        do
        {
           Console.Write("Enter a number: ");
           bool isNumber = int.TryParse(Console.ReadLine(), out int number);

           if(isNumber == false)
           {
                Console.Write("Invalid input, please enter a number: ");
                isNumber = int.TryParse(Console.ReadLine(), out number);
           } 

           if(number == 0)
           {
                runProgram = false;
                int sum = numbers.Sum();
                double average = numbers.Average();
                int max = numbers.Max();
                Console.WriteLine($"The sum of the numbers is {sum}");
                Console.WriteLine($"The average of the numbers is {average}");
                Console.WriteLine($"The max of the numbers is {max}");
           }
           else
           {
                numbers.Add(number);
           }
        }
        while(runProgram == true);
        
    }
}