using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class QuestProgram
{
    public List<string> _goals = new List<string>();

    private int _score = 0;

    public void CreateChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, string type)
    {
        Checklist checklist = new Checklist(name, description, points, targetCount, bonusPoints, type);
        //_goals.Add(checklist);
    }

    public void CreateEternalGoal(string name, string description, int points, string type)
    {
        Eternal eternal = new Eternal(name, description, points, type);
        //_goals.Add(eternal);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //TODO: fix this to add the goal to the list. currently it does not save the goal after the method is done
    public void CreateSimpleGoal(string name, string description, int points, string type)
    {
        Simple simple = new Simple(name, description, points, type);
        string goal = simple.RecordGoal();
        int length = _goals.Count;
        Console.WriteLine($"Length of goal's list is {length}");
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
        Console.WriteLine($"Length of goal's list is {length2}");
        //_goals.Add(simple);
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int number)
    {
        _score = number;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void DisplayGoals()
    {
        //TODO: fix this to display all the goals right not it does not work
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void DisplayScore()
    {
        int number = GetScore();
        Console.WriteLine($"You have {number} points.");
    }

    public void RecordEvent(int number)
    {

    }
}