using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Menu
{
    public void App()
    {
        PromptHandler prompt = new PromptHandler();
        Entry entry = new Entry();
        Journal journal = new Journal();

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
            Console.Write("What would you like to do? ");
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
                Console.Write("What would you like to do? ");
                userChoice = Console.ReadLine();

                userChoiceBool = int.TryParse(userChoice, out FeatureChoice);

            }

            switch(FeatureChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine();
                    prompt.GetPrompt();
                    string question = prompt.LoadPrompt();
                    Console.WriteLine(question);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    entry.SetEntry(question, response);
                    string journalEntry = entry.DisplayEntry();
                    journal.AddEntry(journalEntry);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("What is the name of the file you would like to load?");
                    Console.Write("> ");
                    string fileName = Console.ReadLine() + ".txt";
                    bool doesFileExist = journal.LoadJournal(fileName);
                    if (doesFileExist == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("That file does not exist.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("File loaded successfully.");
                    }
                    break;
                case 4:
                    Console.WriteLine();
                    bool saveFile = journal.SaveJournal();
                    if (saveFile == true)
                    {
                      journal.ClearList();
                    }
                    break;
                case 5:
                    Console.WriteLine();
                    bool checkListStatus = journal.IsListEmpty();
                    if(checkListStatus == false)
                    {
                        Console.WriteLine("You have unsaved entries. Are you sure you want to quit? (y/n)");
                        Console.Write("> ");
                        string quitChoice = Console.ReadLine().ToLower();
                        if(quitChoice == "y")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Goodbye!");
                            runProgram = false;
                        }
                        else if(quitChoice == "n")
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Please select option 4 to save your journal entries:");
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid input. Please try again.");
                            Console.WriteLine();
                            Console.WriteLine("You have unsaved entries. Are you sure you want to quit? (y/n)");
                            Console.Write("> ");
                            quitChoice = Console.ReadLine().ToLower();
                            if(quitChoice == "y")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Goodbye!");
                                runProgram = false;
                            }
                            else if(quitChoice == "n")
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Please select option 4 to save your journal entries:");
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Goodbye!");
                        runProgram = false;
                    }
                    break;
            }
        }
        while(runProgram == true);
    }
}