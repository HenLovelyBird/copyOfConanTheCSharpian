using System;
using ConanTheCSharpian.Core; // We added this 'using' directive to avoid having to write Core.Battleground instead of Battleground alone (they live in different namespaces)

namespace ConanTheCSharpian.ConsoleApplication
{
    /// <summary>
    /// The console application in which our game is hosted
    /// </summary>
    class ConsoleApplication
    {
        /// <summary>
        /// Entry point for our console application (= the first line that get executed when the application starts)
        /// </summary>
        static void Main(string[] args)
        {
            DisplayGameTitle(); // Sorry, I had to to that

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Conan the CSharpian game!"); // Console (System.Console) is an helper class provided by .NET Core that let us interact with the console itself

            // NOTE: to be able to access to Battleground class, 
            // we have to set the ConanTheCSharpian.Core project as a DEPENDENCY for the ConanTheCSharpian.ConsoleApplication project:
            // Solution explorer -> ConanTheCSharpian.ConsoleApplication -> Dependencies -> Add reference -> Projects -> Tick the 'ConanTheCSharpian.Core' project


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please select your hero: barbarian | wizard | ranger | paladin");
            string characterType = Console.ReadLine(); // Wait for the user input, and when he/she presses enter take the whole string and assign it to the characterType variable
            
            Console.WriteLine("How many allies do you want to have?");
            int numberOfAllies = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many monsters do you want to face?");
            int numberOfMonsters = Convert.ToInt32(Console.ReadLine());

            Battleground battleground = new Battleground();
            Player player = new Player();
            battleground.PlayTheGame(characterType, numberOfAllies, numberOfMonsters, player);
        }


        private static void DisplayGameTitle()
        {
            Console.WriteLine(@"                     ___
       .----.      __) `\      ___ ___  _ __   __ _ _ __  
       | == |     < __=- |    / __/ _ \| '_ \ / _` | '_ \ 
    ___| :: |___   \\ `)/    | (_| (_) | | | | (_| | | | | 
    \  `----'  /\  (\) (      \___\___/|_| |_|\__,_|_| |_|        
     \   `.   /( \/ /\\
     |    :   | \  /  \\            the CSharpian
     \   _._  /  `""   <_>
      xxx(o)xx

            ");
        }
    }
}
