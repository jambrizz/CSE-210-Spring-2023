using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        bool runProgram = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to your Journal App!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Write Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Load Entries");
            Console.WriteLine("4. Save Entries");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            string userChoice = Console.ReadLine();

            bool userChoiceBool = int.TryParse(userChoice, out int FeatureChoice);

            if (userChoiceBool == false)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Write Entry");
                Console.WriteLine("2. Display Entries");
                Console.WriteLine("3. Load Entries");
                Console.WriteLine("4. Save Entries");
                Console.WriteLine("5. Quit");
                Console.WriteLine("What would you like to do?");
                userChoice = Console.ReadLine();

                userChoiceBool = int.TryParse(userChoice, out FeatureChoice);

            }

            switch(FeatureChoice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Journal Entry:");
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Display Entries:");
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Load Entries:");
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Save Entries:");
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("Quit:");
                    runProgram = false;
                    break;
            }
        }
        while(runProgram == true);
    }
}