using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reflecting : Activity
{
    private string _description = "This Activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    private string _prompt;

    private string _question;

    private List<string> _promptList = new List<string>();

    private List<string> _questionList = new List<string>();

    private List<string> _DisplayedQuestionList = new List<string>();

    //Might need to change the constructor
    public Reflecting(string activityName, int time, string description, string prompt, string question) : base(activityName, time)
    {
        _description = description;
        _prompt = prompt;
        _question = question;
    }

    public Reflecting() : base()
    {

    }

    public void GetQuestion()
    {

    }

    public void GetPrompt()
    {

    }

    public void RandomQuestion()
    {

    }
}