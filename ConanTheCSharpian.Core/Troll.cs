using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Troll : Monster
    {
        public Troll(Battleground battleground)
            : base(battleground)
        {
            Name = "Daniele";
            MaxHealth = 120;
            Accuracy = 0.6f;
            AttackDamage = 50;
            SpecialActionName = "Massive smash";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Trolls do when performing special actions

            Console.WriteLine($"  {Name}: \"UGH! ME CRASH YOU HEAD!\"");
            // TODO: implement that scary thing
        }
    }
}
