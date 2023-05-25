using System;
using System.Collections.Generic;
using System.Linq;

public class ScriptureLibrary
{
    private int _random;
    private int _lengthOfTextFile;

    private string _path;
    private List<Scriptures> _scriptures = new List<Scriptures>();

    private string test;

    public ScriptureLibrary(string path)
    {
        _path = path;   
    }

    private void SetLengthOfTextFile(int length)
    {
        _lengthOfTextFile = length;
    }

    public int GetRandom()
    {
        return _random;
    }

    public int LengthOfTextFile()
    {
        return _lengthOfTextFile;
    }
    public void GetLengthOfTextFile()
    {
        int number = File.ReadLines(_path).Count();
        SetLengthOfTextFile(number);
    }

    public void GetRandomScripture()
    {
        Random random = new Random();
        int number = random.Next(1, _lengthOfTextFile + 1);
        _random = number;
    }

    public void LoadScripturesFromFiles()
    {
        int number = _random;
        string text = File.ReadLines(_path).Skip(number - 1).Take(1).First();
        Console.WriteLine(text.ToString());
    }

    private string ParseScriptureReference(string scripture)
    {
        return "";
    }

   
}