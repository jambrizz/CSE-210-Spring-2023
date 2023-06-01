using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Word
{
    private int _length;

    public List<int> listLength = new List<int>();

    private List<string> _verseToDisplay = new List<string>();

    private List<string> _newVerseToDisplay = new List<string>();

    public List<int> hiddenWords = new List<int>();

    public void pickThreeWords()
    {
        for (int i = 0; i < 3;)
        {
            int number = RandomNumberGenerator();
            if(hiddenWords.Contains(number) == false)
            {
                hiddenWords.Add(number);
                i++;
            }
            if(hiddenWords.Count == _verseToDisplay.Count())
            {
                break;
            }
        }
    }

    public int RandomNumberGenerator()
    {
        Random random = new Random();
        int number = random.Next(0, _verseToDisplay.Count());
        return number;
    }
    
    internal object wordCount(List<object> list)
    {
        int count = list.Count();
        listLength.Add(count);
        return count;
    }

    public void AddVerseToList(string text)
    {
        string[] words = text.Split(" ");
        foreach (var item in words)
        {
            _verseToDisplay.Add(item);
        }
    }

    public string DisplayVerse()
    {
        string verse = "";
        foreach (var item in _verseToDisplay)
        {
            verse += item + " "; 
        }
        return verse;
    }

    public string DisplayVerseWithHiddenWords()
    {
        string verse = "";
        foreach (var item in _newVerseToDisplay)
        {
            verse += item + " "; 
        }
        return verse;
    }

    public void HideText()
    {
        pickThreeWords();
        _newVerseToDisplay.Clear();
        foreach (var item in _verseToDisplay)
        {
            int wordLength = item.Length;
            if(hiddenWords.Contains(_verseToDisplay.IndexOf(item)))
            {
                for (int i = 0; i < wordLength;)
                {
                    _newVerseToDisplay.Add("_");
                    i++;
                }
            }
            else
            {
                _newVerseToDisplay.Add(item);
            }
        }

    }

    public bool CheckIfComplete()
    {
        bool programComplete;
        int count1 = _verseToDisplay.Count();
        int count2 = hiddenWords.Count();
        if(count1 == count2)
        {
            programComplete = true;
        }
        else
        {
            programComplete = false;
        }
        return programComplete;
    }
}