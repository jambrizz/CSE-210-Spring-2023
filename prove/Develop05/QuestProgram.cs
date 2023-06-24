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
        if(_goals.Count == 0)
        {
            SetScore(0);
            return 0;
        }
        else
        {
            string line = _goals[0];
            string[] splitLine = line.Split(":");
            string score = splitLine[1];
            bool number = int.TryParse(score, out int scoreInt);
            if(number == true)
            {
                SetScore(scoreInt);
                return scoreInt;
            }
            else
            {
                Console.WriteLine("There was an error extracting the score.");
                return 0;
            }
        }
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
    
    private void DisplayGoals()
    {
        Console.Clear();
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
        string newLine = "";
        string goal = _goals[number];
        
        string status = goal.Split("Status:")[1];
        
        if(status == "true")
        {
            Console.WriteLine("You have already completed this goal.");
        }
        else
        {
            string goalType = goal.Split(":")[1];
            string type = goalType.Split("|")[0];
            
            if(type == "Simple")
            {
                string newGoalType = goal.Split("|")[0];
                newLine += newGoalType + "|" + "Checkbox:[X]|";
                
                string name = goal.Split("Name:")[1];
                string newName = name.Split("|")[0];
                newLine += " Name:" + newName + "|";

                string description = goal.Split("Description:")[1];
                string newDescription = description.Split("|")[0];
                newLine += " Description:" + newDescription + "|";

                string points = goal.Split("Points:")[1];
                string newPoints = points.Split("|")[0];
                newLine += " Points:" + newPoints + "|";

                newLine += " Status:true";
                
                int pointsToAdd = int.Parse(newPoints);
                UpdateScore(pointsToAdd);
                Console.WriteLine("Congratulations! You have completed your goal! You have earned " + pointsToAdd + " points.");
                Console.WriteLine();
                _goals.RemoveAt(number);
                _goals.Insert(number, newLine);
            }
            else if(type == "Eternal")
            {
                string newGoalType = goal.Split("|")[0];
                newLine += newGoalType + "|" + "Checkbox:[ ]|";
                
                string name = goal.Split("Name:")[1];
                string newName = name.Split("|")[0];
                newLine += " Name:" + newName + "|";

                string description = goal.Split("Description:")[1];
                string newDescription = description.Split("|")[0];
                newLine += " Description:" + newDescription + "|";

                string points = goal.Split("Points:")[1];
                string newPoints = points.Split("|")[0];
                newLine += " Points:" + newPoints + "|";

                newLine += " Status:false";
                
                int pointsToAdd = int.Parse(newPoints);
                UpdateScore(pointsToAdd);
                Console.WriteLine("Congratulations! You have completed your goal! You have earned " + pointsToAdd + " points.");
                Console.WriteLine();
                _goals.RemoveAt(number);
                _goals.Insert(number, newLine);
            }
            else if(type == "Checklist")
            {
                string numerator = goal.Split("Numerator:")[1];
                string newNumerator = numerator.Split("|")[0];
                int numeratorInt = int.Parse(newNumerator);
                numeratorInt++;

                string denominator = goal.Split("Denominator:")[1];
                string newDenominator = denominator.Split("|")[0];
                int denominatorInt = int.Parse(newDenominator);

                if(numeratorInt == denominatorInt)
                {
                    string newGoalType = goal.Split("|")[0];
                    newLine += newGoalType + "|" + "Checkbox:[X]|";
                    
                    string name = goal.Split("Name:")[1];
                    string newName = name.Split("|")[0];
                    newLine += " Name:" + newName + "|";

                    string description = goal.Split("Description:")[1];
                    string newDescription = description.Split("|")[0];
                    newLine += " Description:" + newDescription + "|";

                    string tally = goal.Split("Tally:")[1];
                    string newTally = tally.Split("|")[0];
                    newLine += " Tally:" + newTally + "|";

                    string newNumeratorString = " Numerator:" + numeratorInt + "|";
                    newLine += newNumeratorString;

                    string newDenominatorString = "Denominator:" + denominatorInt + "|";
                    newLine += newDenominatorString;

                    string points = goal.Split("Points:")[1];
                    string newPoints = points.Split("|")[0];
                    newLine += " Points:" + newPoints + "|";

                    string bonus = goal.Split("Bonus:")[1];
                    string newBonus = bonus.Split("|")[0];
                    newLine += " Bonus:" + newBonus + "|";

                    newLine += " Status:true";
                    
                    int pointsToAdd = int.Parse(newPoints);
                    int bonusToAdd = int.Parse(newBonus);
                    int totalPoints = pointsToAdd + bonusToAdd;
                    UpdateScore(totalPoints);
                    Console.WriteLine("Congratulations! You have completed your goal! You have earned " + pointsToAdd + " points." + " You have also earned a bonus of " + newBonus + " points.");
                    Console.WriteLine();
                    _goals.RemoveAt(number);
                    _goals.Insert(number, newLine);
                }
                else
                {
                    string newGoalType = goal.Split("|")[0];
                    newLine += newGoalType + "|" + "Checkbox:[ ]|";
                    
                    string name = goal.Split("Name:")[1];
                    string newName = name.Split("|")[0];
                    newLine += " Name:" + newName + "|";

                    string description = goal.Split("Description:")[1];
                    string newDescription = description.Split("|")[0];
                    newLine += " Description:" + newDescription + "|";

                    string tally = goal.Split("Tally:")[1];
                    string newTally = tally.Split("|")[0];
                    newLine += " Tally:" + newTally + "|";

                    string newNumeratorString = " Numerator:" + numeratorInt + "|";
                    newLine += newNumeratorString;

                    string newDenominatorString = "Denominator:" + denominatorInt + "|";
                    newLine += newDenominatorString;


                    string points = goal.Split("Points:")[1];
                    string newPoints = points.Split("|")[0];
                    newLine += " Points:" + newPoints + "|";

                    string bonus = goal.Split("Bonus:")[1];
                    string newBonus = bonus.Split("|")[0];
                    newLine += " Bonus:" + newBonus + "|";

                    newLine += " Status:false";
                    
                    int pointsToAdd = int.Parse(newPoints);
                    UpdateScore(pointsToAdd);
                    Console.WriteLine("Congratulations! You have completed your goal! You have earned " + pointsToAdd + " points.");
                    Console.WriteLine();
                    _goals.RemoveAt(number);
                    _goals.Insert(number, newLine);
                }
            }
            else
            {
                Console.WriteLine("There was an error recording your goal.");
            }
        }
    }

    public void UpdateScore(int number)
    {
        string scoreFromList = _goals[0];
        string[] splitLine = scoreFromList.Split(":");
        string score = splitLine[1];
        bool scoreBool = int.TryParse(score, out int scoreInt);
        if(scoreBool == true)
        {
            int newScore = scoreInt + number;
            string newScoreString = "TotalScore:" + newScore;
            _goals.RemoveAt(0);
            _goals.Insert(0, newScoreString);
        }
        else
        {
            Console.WriteLine("There was an error updating your score.");
        }
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
                    Console.Clear();
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
                                bool overwrite = false;
                                while(overwrite == false)
                                {
                                    Console.WriteLine("Would you like to overwrite the file? (Y/N) ");
                                    string overwriteInput = Console.ReadLine();
                                    if(overwriteInput == "Y" || overwriteInput == "y")
                                    {
                                        Files f2 = new Files(filenameToSave);
                                        bool clearList = f2.SaveGoals(_goals);
                                        if(clearList == true)
                                        {
                                            _goals.Clear();
                                            exists = false;
                                            overwrite = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("There was an error saving your goals. Please try again.");
                                            Console.WriteLine();
                                        }
                                    }
                                    else if(overwriteInput == "N" || overwriteInput == "n")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a new filename.");
                                        Console.WriteLine();
                                        overwrite = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid choice. Please try again.");
                                        Console.WriteLine();
                                    }
                                }
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
                case 4:
                    Console.Clear();
                    Console.Write("What is the filename for the goal file. ");
                    string nameInput = Console.ReadLine();
                    string filenameToLoad = nameInput + ".txt";
                    Files f3 = new Files();
                    bool fileBool = f3.FileAlreadyExists(filenameToLoad);
                    if(fileBool == false)
                    {
                        Console.Clear();
                        Console.WriteLine("That file does not exist. Please try again. Do not include the .txt extension at the end.");
                        Console.WriteLine();
                    }
                    else
                    {   
                        Console.Clear();
                        Files f4 = new Files(filenameToLoad);
                        f4.LoadFile(filenameToLoad, _goals);
                    }
                    Console.WriteLine();
                    
                break;
                case 5:
                    Console.Clear();
                    int lenght = GetLengthOfList();

                    if(lenght == 0)
                    {
                        Console.WriteLine("You have no goals to record. Please create some goals first then try again.");
                    }
                    else
                    {
                        int eventSelection = 0;
                        bool validEventChoice = false;
                        while(validEventChoice == false)
                        {
                            Console.WriteLine("Record a goal from the following list.");
                            Console.WriteLine();
                            DisplayGoals();
                            Console.WriteLine();
                            Console.Write("Please enter the number of the goal you accomplished. ");
                            string goalNumber = Console.ReadLine();
                            bool goalNumberBool = int.TryParse(goalNumber, out int goalNumberInt);

                            if(goalNumberBool == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a number and try again.");
                                Console.WriteLine();
                            }
                            else if(goalNumberBool == true && goalNumberInt > GetLengthOfList() -1  || goalNumberBool == true && goalNumberInt < 1)
                            {
                                Console.Clear();
                                Console.WriteLine($"You entered {goalNumberInt}, which is not a valid selection. Please try again.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.Clear();
                                eventSelection = goalNumberInt;
                                validEventChoice = true;
                            }
                        }
                        Console.WriteLine();
                        RecordEvent(eventSelection);
                    }
                    
                    
                break;
                case 6:
                    Console.Clear();
                    int length = GetLengthOfList();

                    if(length > 0)
                    {
                        bool leave = false;
                        while(leave == false)
                        {
                            Console.WriteLine("You have unsaved goals. Would you like to save them? (Y/N) ");
                            string saveInput = Console.ReadLine();
                            if(saveInput == "Y" || saveInput == "y")
                            {
                                Console.Clear();
                                Console.WriteLine("Please select menu option 3 to save your goals.");
                                Console.WriteLine();
                                leave = true;
                            }
                            else if(saveInput == "N" || saveInput == "n")
                            {
                                Console.Clear();
                                Console.WriteLine("Thank you for using the Eternal Quest Program! See you next time!");
                                Console.WriteLine();
                                leave = true;
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid choice. Please try again.");
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using the Eternal Quest Program! See you next time!");
                        Console.WriteLine();
                        runProgram = false;
                    }
                break;
                default:
                break;
            }
        }
        while (runProgram == true);
    }
}