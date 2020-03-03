using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Warlock : Monster
    {
        public Warlock(Battleground battleground)
            : base(battleground)
        {
            Name = "Saruman";
            MaxHealth = 40;
            Accuracy = 0.9f;
            AttackDamage = 40;
            SpecialActionName = "Goblin summoning";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Warlocks do when performing special actions

            Console.WriteLine($"  {Name}: \"Whahahah! I'm summoning a new Goblin!\"");
            // TODO: implement that scary thing
        }
    }
}
