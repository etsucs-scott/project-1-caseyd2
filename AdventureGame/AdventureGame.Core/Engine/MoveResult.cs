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
        public bool Moved {  get; set; }
        public bool Won { get; set; }
        public bool Died { get; set; }
        public string Message { get; set; } = "";
    }
}
