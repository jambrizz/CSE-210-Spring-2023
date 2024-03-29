using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin: Character
{
    private string paladinShield = "Shield of the Righteous";

    protected int paladinShieldPower = 50;

   

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

    public override int GetShieldPower()
    {
        return paladinShieldPower;
    }

    public override void SetShieldPower(int number)
    {
        paladinShieldPower = number;
    }

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nBonus: " + paladinShield + "\nBonus Power: " + paladinShieldPower;
    }
}