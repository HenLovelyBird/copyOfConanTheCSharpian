using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    abstract class Monster : Character
    {
        public Monster(Battleground battleground)
            : base(battleground)
        {
            
        }
    }
}
