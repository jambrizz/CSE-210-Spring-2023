using System;
using System.Collections.Generic;
using System.Linq;

public class Scriptures
{
    private string _text;
    //private Random _random = new Random();
    //private Reference _reference = new Reference(string book, int chapter, int verse);
    //private Word _word = new Word(text);

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
}