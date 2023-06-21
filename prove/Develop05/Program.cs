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
            //Console.Clear();
            int selection = 0;
            bool validChoice = false;
            while(validChoice == false)
            {
                QuestProgram qP = new QuestProgram();
                qP.DisplayScore();
                Console.WriteLine();
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
                    int goalSelection = 0;
                    bool validGoalChoice = false;
                    while(validGoalChoice == false)
                    {
                        Files f1 = new Files("creategoal.txt");
                        f1.DisplayMenuFile();
                        Console.WriteLine("Which type of goal would you like to create? ");
                        string goalChoice = Console.ReadLine();
                        bool choice = int.TryParse(goalChoice, out int goalChoiceInt);
                        if(choice == false)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.WriteLine();
                        }
                        else if(choice == true && goalChoiceInt > 3 || choice == true && goalChoiceInt < 1)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"You selected {goalChoiceInt}, which is not a valid selection. Please try again.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Clear();
                            goalSelection = goalChoiceInt;
                            validGoalChoice = true;
                        }
                    }
                    switch(goalSelection)
                    {
                        case 1:
                            Console.Clear();
                            //int points = 0;
                            bool validPoints = false;
                            while(validPoints == false)
                            {
                                Console.WriteLine("What is the name of your goal? ");
                                string name = Console.ReadLine();
                                Console.WriteLine("What is a short description of your goal? ");
                                string description = Console.ReadLine();
                                Console.WriteLine("What is the amount of points this goal is worth? ");
                                string userPoints = Console.ReadLine();
                                bool userNumber = int.TryParse(userPoints, out int userPointsInt);
                                if(userNumber == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You entered an invalid number for the amount of points. Please try again.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    //points = userPointsInt;
                                    QuestProgram qP1 = new QuestProgram();
                                    qP1.CreateSimpleGoal(name, description, userPointsInt, "Simple");
                                    validPoints = true;
                                }
                            }
                        
                        break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You have selected to create an Eternal goal.");
                        break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You have selected to create a Checklist goal.");
                        break;
                        default:
                        break;
                    }
                    //Environment.Exit(0);
                break;
                case 2:
                    
                    QuestProgram qP2 = new QuestProgram();
                    qP2.DisplayGoals();
                    Console.WriteLine();
                    //Environment.Exit(0);
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
        while (runProgram == true);
    }
}