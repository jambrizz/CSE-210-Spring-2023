using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Listing : Activity
{
    private string _description;

    private List<string> _promptList = new List<string>();

    //Might need to change the constructor
    public Listing(string activityName, int time, string description) : base(activityName, time)
    {
        _description = description;
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_promptList.Count);
        string prompt = _promptList[index];
        return prompt;
    }

    public void RunListingActivity()
    {

    }
}