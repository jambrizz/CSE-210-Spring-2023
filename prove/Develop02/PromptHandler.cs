using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PromptHandler
{
    public string _prompt;

    private List<string> questions = new List<string>()
    {
        
        "What was your highlight of this day?",
        "What is something that you are grateful for today?",
        "What is something that you wish you could have done differently today?",
        "What is something that you learned today?",
        "What is something that you are looking forward to tomorrow?",
        "Who was the most influential person you interacted with today?",
        "What is something that you are proud of today?",
        "Did you learn anything new today?",
    };

    
    public int GetRandomPrompt()
    {
        Random number = new Random();
        int randomNumber = number.Next(0, questions.Count);
        return randomNumber;
    }

    public string GetPrompt()
    {
        int randomNumber = GetRandomPrompt();
        string prompt = questions[randomNumber];
        return _prompt = prompt;
    }

    public string LoadPrompt()
    {
        return _prompt;
    }
}