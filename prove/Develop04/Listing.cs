using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Listing : Activity
{
    private string _description;

    private List<string> _promptList = new List<string>();

    private List<string> _userList = new List<string>();

    //Might need to change the constructor
    public Listing(string activityName, int time, string description) : base(activityName, time)
    {
        _description = description;
    }


}