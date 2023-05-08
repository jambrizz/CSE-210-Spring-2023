using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Entry
{
    public string _date;

    public string _prompt;

    public string _response;

    public void SetEntry(string prompt, string response)
    {
        _date = DateTime.Now.ToString("MM/dd/yyyy");
        _prompt = prompt;
        _response = response;
    }

    public string DisplayEntry()
    {
        return $"Date: {_date} - Prompt: {_prompt} \n{_response}";
    }
}