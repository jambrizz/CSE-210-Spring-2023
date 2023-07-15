using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Wizard: Character
{
  private string wizardStaff = "Staff of the Magi";

    private int wizardStaffPower = 70;

    private List<string> _wizardMessages = new List<string>()
    {
        "You jump out of the way!",
        "You dodge the attack!",
        "You block the attack!",
        "You take the hit!",
        "You take a critical hit!",
        "You take a glancing blow!",
        "You landed a critical hit with the Staff of the Magi!",
        "You landed a glancing blow!",
        "You landed a solid hit with your Short Sword!",
        "You missed!"
    };

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