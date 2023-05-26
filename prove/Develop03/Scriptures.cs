using System;
using System.Collections.Generic;
using System.Linq;

public class Scriptures
{
    private string _text;
    private string _reference;
    private string _displayText;

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

    //TODO: fix this method having issues with line 34
    public string GetDisplayText()
    {
        string _displayText = _text;

        Console.WriteLine(_displayText);
        string [] seperator = {"|"};
        string [] removeIdentifiers = {"Book:", "Chapter:", "Verse:", "Text:"};

        string [] splitText = _displayText.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

        //string book = _displayText.Substring(bookIndex);

        Console.WriteLine(splitText[0]); 
        
        return "";
    }

    public void SendReference()
    {
        Reference reference = new Reference(_reference);
    }
}