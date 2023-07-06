using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Wizard: Character
{
  private string wizardStaff = "Staff of the Magi";

    private int wizardStaffPower = 50;

    public Wizard(int selection) : base(selection)
    {
        _heroType = "Wizard";
        _health = 100;
        _armor = 100;
        _weaponType = "Short Sword";
        _weaponPower = 25;
    }  

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nStaff: " + wizardStaff + "\nStaff Power: " + wizardStaffPower;
    }
}