using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Paladin : Hero
    {
        public Paladin(Battleground battleground)
            : base(battleground)
        {
            Name = "Faina";
            MaxHealth = 65;
            Accuracy = 0.70f;
            AttackDamage = 35;
            SpecialActionName = "Bless";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Paladins do when performing special actions

            Console.WriteLine($"  {Name}: \"I bleess thee, my honorable friend!\"");
            // TODO: implement that powerful thing
        }
    }
}
