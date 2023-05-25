using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    private int _lenght;

    public List<int> listLength = new List<int>();

    private List<int> _savedIndexes = new List<int>();

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

}