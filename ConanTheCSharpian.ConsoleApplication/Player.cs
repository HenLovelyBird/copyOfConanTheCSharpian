using ConanTheCSharpian.Core.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.ConsoleApplication
{
    /// <summary>
    /// Player entity, that lets the application user to perform choices
    /// 
    /// NOTE: this Class is defined OUTSIDE our Core library, but 
    ///       AS LONG AS IT IMPLEMENTS THE ICharacterController INTERFACE IT CAN BE USED FROM THERE AS WELL.
    ///       This allows us to re-use our Core library for other Projects (IE: WebApplication) as long as they
    ///       provide their own implementation for a ICharacterController.
    /// </summary>
    class Player : ICharacterController
    {

        public void PerformNextAction(Character characterInTurn)
        {
            // HACK: three different ways to format a string:

            // Console.WriteLine("It's " + characterInTurn.Name + " turn: please type 'A' for main attack or 'S' for special action");
            // Console.WriteLine(string.Format("It's {0} turn: please type 'A' for main attack or 'S' for special action", characterInTurn.Name));
            Console.WriteLine($"It's {characterInTurn.Name} turn: please type 'A' for main attack or 'S' for \"{characterInTurn.SpecialActionName}\"");

            while (true)
            {
                string choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "ATTACK":
                    case "A":
                        characterInTurn.PerformMainAttack();
                        return;
                    case "SPECIAL":
                    case "S":
                        characterInTurn.PerformSpecialAction();
                        return;
                    default:
                        Console.WriteLine("Please, select 'A' or 'S'.");
                        break;
                }
            }
        }
    }
}
