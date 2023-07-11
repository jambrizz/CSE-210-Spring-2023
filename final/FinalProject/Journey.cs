using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Journey
{
    string powerUpType;

    int powerUpAmount;

    int _enemiesFought;

    int _questionsCount;

    List<string> _powerUps = new List<string>()
    {
        "Health",
        "Attack",
        "Defense"
    };

    List<int> _powerUpAmounts = new List<int>()
    {
        30,
        15,
        25
    };

    public string SphinxRiddle()
    {
        return "";
    }

    public void JourneyCombat()
    {
        
    }
}