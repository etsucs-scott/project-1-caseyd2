using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core.Characters
{

    // defines what each character must have
    public interface ICharacter

    {
        // Character's name
        string Name { get; }

        // Current health
        int Health { get; } 

        // Maximun health
        int MaxHealth { get; }  

        // Attacks another character and return damage dealt 
        int Attack (ICharacter target);

        // Takes damage and lowers health
        void TakeDamage(int amount);
    }

}
