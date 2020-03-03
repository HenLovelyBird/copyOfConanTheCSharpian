using ConanTheCSharpian.Core.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core
{
    /// <summary>
    /// AI that controls Player allies and Monsters
    /// </summary>
    class Ai : ICharacterController
    {
        public void PerformNextAction(Character characterInTurn)
        {
            bool specialAction = new Random().Next(4) == 0;

            if (specialAction)
                characterInTurn.PerformSpecialAction();
            else
                characterInTurn.PerformMainAttack();
        }
    }
}
