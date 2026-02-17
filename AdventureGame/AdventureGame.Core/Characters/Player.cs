using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureGame.Core.Items;
using System.Collections.Generic;

namespace AdventureGame.Core.Characters;

// represents the player
public class Player : ICharacter
{

    // player name
    public string Name { get; set; }

    // current health
    public int Health { get; private set; }

    // maximun health
    public int MaxHealth { get; private set; }

    // amount of damage per attack
    public int AttackPower { get; set; }
        public Player(string name)
    {
        Name = name;
        MaxHealth = 100;
        Health = 100;
        AttackPower = 10;
    }

    // sets the player's name and starting health
    
    // Reduces health when the player takes damage
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0; 
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    // Attacks another character using AttackPower and return the damage given
    public int Attack(ICharacter target)
    {
        int damage = AttackPower;
        target.TakeDamage(damage);
        return damage;
    }
}

