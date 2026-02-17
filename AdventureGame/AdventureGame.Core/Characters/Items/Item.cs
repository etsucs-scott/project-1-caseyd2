using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Core.Characters;

namespace AdventureGame.Core.Items;

// Base case for all of the items 
public abstract class Item
{
    // Name of the item
    public string Name;
    public char Symbol;

    // Message shown when the item is picked up
    public string PickupMessage;

    // Created a new item and sets value
    public Item (string name,  char symbol, string message)
   
            {       
            Name = name;
            Symbol = Symbol;
            PickupMessage = message;
            }

    public abstract void Apply(Player player);
}