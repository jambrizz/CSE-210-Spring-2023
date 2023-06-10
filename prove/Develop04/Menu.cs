using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
                    int time = 0;
                    bool runBreathing1 = false;
                    Breathing breathing = new Breathing();
                    breathing.SetActivityName("Breathing");
                    while (runBreathing1 == false)
                    {
                        Console.Clear();
                        Console.WriteLine(breathing.DisplayStartingMessage());
                        Console.WriteLine();
                        Console.WriteLine(breathing.GetActivityDescription());
                        Console.WriteLine();
                        Console.Write("How long, in seconds, would you like for your session to last?:> ");
                        string timeChoice = Console.ReadLine();
                        bool validTime = int.TryParse(timeChoice, out int timeChoiceInt);
                        if (validTime == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number.");
                            Console.WriteLine();
                        }
                        else if (validTime == true && timeChoiceInt < 8)
                        {
                            Console.Clear();
                            Console.WriteLine($"You selected {timeChoiceInt} seconds, which is too short. Please enter at least 8 seconds or more.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Clear();
                            time = timeChoiceInt;
                            runBreathing1 = true;
                        }
                    }
                    Activity activity2 = new Activity(time);
                    activity2.GetReady();
                    Breathing breathing2 = new Breathing();
                    breathing2.DisplayBreathingExcercise(time, 4);

                    //Possibly remove the Environment.Exit(0) and replace with a return to menu option
                    Environment.Exit(0);
                    break;
                case 2:
                    Console.Clear();
                    int time2 = 0;
                    bool runReflecting = false;
                    Reflecting reflecting = new Reflecting();
                    reflecting.SetActivityName("Reflecting");
                    while (runReflecting == false)
                    {
                        Console.WriteLine(reflecting.DisplayStartingMessage());
                        Console.WriteLine();
                        Console.WriteLine(reflecting.GetDescription());
                        Console.WriteLine();
                        Console.Write("How long, in seconds, would you like for your session to last?:> "); 
                        string timeChoice = Console.ReadLine();
                        bool validTime = int.TryParse(timeChoice, out int timeChoiceInt);
            
                        if (validTime == false)
                        {
                            Console.Clear();
                            Console.WriteLine("<===============><===============>");
                            Console.WriteLine("Please enter a valid number.");
                            Console.WriteLine("<===============><===============>");
                            Console.WriteLine();
                        }
                        else if (validTime == true && timeChoiceInt < 10)
                        {
                            Console.Clear();
                            Console.WriteLine("<===============><===============><===============><===============><===============><===============>");
                            Console.WriteLine($"You selected {timeChoiceInt} seconds, which is not enough time to reflect. Please enter at least 10 seconds or more.");
                            Console.WriteLine("<===============><===============><===============><===============><===============><===============>");
                            Console.WriteLine();
                        }
                        else if (validTime == true && timeChoiceInt > 160)
                        {
                            Console.Clear();
                            Console.WriteLine("<===============><===============><===============><===============><===============><===============>");
                            Console.WriteLine($"You selected {timeChoiceInt} seconds, which is too much time for this activity. Please enter 160 seconds or less.");
                            Console.WriteLine("<===============><===============><===============><===============><===============><===============>");
                            Console.WriteLine();
                        }
                        else
                        {
                            time2 = timeChoiceInt;
                            runReflecting = true;
                        } 
                    }
                    Console.Clear();
                    Reflecting reflecting2 = new Reflecting();
                    reflecting2.RandomQuestion(time2);
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