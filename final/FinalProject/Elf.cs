using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Elf: Character
{
    private string elfBow = "Bow of the Forest";

    private int elfBowPower = 55;

    private List<string> _elfMessages = new List<string>()
    {
        "You jump out of the way!",
        "You dodge the attack!",
        "You block the attack!",
        "You take the hit!",
        "You take a critical hit!",
        "You take a glancing blow!",
        "You landed a critical hit with the Bow of the Forest!",
        "You landed a glancing blow!",
        "You landed a solid hit with the Goblin Cleaver!",
        "You missed!"
    };

    public Elf(int selection) : base(selection)
    {
        _heroType = "Elf";
        _health = 100;
        _armor = 80;
        _weaponType = "Goblin Cleaver";
        _weaponPower = 30;
    }

    public Elf(int health, int armor) : base(health, armor)
    {
        _health = health;
        _armor = armor;
    }

    public Elf() : base()
    {
    
    }

    public override int GetElfBowPower()
    {
        return elfBowPower;
    }

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nBonus: " + elfBow + "\nBonus Power: " + elfBowPower;
    }
}