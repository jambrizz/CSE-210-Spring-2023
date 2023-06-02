using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Menu
{
    public void App()
    {
        bool runProgram = true;
        do
        {
            int selection = 0;
            bool validChoice = false;
            while(validChoice == false)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Start Breathing Activity");
                Console.WriteLine("2. Start Reflecting Activity");
                Console.WriteLine("3. Start Listing Activity");
                Console.WriteLine("4. Quit App");
                Console.WriteLine("Select a choice from the menu:");
                Console.Write(">: ");
                string menuChoice = Console.ReadLine();
                validChoice = int.TryParse(menuChoice, out int menuChoiceInt);

                if (validChoice == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                else if (validChoice == true && menuChoiceInt > 4)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You selected {menuChoiceInt}, which is not a valid selection. Please try again.");
                }
                else
                {
                    selection = menuChoiceInt;
                }
            }

            switch (selection)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Starting Breathing Activity...");
                    Environment.Exit(0);
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Starting Reflecting Activity...");
                    Environment.Exit(0);
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Starting Listing Activity...");
                    Environment.Exit(0);
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness App! See you next time!");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        } 
        while (runProgram == true);
    }
}