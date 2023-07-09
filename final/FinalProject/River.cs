using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class River: Journey
{
    private int _riverSphinxQuestions = 1;

    private int _riverBandits = 1;

    private int _riverPathLenght = 2;

    private List<string> _riverStoryLines = new List<string>()
    {

    };

    public int GetRiverPathLength()
    {
        return _riverPathLenght;
    }

    public int GetRiverSphinxQuestions()
    {
        return _riverSphinxQuestions;
    }

    public int GetRiverBandits()
    {
        return _riverBandits;
    }   

    public void SetRiverPathLenght(int number)
    {
        _riverPathLenght = number;
    }

    public void SetRiverSphinxQuestions(int number)
    {
        _riverSphinxQuestions = number;
    }

    public void SetRiverBandits(int number)
    {
        _riverBandits = number;
    }

    public void RiverStory(int start, int end)
    {

    }
}