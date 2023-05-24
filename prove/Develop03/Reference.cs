using System;
using System.Collections.Generic;
using System.Linq;

public class Reference
{
    public string _book;

    public int _chapter;

    public int _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public void SetVerse(int verse)
    {
        _verse = verse;
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    public string GetReference()
    {
        return $"{_book} {_chapter}:{_verse}";
    }


}