using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    private int _length;

    public List<int> listLength = new List<int>();

    private List<string> _verseToDisplay = new List<string>();

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
            if(hiddenWords.Count == listLength[0])
            {
                break;
            }
        }
    }

    public int RandomNumberGenerator()
    {
        Random random = new Random();
        int number = random.Next(0, listLength[0]);
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
        foreach (var item in text)
        {
            string newItem = item.ToString();
            string word;
            if(newItem != " ")
            {
            
            }
        }
    }

    public void DisplayVerse()
    {
        foreach (var word in _verseToDisplay)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine(_verseToDisplay.Count);
    }
}