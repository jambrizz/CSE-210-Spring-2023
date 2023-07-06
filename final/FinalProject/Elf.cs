using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Elf: Character
{
    private string elfBow = "Bow of the Forest";

    private int elfBowPower = 35;

    public Elf(int selection) : base(selection)
    {
        _heroType = "Elf";
        _health = 100;
        _armor = 100;
        _weaponType = "Goblin Cleaver";
        _weaponPower = 35;
    }

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nBow: " + elfBow + "\nBow Power: " + elfBowPower;
    }
}