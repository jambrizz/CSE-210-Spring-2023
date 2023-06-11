using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Listing : Activity
{
    private string _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    private List<string> _promptList = new List<string>()
    {
       "Who are people in your life that you appreciate?",
       "What are you personal strengths?",
       "Who are people in your life that you can rely on?",
       "What are some of your favorite memories?",
       "What are some of your favorite things?", 
       "When have you felt the Holy Ghost this month?",
       "Who are some of your personal heroes?",
       "What are some of your favorite things about yourself?",
       "What are some of the happiest moments of your life?",
    };

    private string message1 = "List as many responses you can to the following prompt:";

    public Listing(string activityName, int time, string description) : base(activityName, time)
    {
        _description = description;
    }

    public Listing() : base()
    {

    }

    public string GetDescription()
    {
        return _description;
    }

    private string GetMessage1()
    {
        return message1;
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _promptList.Count);
        string prompt = _promptList[index];
        return prompt;
    }

    public void RunListingActivity(int time)
    {
        int counter = 0;
        SetActivityTime(time);
        Console.Clear();
        GetReady();
        Console.WriteLine(GetMessage1());
        Console.WriteLine();
        Console.Write(" -----> ");
        Console.Write(GetRandomPrompt());
        Console.Write(" <----- ");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("You may begin in: ");
        CountDown(9);
        Console.WriteLine();
        
        bool run = true;
        object futureTime = AddSeconds(time);
        while (run == true)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (response != "")
            {
               object currentTime = GetDateTime();
               int timeIsUp = DateTime.Compare((DateTime)currentTime, (DateTime)futureTime);
               if (timeIsUp == 0 || timeIsUp == 1)
               {
                run = false;
               }
                counter++;
            }
            else
            {
                Console.WriteLine("You must enter a response.");
                object currentTime = GetDateTime();
                int timeIsUp = DateTime.Compare((DateTime)currentTime, (DateTime)futureTime);
                if (timeIsUp == 0 || timeIsUp == 1)
                {
                    run = false;
                }
            }
        }
        Console.Write(" ------> ");
        Console.Write($"You listed {counter} items!");
        Console.Write(" <------ ");
        Console.WriteLine();
        GetDone();
        Console.WriteLine();
        Console.WriteLine(DisplayEndingMessage());
    }
}