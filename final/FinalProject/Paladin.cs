using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin: Character
{
    private string paladinShield = "Shield of the Righteous";

    private int paladinShieldPower = 50;

    public Paladin(int selection) : base(selection)
    {
        _heroType = "Paladin";
        _health = 100;
        _armor = 100;
        _weaponType = "Drogden Mace";
        _weaponPower = 45;
    }

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nShield: " + paladinShield + "\nShield Power: " + paladinShieldPower;
    }
}