using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class FileHelper
{
    public bool SaveFile(string fileName, List<string> List)
    {
        if (File.Exists(fileName))
        {
            Console.Clear();
            Console.WriteLine("This file already exists. Would you like to overwrite it? (y/n)");
            string userChoice = Console.ReadLine().ToLower();
            if(userChoice == "y")
            {
                File.WriteAllLines(fileName, List);
                Console.WriteLine("File saved.");
                return true;
            }
            else if(userChoice == "n")
            {
                Console.WriteLine("File not saved. Please save your file with a different name.");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. File not saved.");
                Console.WriteLine();
                Console.WriteLine("This file already exists. Would you like to overwrite it? (y/n)");
                userChoice = Console.ReadLine().ToLower();
                if (userChoice == "y")
                {
                    File.WriteAllLines(fileName, List);
                    Console.WriteLine("File saved.");
                    return true;
                }
                else if (userChoice == "n")
                {
                    Console.WriteLine("File not saved. Please save your file with a different name.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. File not saved please start over.");
                    return false;
                }
            }
        }
        else
        {
            File.WriteAllLines(fileName, List);
            Console.WriteLine("File saved.");
            return true;
        }
    }

    public void LoadFile(string fileName, List<string> List)
    {
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            List.Add(line);
        }
    }
}