using System;
using System.Collections.Generic;
using System.Linq;

public class Reference
{
    public string _book;

    public string _chapter;

    public string _startVerse;

    public string _endVerse;

    public string _reference;

    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _endVerse = verse;
    }

    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string reference)
    {
        _reference = reference;
    }
    /////////////////////////////////////////////////////////////////
    public void SetRefernces()
    {
        string rawReference = _reference;
        string book = rawReference.Split("Book:")[1].Split("|")[0];
        string chapter = rawReference.Split("Chapter:")[1].Split("|")[0];
        string endVerse = rawReference.Split("Verse:")[1].Split("|")[0];

        _book = book;
        _chapter = chapter;
        _endVerse = endVerse;
    
    }

    public void SetMultipleVerses()
    {
        string rawReference = _reference;
        string book = rawReference.Split("Book:")[1].Split("|")[0];
        string chapter = rawReference.Split("Chapter:")[1].Split("|")[0];
        string verses = rawReference.Split("Verses:")[1].Split("|")[0];
        string startVerse = verses.Split("-")[0];
        string endVerse = verses.Split("-")[1];

        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetReferenceSingleVerse()
    {
        return $"{_book} {_chapter}:{_endVerse}";
    }

    public string GetReferenceMultipleVerses()
    {
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }

}