using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core.Engine
{
    // Stores the result of a player move
   public class MoveResult
    {
        // true if the player moved to new position
        public bool Moved {  get; set; }

        // true if the player reached the exit and won 
        public bool Won { get; set; }

        // true if the player died 
        public bool Died { get; set; }

        // Message describing what happened during the move
        public string Message { get; set; } = "";
    }
}
