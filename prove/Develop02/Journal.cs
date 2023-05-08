using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Journal
{
    

    public string AddEntry()
    {
        Console.Clear();
        PromptHandler prompt = new PromptHandler();
        prompt.GetPrompt();
        string question = prompt.LoadPrompt();
        Console.WriteLine(question);
        Console.Write("> ");
        string response = Console.ReadLine();
        Entry entry = new Entry();
        entry.SetEntry(question, response);
        string entryString = entry.DisplayEntry();
        return entryString;
    }

    public void DisplayJournal(List<string> List)
    {
        Console.Clear();
        foreach (string line in List)
        {
            Console.WriteLine(line);
            Console.WriteLine();
        }
    }

    public void LoadJournal()
    {

    }

    public void SaveJournal()
    {

    }
}