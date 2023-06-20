using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Goal
{
    private bool _completed;

    protected string _name;

    protected int _points;

    public Goal(string name)
    {
        _name = name;
    }


}