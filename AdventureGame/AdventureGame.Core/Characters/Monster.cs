using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core.Characters
{
 // represents an enemy in the game
    public class Monster : ICharacter
    {
        // monster name
        public string Name { get; set; }

        // current health
        public int Health { get; private set; }

        // maximun health
        public int MaxHealth { get; private set; }


        // sets the monster's name and health
        public Monster(string name, int health)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
        }

        // reduces health when the monster takes damage
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        // attacks another character and gives damage points 
        public int Attack(ICharacter target)
        {
            int damage = 10;
            target.TakeDamage(damage);
            return damage;
        }
    }

}