using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Character
{
   protected string _heroType;

   protected int _heroSelected;

   protected int _health;

   protected int _armor;

   protected string _weaponType;

   protected int _weaponPower;

   public Character(int selection)
   {
      _heroSelected = selection;
   }

   public Character(int health, int armor)
   {
        _health = health;
        _armor = armor;
   }

   public virtual string HeroStats()
    {
        return "";
    }

    private void SetHealth(int health)
    {
        _health = health;
    }

    private void SetArmor(int armor)
    {
        _armor = armor;
    }
     
}