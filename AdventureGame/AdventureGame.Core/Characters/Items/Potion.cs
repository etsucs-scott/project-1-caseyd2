using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Core.Characters;

namespace AdventureGame.Core.Items;

public class Potion:Item
{
    public int HealAmount;

    // Creates a potion and sets how much health it restores
    public Potion(string name, int healAmount, string message)
        : base(name, 'P', message)

    { 
        HealAmount = healAmount;
    }

    public override void Apply(Player player)
    {
        player.Heal(HealAmount);
    }
}