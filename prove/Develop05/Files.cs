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

    private void SetFilename(string filename)
    {
        _filename = filename;
    }

    public string GetFilename()
    {
        return _filename;
    }

    public void SaveGoals(string filename, List<Goal> list)
    {
        
    }

    public void SaveToExistingFile(string filename, List<Goal> list)
    {
        
    }

    public void LoadFile(string filename)
    {
        
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