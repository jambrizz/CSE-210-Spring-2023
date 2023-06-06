using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reflecting : Activity
{
    private string _description;

    private string _prompt;

    private string _question;

    private List<string> _promptList = new List<string>();

    private List<string> _questionList = new List<string>();

    private List<string> _userQuestionList = new List<string>();

    //Might need to change the constructor
    public Reflecting(string activityName, int time, string description, string prompt, string question) : base(activityName, time)
    {
        _description = description;
        _prompt = prompt;
        _question = question;
    }
}