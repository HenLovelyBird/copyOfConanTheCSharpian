using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    abstract class Hero : Character
    {
        public Hero(Battleground battleground)
            : base(battleground)
        {
            
        }
    }
}
