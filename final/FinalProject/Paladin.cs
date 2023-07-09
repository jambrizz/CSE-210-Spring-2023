using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin: Character
{
    private string paladinShield = "Shield of the Righteous";

    private int paladinShieldPower = 50;

    private List<string> _paladinMessages = new List<string>()
    {
        "You jump out of the way!",
        "You dodge the attack!",
        "You block the attack!",
        "You take the hit!",
        "You take a critical hit!",
        "You take a glancing blow!",
        "You landed a critical hit with your Mace!",
        "You landed a glancing blow!",
        "You landed a solid hit with your Mace!",
        "You missed!"
    };

    public Paladin(int selection) : base(selection)
    {
        _heroType = "Paladin";
        _health = 100;
        _armor = 100;
        _weaponType = "Drogden Mace";
        _weaponPower = 45;
    }

    public Paladin(int health, int armor, int shield) : base(health, armor)
    {
        _health = health;
        _armor = armor;
        paladinShieldPower = shield;
    }

    public Paladin() : base()
    {
    
    }

    public int GetShieldPower()
    {
        return paladinShieldPower;
    }

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nBonus: " + paladinShield + "\nBonus Power: " + paladinShieldPower;
    }
}