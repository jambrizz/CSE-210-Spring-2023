using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Eternal: Goal
{
    public Eternal(string name): base(name)
    {
        
    }

    public Eternal(string name, string description, int points, string type): base(name, description, points, type)
    {
        _name = name;
        _description = description;
        _points = points;
        _goalType = type;
    }

    public override string RecordGoal()
    {
        return $"GoalType:{_goalType}|Checkbox:[ ]| Name:{_name}| Description:({_description})| Points:{_points}| Status:false";
    }
}