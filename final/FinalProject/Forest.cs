using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Forest: Journey
{
    private int _forestSphinxQuestions = 2;

    private int _forestGoblins = 3;

    private int _forestPathLenght = 3;

    private List<string> _forestStoryLines = new List<string>()
    {

    };

    public int GetForestPathLength()
    {
        return _forestPathLenght;
    }

    public int GetForestSphinxQuestions()
    {
        return _forestSphinxQuestions;
    }

    public int GetForestGoblins()
    {
        return _forestGoblins;
    }

    public void SetForestPathLenght(int number)
    {
        _forestPathLenght = number;
    }

    public void SetForestSphinxQuestions(int number)
    {
        _forestSphinxQuestions = number;
    }

    public void SetForestGoblins(int number)
    {
        _forestGoblins = number;
    }

    public void ForestStory(int start, int end)
    {

    }
}