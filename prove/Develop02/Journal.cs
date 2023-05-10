using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    

public class Journal
{
    public static List<string> _entries = new List<string>();

    public void AddEntry(string entry)
    {
        _entries.Add(entry);       
    }

    public void DisplayJournal()
    {
        if(_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to display.");
        }
        else
        {
            foreach (string line in _entries)
            {
                Console.WriteLine(line);
            }
        }
    }

    public bool LoadJournal(string fileName)
    {   
        FileHelper fileHelper = new FileHelper();
        if(File.Exists(fileName) == false)
        {
            return false;
        }
        else
        {
            fileHelper.LoadFile(fileName, _entries);
            return true;
        }

    }

    public bool SaveJournal()
    {
        if(_entries.Count == 0)
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
            return fileHelper.SaveFile(fileName, _entries);
        }
    }

    public bool IsListEmpty()
    {
        if(_entries.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearList()
    {
        _entries.Clear();
    }
}
