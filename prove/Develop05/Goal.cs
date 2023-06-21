using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Goal
{
    private bool _completed;

    protected string _name;

    protected string _description;

    protected int _points;
    protected string _goalType;

    public Goal()
    {

    }

    public Goal(string name)
    {
        _name = name;
    }

    public Goal(string name, string description, int points, string type)
    {
        _name = name;
        _description = description;
        _points = points;
        _goalType = type;
    }
    
    public virtual string RecordGoal()
    {
        return "";
    }
}