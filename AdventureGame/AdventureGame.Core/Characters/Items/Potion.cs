using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Core.Characters;

namespace AdventureGame.Core.Items;

// Represents a potion item that restores health 
public class Potion:Item
{

    // Amount of health a potion restores
    public int HealAmount;

    // Creates a potion and sets how much health it restores
    public Potion(string name, int healAmount, string message)
        : base(name, 'P', message)

    { 
        HealAmount = healAmount;
    }

    // Applies the potion effect a restores health
    public override void Apply(Player player)
    {
        player.Heal(HealAmount);
    }
}