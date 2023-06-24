using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Checklist: Goal
{
    private int _targetCount;
    private int _bonusPoints;
    
    public Checklist(string name): base(name)
    {
        
    }

    public Checklist(string name, string description, int points, int targetCount, int bonusPoints, string type): base(name, description, points, type)
    {
        _name = name;
        _description = description;
        _points = points;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _goalType = type;
    }

    public override string RecordGoal()
    {
        return $"GoalType:{_goalType}|Checkbox:[ ]| Name:{_name}| Description:({_description})| Tally: -- Currently completed| Numerator:0| Denominator:{_targetCount}| Points:{_points}| Bonus: {_bonusPoints}| Status:false";
    }
}