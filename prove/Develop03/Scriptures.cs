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

    public string GetDisplayText()
    {
        string _displayText = _text;
        
        return _displayText;
    }

    public void SendReference()
    {
        Reference reference = new Reference(_reference);
    }
}