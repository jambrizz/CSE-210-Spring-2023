using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Wizard: Character
{
  private string wizardStaff = "Staff of the Magi";

    private int wizardStaffPower = 70;

    public Wizard(int selection) : base(selection)
    {
        _heroType = "Wizard";
        _health = 100;
        _armor = 70;
        _weaponType = "Short Sword";
        _weaponPower = 20;
    }  

    public Wizard() : base()
    {
    
    }

    public override int GetWizardStaffPower()
    {
        return wizardStaffPower;
    }

    public override string HeroStats()
    {
        return "Hero Type: " + _heroType + "\nHealth: " + _health + "\nArmor: " + _armor + "\nWeapon: " + _weaponType + "\nWeapon Power: " + _weaponPower + "\nBonus: " + wizardStaff + "\nBonus Power: " + wizardStaffPower;
    }
}