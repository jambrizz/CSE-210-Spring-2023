using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Elf: Character
{
    private string elfBow = "Bow of the Forest";

    private int elfBowPower = 55;

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