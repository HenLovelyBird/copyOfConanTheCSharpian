/*

    LET'S FINISH THIS TOGETHER:

---- Ex1: --------------------------------------------------------------------------------------------------------------------------------------

    We forgot to re-implement Battleground -> IsTheGameFinished()

    Please take care of that!


---- Ex2: --------------------------------------------------------------------------------------------------------------------------------------

    We still need to implement main attack damage.

    When attacking, a Character should randomly determine if it's a hit or miss, based on his/her accuracy.
    IE: a Barbarian, with 0.75 of Accuracy, will hit 75% of the times.

    When successfully attacking, we want to read a line in the console stating:
    "X attacks Y for Z damage!"

    The CurrentHealth of the attacked Character should be lowered accordingly.

    When failing to hit, we want to read a line in the console stating:
    "X tried to attack Y, but he missed."

    >>> EXCELLENT WORK, FAINA <<<


---- Ex3: --------------------------------------------------------------------------------------------------------------------------------------

    When a Character dies, we want to read a line in the console stating:
    "X has just perished. We'll be missing him." if he/she's a Hero
    or
    "X has been slained. Well done!" if he/she's a Monster


---- Ex4: --------------------------------------------------------------------------------------------------------------------------------------

    Our lovely client just called during our lunch break, politely asking for a couple of new features.

    We should introduce a new class, the Paladin, who's going to bless his allies, increasing their damage for a couple of turns.
    [Console.WriteLine("I bleess thee, my honorable friend!"); would simply be enough]


---- Ex5: --------------------------------------------------------------------------------------------------------------------------------------

    He also want that when the user is supposed to make a choice on the next attack, we change the currently displayed line from:

    "It's X turn: please type 'A' for main attack or 'S' for special action"

    to:
    
    "It's X turn: please type 'A' for main attack or 'S' for special action (SPECIAL_ACTION_NAME)"

    Where SPECIAL_ACTION_NAME is one of the following:
    
    Barbarian: "Enraged blow"
    Wizard: "Healing spell"
    Ranger: "Triple shot"
    Paladin: "Bless"
    Goblin: "Double attack"
    Troll: "Massive smash"
    Warlock: "Goblin summoning"

*/