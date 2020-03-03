using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Ranger : Hero
    {
        public Ranger(Battleground battleground)
            : base(battleground)
        {
            Name = "Heni";
            MaxHealth = 50;
            Accuracy = 0.9f;
            AttackDamage = 25;
            SpecialActionName = "Triple shot";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Rangers do when performing special actions

            Console.WriteLine($"  {Name}: \"Look how I now pierce three of them!\"");
            // TODO: implement that powerful thing
        }
    }
}
