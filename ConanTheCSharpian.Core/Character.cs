using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    /// <summary>
    /// Basic Character that acts in our game
    /// </summary>
    public abstract class Character // it implicitely derives from object - like Character : object
    {
        #region Fields

        private float _currentHealth = float.MaxValue; // backing, private field for our CurrentHealth Property
                                                       // We initially set it to float.MaxValue to avoid the Character being considered Dead

        /// <summary>
        /// The current health of our Character
        /// </summary>
        public float CurrentHealth
        {
            get
            {
                return _currentHealth;
            }
            protected set
            {
                // This way we can have more control for when this field is set:
                // for instance, we can prevent healing a Character if he/she's already dead..
                if (_currentHealth <= 0)
                    return;
                
                _currentHealth = value;

                // ..and going over its max allowed value:
                if (_currentHealth > MaxHealth)
                    _currentHealth = MaxHealth;

                // Check if it has just died
                if (_currentHealth <= 0)
                {
                    if (IsAHero)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{ExtendedName} has just perished. We'll be missing him.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{ExtendedName} has been slained. Well done!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        #region Alternative, ugly way to control get/set of a field
        //public float GetCurrentHealth()
        //{
        //    return _currentHealth;
        //}

        //public void SetCurrentHealth(float newValue)
        //{
        //    if (_currentHealth <= 0)
        //        return;

        //    _currentHealth = newValue;
        //}
        #endregion Alternative, ugly way to control get/set of a field

        private float _maxHealth;

        /// <summary>
        /// The maximum health of our Character
        /// </summary>
        public float MaxHealth 
        {
            get
            {
                return _maxHealth;
            }
            protected set
            {
                _maxHealth = value;
                _currentHealth = value;
            }
        }

        /// <summary>
        /// The name of our Character
        /// </summary>
        public string Name { get; protected set; }  // This is a shorter way to define a Property that only needs to specify get/set accessibility
                                                    // This Property is PUBLICLY READABLE, but only Characters and its child classes can SET IT

        public string ExtendedName { get { return $"{Name} the {this.GetType().Name}"; } }

        /// <summary>
        /// Damage dealt by this Character with a successful blow
        /// </summary>
        public float AttackDamage; // This is a public field; not specifying any value equals to writing: AttackDamage = 0

        /// <summary>
        /// Chance to deal a successful blow (ranging from 0 to 1)
        /// </summary>
        public float Accuracy; // NC: public fields require PascalCase (first letter is Uppercase)

        public string SpecialActionName { get; protected set; }

        /// <summary>
        /// Internally determines if he/she's a Hero based on the fact its Class inherits from Hero
        /// </summary>
        public bool IsAHero
        {
            get { return this is Hero; }
        }

        private Battleground _battleground;

        #endregion Fields


        #region Constructor & character creation

        public Character(Battleground battleground)
        {
            _battleground = battleground;
        }


        // METHOD OVERLOADING:
        // We can define multiple versions of the same method that take different parameters

        // STATIC:
        // Static members are part of the CLASS itself, not specific to some INSTANCE of it
        // They are accessible through: Character.CreateNewCharacter(...) and NOT someFightingCharacter.CreateNewCharacter(...)
        // They exist and can be called even if no instance of this class exists at all

        public static Character CreateNewCharacter(bool isHeAHero, Battleground battleground)
        {
            // Choose character type randomly
            string[] typesToChooseFrom;
            if (isHeAHero)
                typesToChooseFrom = _heroTypes;
            else
                typesToChooseFrom = _monsterTypes;

            int randomIndex = new Random().Next(0, typesToChooseFrom.Length);
            string characterType = typesToChooseFrom[randomIndex];
            return CreateNewCharacter(characterType, battleground);
        }

        private static string[] _heroTypes = { "barbarian", "wizard", "ranger", "paladin" };
        private static string[] _monsterTypes = { "goblin", "troll", "warlock" };

        public static Character CreateNewCharacter(string characterType, Battleground battleground)
        {
            characterType = characterType.ToLower();
            switch (characterType)
            {
                case "barbarian": return new Barbarian(battleground);
                case "wizard": return new Wizard(battleground);
                case "ranger": return new Ranger(battleground);
                case "paladin": return new Paladin(battleground);
                case "goblin": return new Goblin(battleground);
                case "troll": return new Troll(battleground);
                case "warlock": return new Warlock(battleground);
            }

            return null;
        }

        /// <summary>
        /// If we want to be REAL BADASS and not to depend on the ugly switch-case above,
        /// we could use Reflection to create specific Character instances just by knowing their class name.
        /// 
        /// This is somehow slower, but would let us to really don't have to change ANYTHING in ANY OTHER CLASS
        /// when adding a new Character type class (IE: Ogre, Thief, Bandit, Cleric..)
        /// </summary>
        public static Character CreateNewCharacterUsingReflection(string characterType, Battleground battleground)
        {
            // We need the name in the proper case, IE: barBARIAn -> Barbarian
            characterType = characterType.ToLower();
            characterType = characterType[0].ToString().ToUpper() + characterType.Substring(1, characterType.Length - 1);

            // Find the Type we want to instantiate
            Type typeToIstantiate = Type.GetType($"ConanTheCSharpian.Core.Characters.{characterType}");

            // Create a new instance, by providing its Type and the parameter required by its constructor (so, the Battleground)
            return (Character)Activator.CreateInstance(typeToIstantiate, battleground);
        }

        #endregion Constructor & character creation


        #region Methods

        /// <summary>
        /// The Characters tries to inflict damage to a random opponent
        /// </summary>
        public void PerformMainAttack() // this method doesn't return anything to the caller, so that's a "void"
        {

            Character opponentToAttack =_battleground.GetRandomOpponent(this);
            if (opponentToAttack == null)
            {
                WriteColoredNameInTheConsole();
                Console.WriteLine($" has no more opponents to attack.");
                return;
            }

            float damageDealt = TryToDamageAnOpponent(opponentToAttack, Accuracy, AttackDamage);

            WriteColoredNameInTheConsole();
            if (damageDealt > 0)
            {
                Console.Write(" attacked ");
                opponentToAttack.WriteColoredNameInTheConsole();
                Console.WriteLine($" for {damageDealt} damage! ({opponentToAttack.CurrentHealth}/{opponentToAttack.MaxHealth} HP)");
            }
            else
            {
                Console.Write(" tried to attack ");
                opponentToAttack.WriteColoredNameInTheConsole();
                Console.WriteLine(", but he missed.");
            }
        }

        private float TryToDamageAnOpponent(Character opponentToAttack, float accuracy, float damage)
        {
            // Let's see if we're able to hit
            double randomChance = new Random().NextDouble();
            if (randomChance > accuracy)
                return 0;

            opponentToAttack.CurrentHealth -= damage;
            return damage;
        }

        /// <summary>
        /// The Characters uses his/her special action in battle
        /// </summary>
        public void PerformSpecialAction() // this method doesn't return anything to the caller, so that's a "void"
        {
            WriteColoredNameInTheConsole();
            Console.WriteLine(" is performing his special action:");

            PerformMySpecialAction(); // Call the specific implementation based on the actual type (Barbarian, Wizard, Troll..)
        }

        protected void WriteColoredNameInTheConsole()
        {
            // We shouldn't do that: Console is something that shouldn't belong to this .Core library.
            // Just don't tell it to the client...

            Console.ForegroundColor = IsAHero ? ConsoleColor.Yellow : ConsoleColor.DarkYellow;
            Console.Write(ExtendedName);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        protected abstract void PerformMySpecialAction(); // Forces any concrete implementation of this class to specify its own code for performing their special action

        /// <summary>
        /// Determine if a Character is already dead
        /// </summary>
        public bool IsDead
        {
            get { return CurrentHealth <= 0; }
        }

        #endregion Methods
    }
}
