using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureGame.Core.Items;
using System.Collections.Generic;

namespace AdventureGame.Core.Characters;

// represents the player charaxter in the gane
public class Player : ICharacter
{

    // player name
    public string Name { get; set; }

    // current health
    public int Health { get; private set; }

    // maximun health
    public int MaxHealth { get; private set; }

    // Base attack power of the player
    public int AttackPower { get; set; }

    // List of weapons collected
    public List<Weapon> Inventory { get; private set; }

    // Initialize stats
        public Player(string name)
    {
        Name = name;
        MaxHealth = 150;
        Health = 100;
        AttackPower = 10;
        Inventory = new List<Weapon>();
    }
    
    // Reduces health when the player takes damage
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0; 
    }

    // Heals the player by a certain amount 
    public void Heal(int amount)
    {
        Health += amount;
        // Prevents health from exceeding the max
        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public void AddWeapon(Weapon weapon)
    {
        Inventory.Add(weapon);
    }

    // Returns the highest weapon attack in the players inventory
    public int GetBestWeaponModifier()
    {
        // If the player has no weapons, the modifier is 0
        if (Inventory.Count == 0)
        {
            return 0;
        }
        
        // find the weapon with the highest attack modifier
        return Inventory.Max(w => w.AttackModifier);
    }


    // Attacks another character using AttackPower and return the damage given
    public int Attack(ICharacter target)
    {
        // base attack plus the best weapon
        int damage = AttackPower + GetBestWeaponModifier();
        // Apply damage to the target
        target.TakeDamage(damage);

        return damage;
    }
}

