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

    //TODO: revisit this method and modify it to display an error message of the List is empty
    //TODO: revisit this method and modify how the List is displayed so that there is no line gap between prompt question and response 
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

    public bool SaveJournal(List<string> List)
    {
        if (List.Count == 0)
        {
            Console.WriteLine("There are no entries to save.");
            return false;
        }
        else
        {
            Console.Write("Enter the name of the file you would like to save: ");
            string name = Console.ReadLine();
            string fileName = $"{name}.txt";
            FileHelper fileHelper = new FileHelper();
            return fileHelper.SaveFile(fileName, List);
        }
    }
}