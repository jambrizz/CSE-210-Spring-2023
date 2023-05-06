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

    private List<int> questionsUsed = new List<int>();

    public int GetRandomPrompt()
    {
        Random number = new Random();
        int randomNumber = number.Next(0, questions.Count);
        return randomNumber;
    }

    public bool CheckIfPromptUsed(int number)
    {
        if (questionsUsed.Contains(number))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //TODO fix the method below the questionUsed is not saving the number after it is used and always returns 0 regardless of the number of questions used
    //Move the questionsUsed list to the Program.cs file as a posible solution
    public void LoadPrompt()
    {
        Console.WriteLine(questionsUsed.Count);
        int promptQuestionIndex = GetRandomPrompt();
        Console.WriteLine(promptQuestionIndex);
        if (CheckIfPromptUsed(promptQuestionIndex) == false)
        {
            Console.WriteLine(questions[promptQuestionIndex]);
            questionsUsed.Add(promptQuestionIndex);
            Console.WriteLine(questionsUsed.Count);
        }
        else
        {
            Console.WriteLine(questionsUsed.Count);
            Console.WriteLine("This question has already been used. Please try again.");
            LoadPrompt();
        }
    }
}