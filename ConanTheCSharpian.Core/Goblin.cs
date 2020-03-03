using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Goblin : Monster
    {
        public Goblin(Battleground battleground)
            : base(battleground)
        {
            Name = "Diego";
            MaxHealth = 31;
            Accuracy = 0.75f;
            AttackDamage = 25;
            SpecialActionName = "Double attack";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Goblins do when performing special actions

            Console.WriteLine($"  {Name}: \"Hah! Let's see if I you can stand my double attack!\"");
            // TODO: implement that scary thing
        }
    }
}
