using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Wizard : Hero
    {
        public Wizard(Battleground battleground)
            : base(battleground)
        {
            Name = "Tash";
            MaxHealth = 40;
            Accuracy = 0.85f;
            AttackDamage = 28;
            SpecialActionName = "Healing spell";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Wizards do when performing special actions

            Console.WriteLine($"  {Name}: \"I think somebody could use a healing spell..\"");
            // TODO: implement that powerful thing
        }
    }
}
