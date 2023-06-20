using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int selection = 0;
        bool validChoice = false;
        while(validChoice == false)
        {
            Files files = new Files("menu.txt");
            files.DisplayMenuFile();
            Console.WriteLine("Please select an option:");
            Console.Write("> ");
            string menuChoice = Console.ReadLine();
            bool choice = int.TryParse(menuChoice, out int menuChoiceInt);
            if(choice == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
            else if(choice == true && menuChoiceInt > 6 || choice == true && menuChoiceInt < 1)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"You selected {menuChoiceInt}, which is not a valid selection. Please try again.");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                selection = menuChoiceInt;
                validChoice = true;
            }
        }

        switch(selection)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("You have selected to create a new goal.");
                Console.WriteLine();
                Environment.Exit(0);
            break;
            case 2:
                Console.Clear();
                Console.WriteLine("You have selected to list all your goals.");
                Console.WriteLine();
                Environment.Exit(0);
            break;
            case 3:
                Console.Clear();
                Console.WriteLine("You have selected to save goals.");
                Console.WriteLine();
                Environment.Exit(0);
            break;
            case 4:
                Console.Clear();
                Console.WriteLine("You have selected to load goals.");
                Console.WriteLine();
                Environment.Exit(0);
            break;
            case 5:
                Console.Clear();
                Console.WriteLine("You have selected to record an event.");
                Console.WriteLine();
                Environment.Exit(0);
            break;
            case 6:
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Eternal Quest Program! See you next time!");
                Console.WriteLine();
                Environment.Exit(0);
            break;
            default:
            break;
        }
    }
}