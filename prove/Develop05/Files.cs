using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Files
{
    private string _filename;

    public Files(string filename)
    {
        _filename = filename;
    }

    public Files()
    {

    }

    private void SetFilename(string filename)
    {
        _filename = filename;
    }

    public string GetFilename()
    {
        return _filename;
    }

    public bool FileAlreadyExists(string name)
    {
        return File.Exists(name);
    }

    public bool SaveGoals(List<string> list)
    {
        File.WriteAllLines(_filename, list);

        if (FileAlreadyExists(_filename) == true)
        {
            Console.WriteLine("File was created successfully.");
            Console.WriteLine();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveToExistingFile(string filename, List<Goal> list)
    {
        
    }

    public void LoadFile(string filename)
    {
        /////////////////////////////////////////////////////////////////////////////////////
        //TODO: This is where I left off. I need to figure out how to load the file into the _goals list.
        /////////////////////////////////////////////////////////////////////////////////////
    }

    public void DisplayMenuFile()
    {
        string path = _filename;
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

}