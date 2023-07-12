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

   public Character()
   {
    
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
     
    public int GetHealth()
    {
       return _health;
    }

    public int GetArmor()
    {
        return _armor;
    }

    public int GetWeaponPower()
    {
        return _weaponPower;
    }

    public virtual int GetShieldPower()
    {
        return 0;
    }
    
    public virtual void SetShieldPower(int number)
    {
        
    }
    

    public void CombatDamage(string type, int number)
    {
        if (type == "health")
        {
            SetHealth(number);
        }
        else if (type == "armor")
        {
            SetArmor(number);
        }
        else if (type == "shield")
        {
            SetShieldPower(number);
        }
    }
}

    