using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    private bool _hidden;
    private string _text;

    public Word(string text)
    {
        _text = text;
    }

    public string GetVisibleText()
    {
        return "";
    }

    public void Hide()
    {

    }

    public bool IsHidden()
    {
        return false;
    }
    
}