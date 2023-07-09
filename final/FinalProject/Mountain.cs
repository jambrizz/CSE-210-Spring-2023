using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Mountain: Journey
{
    private int _mountainSphinxQuestions = 2;

    private int _mountainTrolls = 2;

    private int _mountainPathLenght = 2;

    private List<string> _mountainStoryLines = new List<string>()
    {

    };

    public int GetMountainPathLength()
    {
        return _mountainPathLenght;
    }

    public int GetMountainSphinxQuestions()
    {
        return _mountainSphinxQuestions;
    }

    public int GetMountainTrolls()
    {
        return _mountainTrolls;
    }

    public void SetMountainPathLenght(int number)
    {
        _mountainPathLenght = number;
    }

    public void SetMountainSphinxQuestions(int number)
    {
        _mountainSphinxQuestions = number;
    }

    public void SetMountainTrolls(int number)
    {
        _mountainTrolls = number;
    }

    public void MountainStory(int start, int end)
    {

    }

}