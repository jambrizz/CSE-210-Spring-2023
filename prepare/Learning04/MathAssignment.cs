using System;

public class MathAssignment : Assignment
{
    private string _textbookSection;

    private string _problems;

    public string GetHomeworkList()
    {
        return $"Section: {_textbookSection} Problems: {_problems}";
    }

    public void SetMathAssignment(string textbookSection, string problems)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }
}