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

    private List<string> _monsterStoryLines = new List<string>()
    {
        "You walk up to King's Tower and you notice a hole in the wall that allows you to see inside. \nYou look inside",
        "You can't make out what the creature, it is too dark to see it clearly but you can tell that it is big.",
        "You hear a loud roar and you get scare thinking that the creature has seen you.",
        "You landed a fatal blow on the creature and it falls to the ground. \nYou walk up to the monster and deliver the final blow.",
        "You start to explorer the tower and see a hidden door to a dungeon under the tower. \nYou enter the dungeon and see a treasure chest in the middle of the room. \nYou open the treasure chest and discover 300 King's Gold Coins. \nYou take the coins and leave the dungeon.",
        "You leave the King's Tower and start to walk back to the village. \nYou are happy that you were able to defeat the monster and happy that you were able to get the treasure from the dungeon.",
    };

    public void SetMonster()
    {
        Random random = new Random();
        int monsterType = random.Next(0, _monsterTypes.Count);
        
        _monsterType = _monsterTypes[monsterType];
        _monsterHealth = _monsterHealths[monsterType];
        _monsterWeapon = _monsterWeapons[monsterType];
        _monsterWeaponPower = _monsterWeaponPowers[monsterType];

    }

    public string GetMonsterWeapon()
    {
        return _monsterWeapon;
    }

    public int GetMonsterAttack()
    {
        return _monsterWeaponPower;
    }

    public int GetMonsterHealth()
    {
        return _monsterHealth;
    }

    public string GetMonsterType()
    {
        return _monsterType;
    }

    private void SetMonsterHealth(int number)
    {
        _monsterHealth = number;
    }

    public int MonsterCombat(int rolledNumber)
    {
        int damage = 0;
        if(rolledNumber <10)
        {
            damage = 0;
            Console.Clear();
            Console.WriteLine("The monster attacks you but misses!");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
        }
        else if(rolledNumber >=10 || rolledNumber < 15)
        {
            damage = GetMonsterAttack() / 2;
            Console.Clear();
            Console.WriteLine("The monster attacks you and hits you with a glancing blow!");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
        }
        else if(rolledNumber >= 15 || rolledNumber <=20)
        {
            damage = GetMonsterAttack();
            Console.Clear();
            Console.WriteLine("The monster attacks you and lands a critical hit!");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
        }

        return damage;
    }

    public void SetMonsterDamage(int damage)
    {
        int health = GetMonsterHealth();
        if(damage > health)
        {
            SetMonsterHealth(0);
        }
        else
        {
            SetMonsterHealth(health - damage);
        }
    }

    public void MonsterStory(int start, int end)
    {
        for(int i = start; i < end + 1;)
        {
            Console.Clear();
            Console.WriteLine(_monsterStoryLines[i]);
            Console.ReadLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            i++;
        }
    }

}