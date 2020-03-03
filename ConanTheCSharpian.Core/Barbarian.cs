using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    class Barbarian : Hero
    {

        public Barbarian(Battleground battleground)
            : base(battleground)
        {
            Name = "Conan";
            MaxHealth = 60;
            Accuracy = 0.75f;
            AttackDamage = 32;
            SpecialActionName = "Enraged blow";
        }

        protected override void PerformMySpecialAction()
        {
            // Tell us what Barbarians do when performing special actions

            Console.WriteLine($"  {Name}: \"Now you make me angry.. TAKE THIS!\"");
            // TODO: implement that powerful thing
        }
    }
}
