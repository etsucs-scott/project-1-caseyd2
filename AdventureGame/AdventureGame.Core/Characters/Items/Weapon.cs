using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Core.Characters;

namespace AdventureGame.Core.Items;

// represents a weapon that increases the attack options
public class Weapon : Item
{
    // Extra value the weapon can provide
    public int AttackModifier;

    // Creates a weapon and sets how much damage it gives
    public Weapon(string name, int attackModifier, string message)
        : base(name, 'W', message)
    {
        AttackModifier = attackModifier;
    }

    // Adds weapon to players inventory
    public override void Apply(Player player)

    {
        player.AddWeapon(this);
    }
}
