using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Scriptures
{
    public string _text;
    private string _reference;
    private string _displayText;

    //private List<Scriptures> _scriptures = new List<Scriptures>();

    public Scriptures(string text)
    {
        _text = text;
    }

    public Scriptures()
    {
        
    }
    public string GetText()
    {
        return _text;
    }

    public string ExtractVerse()
    {
        string text = _text;
        string verse = text.Split("Text:")[1].Split("|")[0];
        return verse;
    }

    public string ExtractReference()
    {
        string text = _text;
        string reference = text.Split("*")[1].Split("Text:")[0];
        return reference;
    }
}