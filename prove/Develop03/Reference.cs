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

    public void SetBook(string book)
    {
        _book = book;
    }

    public void SetChapter(string chapter)
    {
        _chapter = chapter;
    }

    public void SetStartVerse(string verse)
    {
        _startVerse = verse;
    }

    public void SetEndVerse(string verse)
    {
        _endVerse = verse;
    }

    public string GetBook()
    {
        return _book;
    }

    public string GetChapter()
    {
        return _chapter;
    }

    public string GetVerse()
    {
        return _startVerse;
    }

    public string GetEndVerse()
    {
        return _endVerse;
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