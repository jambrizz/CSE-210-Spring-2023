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

    private void SetWeaponPower(int weaponPower)
    {
        _weaponPower = weaponPower;
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

    public virtual int GetElfBowPower()
    {
        return 0;
    }

    public virtual int GetWizardStaffPower()
    {
        return 0;
    }
    
    public virtual void SetShieldPower(int number)
    {
        
    }

    public void CombatStats(int hero)
    {
        if(hero ==1)
        {
            Console.WriteLine();
            Console.WriteLine($"Hero Stats: \nHealth: {_health}\nArmor: {_armor}\nShield: {GetShieldPower()}\nWeapon Power: {_weaponPower}");
            Console.WriteLine();
        }
        else if(hero == 2)
        {
            Console.WriteLine();
            Console.WriteLine($"Hero Stats: \nHealth: {_health}\nArmor: {_armor}\nSword Power: {_weaponPower}\nBow Power: {GetElfBowPower()}");
            Console.WriteLine();
        }
        else if(hero == 3)
        {
            Console.WriteLine();
            Console.WriteLine($"Hero Stats: \nHealth: {_health}\nArmor: {_armor}\nSword Power: {_weaponPower}\nMagic Power: {GetWizardStaffPower()}");
            Console.WriteLine();
        }
    }

    public int combat(int hero, int rolledNumber, int enemyHealth)
    {
        Journey j = new Journey();
        int newEnemyHealth = 0;
        int attack = GetWeaponPower();
        if(hero == 1)
        {
            if(rolledNumber < 10)
            {
                Console.WriteLine();
                Console.WriteLine("You missed!");
                Console.WriteLine();
                newEnemyHealth = enemyHealth;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(rolledNumber >= 10 && rolledNumber <15)
            {
                Console.WriteLine();
                Console.WriteLine("You landed a glancing blow!");
                Console.WriteLine();
                int damage = attack / 3;
                if(damage > enemyHealth)
                {
                    newEnemyHealth = 0;
                }
                else
                {
                    newEnemyHealth = enemyHealth - damage;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(rolledNumber >= 15 && rolledNumber <=20)
            {
                Console.WriteLine();
                Console.WriteLine("You landed a critical!");
                Console.WriteLine();
                int damage = attack;
                if(damage > enemyHealth)
                {
                    newEnemyHealth = 0;
                }
                else
                {
                    newEnemyHealth = enemyHealth - damage;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        else if(hero == 2)
        {
            int bowAttack = GetElfBowPower();
            if(rolledNumber < 10)
            {
                Console.WriteLine();
                Console.WriteLine("You missed!");
                Console.WriteLine();
                newEnemyHealth = enemyHealth;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(rolledNumber >=10 && rolledNumber < 15)
            {
                Console.WriteLine();
                Console.WriteLine("You landed a glancing blow!");
                Console.WriteLine();
                int damage = attack / 2;
                if(damage > enemyHealth)
                {
                    newEnemyHealth = 0;
                }
                else
                {
                    newEnemyHealth = enemyHealth - damage;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(rolledNumber >=15 && rolledNumber <= 20)
            {
                Console.WriteLine();
                Console.WriteLine("You landed a critical!");
                Console.WriteLine();
                int damage = bowAttack;
                if(damage > enemyHealth)
                {
                    newEnemyHealth = 0;
                }
                else
                {
                    newEnemyHealth = enemyHealth - damage;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        else if(hero == 3)
        {
            int staffAttack = GetWizardStaffPower();
            if(rolledNumber < 10)
            {
                Console.WriteLine();
                Console.WriteLine("You missed!");
                Console.WriteLine();
                newEnemyHealth = enemyHealth;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(rolledNumber >= 10 && rolledNumber <15)
            {
                Console.WriteLine();
                Console.WriteLine("You landed a glancing blow!");
                Console.WriteLine();
                int damage = (attack / 4) * 3;
                if(damage > enemyHealth)
                {
                    newEnemyHealth = 0;
                }
                else
                {
                    newEnemyHealth = enemyHealth - damage;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(rolledNumber >= 15 && rolledNumber <=20)
            {
                Console.WriteLine();
                Console.WriteLine("You landed a critical!");
                Console.WriteLine();
                int damage = staffAttack;
                if(damage > enemyHealth)
                {
                    newEnemyHealth = 0;
                }
                else
                {
                    newEnemyHealth = enemyHealth - damage;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        return newEnemyHealth;
    }
    
    public void CombatDamage(int hero, int attackPower)
    {
        int armor = GetArmor();
        int health = GetHealth();

        if(hero == 1)
        {
            int shield = GetShieldPower();
    
            int newShield;
            int newArmor;
            int newHealth;

            if(shield > 0)
            {
                if(attackPower > shield)
                {
                    newShield = 0;
                    SetShieldPower(newShield);
                }
                else
                {
                    newShield = shield - attackPower;
                    SetShieldPower(newShield);
                }
            }
            else if(shield == 0 && armor > 0)
            {
                if(attackPower > armor)
                {
                    newArmor = 0;
                    SetArmor(newArmor);
                }
                else
                {
                    newArmor = armor - attackPower;
                    SetArmor(newArmor);
                }
            }
            else if(shield == 0 && armor == 0 && health >0)
            {
                if(attackPower > health)
                {
                    newHealth = 0;
                    SetHealth(newHealth);
                }
                else
                {
                    newHealth = health - attackPower;
                    SetHealth(newHealth);
                }
            }
            else if(shield == 0 && armor == 0 && health == 0)
            {
                HeroWasDefeated();
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
        else if(hero == 2)
        {
            if(armor > 0)
            {
                if(attackPower > armor)
                {
                    int newArmor = 0;
                    SetArmor(newArmor);
                }
                else
                {
                    int newArmor = armor - attackPower;
                    SetArmor(newArmor);
                }
            }
            else if(armor == 0 && health > 0)
            {
                if(attackPower > health)
                {
                    int newHealth = 0;
                    SetHealth(newHealth);
                }
                else
                {
                    int newHealth = health - attackPower;
                    SetHealth(newHealth);
                }
            }
            else if(armor == 0 && health == 0)
            {
                HeroWasDefeated();
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
        else if(hero == 3)
        {
           if(armor > 0)
            {
                if(attackPower > armor)
                {
                    int newArmor = 0;
                    SetArmor(newArmor);
                }
                else
                {
                    int newArmor = armor - attackPower;
                    SetArmor(newArmor);
                }
            }
            else if(armor == 0 && health > 0)
            {
                if(attackPower > health)
                {
                    int newHealth = 0;
                    SetHealth(newHealth);
                }
                else
                {
                    int newHealth = health - attackPower;
                    SetHealth(newHealth);
                }
            }
            else if(armor == 0 && health == 0)
            {
                HeroWasDefeated();
            }
            else
            {
                Console.WriteLine("Error!");
            } 
        }

    }

    public void AddPowerUp(string powerUp, int amount)
    {
        if(powerUp == "Health")
        {
            Console.WriteLine($"You have gained an increase of {amount} points in health!");
            Console.WriteLine();
            int startingHealth = GetHealth();
            int newHealth = startingHealth + amount;
            SetHealth(newHealth);
        }
        else if(powerUp == "Attack")
        {
            Console.WriteLine($"You have gained an increase of {amount} points in your attack!");
            Console.WriteLine();
            int startingAttack = GetWeaponPower();
            int newAttack = startingAttack + amount;
            SetWeaponPower(newAttack);
        }
        else if(powerUp == "Defense")
        {
            Console.WriteLine($"You have gained an increase of {amount} points in you armor!");
            Console.WriteLine();
            int startingDefense = GetArmor();
            int newDefense = startingDefense + amount;
            SetArmor(newDefense);
        }
    }

    public void HealthPenalty(int number)
    {
        Console.WriteLine($"You have lost {number} points in health!");
        int startingHealth = GetHealth();
        int newHealth = startingHealth - number;
        SetHealth(newHealth);
    }

    public void PowerUpOrPenalty(string text)
    {
        string key = text;

        string type = key.Substring(0, key.IndexOf("|"));
        string amount = key.Substring(key.IndexOf("|") + 1);

        int number = int.Parse(amount);
        //////////////////////////////////
        //TODO: Add conditional to apply power up or penalty
        //////////////////////////////////

        if(type == "Penalty")
        {
            HealthPenalty(number);
        }
        else
        {
            AddPowerUp(type, number);
        }
    }

    private void HeroWasDefeated()
    {
        Console.WriteLine();
        Console.WriteLine("You have been defeated!");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Environment.Exit(0);
    }
}

    