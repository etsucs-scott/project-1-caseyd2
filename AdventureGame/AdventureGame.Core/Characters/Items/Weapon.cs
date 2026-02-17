using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Core.Characters;

namespace AdventureGame.Core.Items;

public class Weapon : Item
{
    public int AttackModifier;

    // Creates a weapon and sets how much damage it gives
    public Weapon(string name, int attackModifier, string message)
        : base(name, 'W', message)
    {
        AttackModifier = attackModifier;
    }

    public override void Apply(Player player)

    {
        player.AttackPower += AttackModifier;
    }
}
