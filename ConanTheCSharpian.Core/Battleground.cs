using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConanTheCSharpian.Core.Characters;

namespace ConanTheCSharpian.Core
{
    /// <summary>
    /// Battleground in which the entire fighting thakes place.
    /// Contains the Characters and it's responsible for the whole battle simulation.
    /// </summary>
    public class Battleground // We need to declare it public if it want it to be accessible from other PROJECTS as well (such as ConanTheCSharpian.ConsoleApplication)
    {
        /// <summary>
        /// The array containing all the Characters that are involved in this battle
        /// </summary>
        private Character[] _characters;

        #region Character controllers

        private ICharacterController _player;
        private ICharacterController _ai;

        #endregion Character controllers

        /// <summary>
        /// Create and initialize proper instances for all the Characters that will fight in this game
        /// </summary>
        public void PlayTheGame(string controlledCharacterType, int amountOfAllies, int amountOfMonsters, ICharacterController player)
        {
            _characters = new Character[1 + amountOfAllies + amountOfMonsters]; // Initialize the array specifying the exact size we need it to be

            _characters[0] = Character.CreateNewCharacter(controlledCharacterType, this); // Create the player-controlled character

            // Create player allies
            for (int i = 1; i < 1 + amountOfAllies; i++)        
                _characters[i] = Character.CreateNewCharacter(true, this);

            // Create monsters
            for (int i = 1 + amountOfAllies; i < _characters.Length; i++)
                _characters[i] = Character.CreateNewCharacter(false, this);

            _player = player;
            _ai = new Ai();

            StartTheBattle();
        }

        /// <summary>
        /// Start the battle and keep it going until a team is defeated
        /// </summary>
        private void StartTheBattle()
        {
            do
            {
                PlayAGameTurn();

                Console.WriteLine("--- The turn has ended. Press a key to continue...");
                Console.ReadKey();
            } while (!IsTheGameFinished());
        }

        /// <summary>
        /// Play a single, entire game turn, letting all alive Characters to act,
        /// according to Player/AI decisions
        /// </summary>
        private void PlayAGameTurn()
        {
            if (!_characters[0].IsDead)
                _player.PerformNextAction(_characters[0]);

            for (int i = 1; i < _characters.Length; i++)
                if (!_characters[i].IsDead)
                    _ai.PerformNextAction(_characters[i]);
        }

        /// <summary>
        /// Returns <c>true</c> when one of the team is defeated
        /// </summary>
        private bool IsTheGameFinished()
        {
            IEnumerable<Character> heroes = GetAnEntireAliveTeam(true);
            if (heroes.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OH NO! THOSE CRUEL MONSTERS SLAINED OUR HONORABLE PARTY");
                return true;
            }

            IEnumerable<Character> monsters = GetAnEntireAliveTeam(false);
            if (monsters.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OUR MIGHTY HEROES WON!");
                return true;
            }

            return false;
        }

        internal Character GetRandomOpponent(Character caller)
        {
            #region Extended alternative to the line below
            //bool doIWantHeroes;
            //if (caller.IsAHero)
            //    doIWantHeroes = false;
            //else
            //    doIWantHeroes = true;
            #endregion Extended alternative to the line below

            bool doIWantHeroes = caller.IsAHero ? false : true;

            IEnumerable<Character> opponents = GetAnEntireAliveTeam(doIWantHeroes);

            if (opponents.Count() == 0)
                return null; // no opponents remained

            // Take a random Character from our opponents
            int randomIndex = new Random().Next(0, opponents.Count());
            return opponents.ElementAt(randomIndex);
        }

        private IEnumerable<Character> GetAnEntireAliveTeam(bool areTheyHeroes)
        {
            IEnumerable<Character> opponents = from character in _characters
                                               where (character.IsAHero == areTheyHeroes) && !character.IsDead
                                               select character;

            #region Alternative to the line above: same result, different syntax
            //IEnumerable<Character> opponents = _characters.Where(character => 
            //                                        (character.IsAHero == doIWantHeroes) // I would consider HEROES if the caller is a MONSTER, or MONSTERS if the caller is a HERO
            //                                        && !character.IsDead); // I'm also filtering those results excluding dead characters
            #endregion Alternative to the line above: same result, different syntax

            return opponents;
        }

        #region Pointless-but-informative methods

        // HACK: ADDITIONAL, EXTENDED INFORMATION ABOUT CASTING: https://stackoverflow.com/questions/15394032/difference-between-casting-and-using-the-convert-to-method

        /// <summary>
        /// This method is accessible from Battlegrounds only (it's PRIVATE), 
        /// accepts a characterName (string) as an input parameter,
        /// and returns a Character object to the caller
        /// </summary>
        private Character BoxingStuff(string characterName) // NOTE that even private method names are written in PascalCase
        {
            // I'm defining 2 variables here, one is less specific, the other is more specific
            // - their scope will be the BoxingStuff method: when it's called and it reaches those two lines, the variables will be created,
            //   when the methods ends its execution, they will both disappear and won't be accessible anymore from anywhere
            // - PAY ATTENTION: it's only the VARIABLE that will disappear (IE: genericObject), not necessarily its CONTENT (IE: I'm returning
            //   that "Generic Hero" Character to the caller of this method, and it can continue using it).
            // - When there's no other variable referencing our "Generic Hero", it will disappear as well
            Character specificObject;
            object genericObject;

            specificObject = new Barbarian(this); // That's the normal way of doing it
            genericObject = new Barbarian(this); // I CAN do that, since 'Character' INHERITS from 'object', as ANYTHING ELSE in C#. 
                                             // ^ This practice is called BOXING (like putting your stuff into a generic box)

            //specificObject = new Battleground(); // I CAN NOT do that, since Battleground IS NOT a Character, and my 'specificObject' variable can contain only Characters
            genericObject = new Battleground(); // I CAN do that as well, since 'Battleground' INHERITS from 'object', as ANYTHING ELSE in C#
            genericObject = 53; // I CAN do that as well, since 'int' INHERITS from 'object', as ANYTHING ELSE in C#
            genericObject = "I'm a nice egg"; // I CAN do that as well, since 'string' INHERITS from 'object', as ANYTHING ELSE in C#

            specificObject.Accuracy = 0.25f;
            //genericObject.Name = characterName; // I CAN NOT do that, since 'object' does not have any field named "Name"
            if (genericObject is Character)
                ((Character)genericObject).Accuracy = 0.25f; // To be able to do that, I have to CAST it, basically telling the compiler:
                                                                 // "Listen, I know this variable deals with generic objects, 
                                                                 // BUT I'M SURE it now contains a Character, so please treat it like that
                                                                 // and allow me to access its methods and fields"
                                                                 // WARNING: if for any reason there's not a Character inside of that variable,
                                                                 // the whole program will explode.
                                                                 // ^ This practice is called UNBOXING

            // Please also note that BOXING/UNBOXING is a memory/performance consuming task

            // DO NOT USE IT unless you have an extremely valid reason to do that (IE: you really have no other options)

            return specificObject;
        }

        #endregion Pointless-but-informative methods
    }
}
