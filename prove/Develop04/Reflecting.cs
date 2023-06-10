using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reflecting : Activity
{
    private string _description = "This Activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    private List<string> _promptList = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questionList = new List<string>()
    {
       "Why was this experience meaningful to you?",
       "What did you learn from this experience?",
       "How did this experience make you feel?",
       "What were the circumstances that led to this experience?",
       "What was the most difficult part of this experience?",
       "What was the most rewarding part of this experience?",
       "What did you learn about yourself from this experience?",
       "What could you learn from this experience that you could apply to other situations?",
       "How was this experience been different from others?",
       "If you could go back and change anything about this experience, would you? Why or why not?",
       "If you could go back in time and tell your past self something about this experience, what would it be?",
       "What would you tell someone else who was going through a similar experience?",
       "Who was involved in this experience?",
       "What was your role in this experience?",
       "What time in your life did this experience happen to you and was that significant to the event?",
       "If you were writing a book about this experience, what would you title this Chapter and why?",
    };

    private List<int> _DisplayedQuestionList = new List<int>();

    public Reflecting() : base()
    {

    }

    private string GetQuestion()
    {
        string question = "";
        bool run = true;
        while (run == true)
        {
            Random random = new Random();
            int index = random.Next(0, _questionList.Count);
            if (_DisplayedQuestionList.Contains(index))
            {
                index = random.Next(0, _questionList.Count);
            }
            else
            {
                question = _questionList[index];
                _DisplayedQuestionList.Add(index);
                run = false;
            }
        }
        return question;
    }

    private string GetPrompt()
    {
        string prompt = "";
        Random random = new Random();
        int index = random.Next(0, _promptList.Count);
        prompt = _promptList[index];
        return prompt;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void RandomQuestion(int time)
    {
        SetActivityName("Reflecting");
        SetActivityTime(time);
        GetReady();
        Console.Write(" -----> ");
        Console.Write(GetPrompt());
        Console.Write(" <----- ");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        string enter = Console.ReadLine();
        if (enter == "")
        {
            Console.WriteLine();
            bool run = true;
            object futureTime = AddSeconds(time);
            while (run == true)
            {
                Animation animation = new Animation();
                Console.Write("> ");
                Console.Write(GetQuestion());
                animation.DisplaySpinnerCustomTime(10
                );
                Console.WriteLine();
                object currentTime = GetDateTime();
                int timeIsUp = DateTime.Compare((DateTime)currentTime, (DateTime)futureTime);
                if (timeIsUp == 1 || timeIsUp == 0)
                {
                    run = false;
                }
            }
            GetDone();
            Console.WriteLine(DisplayEndingMessage());
        }

    }
}