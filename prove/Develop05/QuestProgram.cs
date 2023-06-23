using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class QuestProgram
{
    public List<string> _goals = new List<string>();

    private int _score = 0;

    public void CreateChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, string type)
    {
        Checklist checklist = new Checklist(name, description, points, targetCount, bonusPoints, type);
        string goal = checklist.RecordGoal();
        int length = _goals.Count;
        if(length == 0)
        {
            _goals.Add("TotalScore:0");
            _goals.Add(goal);
        }
        else
        {
            _goals.Add(goal);
        }
    }

    public void CreateEternalGoal(string name, string description, int points, string type)
    {
        Eternal eternal = new Eternal(name, description, points, type);
        string goal = eternal.RecordGoal();
        int length = _goals.Count;
        if(length == 0)
        {
            _goals.Add("TotalScore:0");
            _goals.Add(goal);
        }
        else
        {
            _goals.Add(goal);
        }
    }
    
    public void CreateSimpleGoal(string name, string description, int points, string type)
    {
        Simple simple = new Simple(name, description, points, type);
        string goal = simple.RecordGoal();
        int length = _goals.Count;
        if(length == 0)
        {
            _goals.Add("TotalScore:0");
            _goals.Add(goal);
        }
        else
        {
            _goals.Add(goal);
        }
        int length2 = _goals.Count;
    }

    private int GetScore()
    {
        return _score;
    }

    private int GetLengthOfList()
    {
        return _goals.Count;
    }

    private void SetScore(int number)
    {
        _score = number;
    }
    
    private string GoalText(string goal)
    
    {
        string goalType = goal.Split(":")[1];
        goalType = goalType.Split("|")[0];
        
        if(goalType == "Simple")
        {
            string line = "";
            string checkbox = goal.Split("Checkbox:")[1];
            checkbox = checkbox.Split("|")[0];
            line += checkbox;
            string name = goal.Split("Name:")[1];
            name = name.Split("|")[0];
            line += " " + name;
            string description = goal.Split("Description:")[1];
            description = description.Split("|")[0];
            line += " " + description;
            
            return line;
        }
        else if(goalType == "Eternal")
        {
            string line = "";
            string checkbox = goal.Split("Checkbox:")[1];
            checkbox = checkbox.Split("|")[0];
            line += checkbox;
            string name = goal.Split("Name:")[1];
            name = name.Split("|")[0];
            line += " " + name;
            string description = goal.Split("Description:")[1];
            description = description.Split("|")[0];
            line += " " + description;
            
            return line;
        }
        else if(goalType == "Checklist")
        {
            string line = "";
            string checkbox = goal.Split("Checkbox:")[1];
            checkbox = checkbox.Split("|")[0];
            line += checkbox;
            string name = goal.Split("Name:")[1];
            name = name.Split("|")[0];
            line += " " + name;
            string description = goal.Split("Description:")[1];
            description = description.Split("|")[0];
            line += " " + description;
            string tally = goal.Split("Tally:")[1];
            tally = tally.Split("|")[0];
            line += " " + tally;
            string numerator = goal.Split("Numerator:")[1];
            numerator = numerator.Split("|")[0];    
            line += " " + numerator + "/";
            string denominator = goal.Split("Denominator:")[1];
            denominator = denominator.Split("|")[0];
            line += denominator;

            return line;
        }
        else
        {
            return "Error displaying the goal";
        }
        
   }

    public void GetScoreFromList()
    {
        string line = _goals[0];
        string[] splitLine = line.Split(":");
        string score = splitLine[1];
        bool number = int.TryParse(score, out int scoreInt);
        if(number == true)
        {
            SetScore(scoreInt);
        }
        else
        {
            Console.WriteLine("There was an error extracting the score.");
        }
    }
    
    private void DisplayGoals()
    {
        int length = GetLengthOfList();
        if(length == 0)
        {
            Console.WriteLine("You have no goals to display.");
        }
        else
        {  
            Console.WriteLine("The following are your goals:");
            for(int i = 1; i < length; i++)
            {
                string goal = _goals[i];
                string line = GoalText(goal);
                Console.Write($"{i}. ");
                Console.Write(line);
                Console.Write("\n");
            }
        }
    }
    
    private void DisplayScore()
    {
        int number = GetScore();
        Console.WriteLine($"You have {number} points.");
    }

    public void RecordEvent(int number)
    {

    }

    public void QuestApp()
    {
        bool runProgram = true;
        do
        {
            int selection = 0;
            bool validChoice = false;
            while(validChoice == false)
            {
                //QuestProgram qP = new QuestProgram();
                DisplayScore();
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
                                    CreateSimpleGoal(name, description, userPointsInt, "Simple");
                                    validPoints = true;
                                }
                            }
                        
                        break;
                        case 2:
                            Console.Clear();
                            bool validPoints2 = false;
                            while(validPoints2 == false)
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
                                    CreateEternalGoal(name, description, userPointsInt, "Eternal");
                                    validPoints2 = true;
                                }
                            }
                        break;
                        case 3:
                            Console.Clear();
                            bool validPoints3 = false;
                            while(validPoints3 == false)
                            {
                                Console.WriteLine("What is the name of your goal? ");
                                string name = Console.ReadLine();
                                Console.WriteLine("What is a short description of your goal? ");
                                string description = Console.ReadLine();
                                Console.WriteLine("What is the amount of points this goal is worth? ");
                                string userPoints = Console.ReadLine();
                                Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
                                string amountOfTimes = Console.ReadLine();
                                Console.WriteLine("What is the bonus for accomplishing it that many times? ");
                                string bonusPoints = Console.ReadLine();
                                bool userNumber1 = int.TryParse(userPoints, out int userPointsInt);
                                bool userNumber2 = int.TryParse(amountOfTimes, out int amountOfTimesInt);
                                bool userNumber3 = int.TryParse(bonusPoints, out int bonusPointsInt);
                                if (userNumber1 == false || userNumber2 == false || userNumber3 == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You entered an invalid number for the amount of points. Please try again.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    CreateChecklistGoal(name, description, userPointsInt, amountOfTimesInt, bonusPointsInt, "Checklist");
                                    validPoints3 = true;
                                }
                            }
                        break;
                        default:
                        break;
                    }
                break;
                case 2:
                    Console.Clear();
                    DisplayGoals();
                    Console.WriteLine();
                break;
                case 3:
                    int listLenght = GetLengthOfList();

                    if(listLenght == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You have no goals to save. Please create some goals first then try again.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Clear();
                        bool exists = true;
                        while(exists == true)
                        {
                            Console.Write("What is the filename for the goal file. ");
                            string fileInput = Console.ReadLine();
                            string filenameToSave = fileInput + ".txt";

                            Files f1 = new Files();
                            bool fileToCheck = f1.FileAlreadyExists(filenameToSave);
                        
                            if (fileToCheck == true)
                            {
                                Console.Clear();
                                Console.WriteLine("That file already exists. Please try again.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Files f2 = new Files(filenameToSave);
                                bool clearList = f2.SaveGoals(_goals);
                                if(clearList == true)
                                {
                                    _goals.Clear();
                                    exists = false;
                                }
                                else
                                {
                                    Console.WriteLine("There was an error saving your goals. Please try again.");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                break;
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //TODO: This is were I left off. I need to figure out how to load the file 
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case 4:
                    Console.Clear();
                    Console.Write("What is the filename for the goal file. ");
                    string nameInput = Console.ReadLine();
                    string filenameToLoad = nameInput + ".txt";
                    Files f3 = new Files();
                    bool fileBool = f3.FileAlreadyExists(filenameToLoad);
                    if(fileBool == false)
                    {
                        //TODO: test this
                        Console.Clear();
                        Console.WriteLine("That file does not exist. Please try again.");
                        Console.WriteLine();
                    }
                    else
                    {   
                        //TODO: test this
                        Files f4 = new Files(filenameToLoad);
                        f4.LoadFile(filenameToLoad);
                    }
                    Console.WriteLine();
                    
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