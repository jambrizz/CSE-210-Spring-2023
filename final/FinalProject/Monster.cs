using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Monster
{
   private string _monsterType;

    private int _monsterHealth;

    private string _monsterWeapon; 

    private int _monsterWeaponPower;

    private List<string> _monsterTypes = new List<string>()
    {
        "Dragon",
        "Ogre",
        "Minautor"
    };

    private List<string> _monsterWeapons = new List<string>()
    {
        //Dragon
        "Fire",
        //Ogre
        "Club",
        //Minautor
        "Axe"
    };

    private List<int> _monsterHealths = new List<int>()
    {
        //Dragon
        150,
        //Ogre
        125,
        //Minautor
        100
    };

    private List<int> _monsterWeaponPowers = new List<int>()
    {
        //Dragon
        50,
        //Ogre
        40,
        //Minautor
        30
    };

    private List<string> _dragonCombat = new List<string>()
    {
        "The dragon breathes fire at you!",
        "The dragon swipes at you with its claws!",
        "The dragon charges you!",
        "The dragon swings its tail at you!"
    };

    private List<string> _ogreCombat = new List<string>()
    {
        "The ogre swings its club at you!",
        "The ogre swings at you!",
        "The ogre kicks at you!",
        "The ogre headbutts you!"
    };

    private List<string> _minautorCombat = new List<string>()
    {
        "The minautor swings its axe at you!",
        "The minautor swipes at you!",
        "The minautor kicks at you!",
        "The minautor charges at you!"
    };

    public void SetMonster()
    {
        Random random = new Random();
        int monsterType = random.Next(0, _monsterTypes.Count);
        
        //Todo: add if statements to decide monster stats
    }

    public string GetMonsterStats()
    {
        return "";
    }

    public string GetMonsterHealth()
    {
        return $"Monster Health: {_monsterHealth}";
    }

    public string GetCombatMessage(string monsterType, int number)
    {
        //TODO: add if statements to decide which list to use
        //TODO: add function to retrive random message from list
        return "";
    }

    public void SetMonsterHealth(int number)
    {
        _monsterHealth = number;
    }
}