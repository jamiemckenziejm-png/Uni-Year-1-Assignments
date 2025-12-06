using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CET1004_Assignment1
{
    internal class GameRules
    {
        //=============================================
        // Method to display the game rules to the user
        //=============================================
        public static void DisplayGameRules()
        {
            GameTitle.DisplayGameTitle();
            Console.WriteLine("GAME RULES:");
            Console.WriteLine("\n 1. The game is played between two players (Player A = you : Player B = the computer) over 3 rounds");
            Console.WriteLine("\n 2. Each player will start the round having 2 dice rolled for them.");
            Console.WriteLine("\n 3. Player A will choose each round to 'STICK' with the score they have or to 'RE-ROLL' the dice with the lowest value.");
            Console.WriteLine("\n 4. Player B will always 'RE-ROLL' if there score is less than 6 and always 'STICK' if higher than 5.");
            Console.WriteLine("\n 5. Each roll for both players will be recorded inlcuding a Total Score.");
            Console.WriteLine("\n 6. Results will be displayed at the end of each round and the final results at the end of the game.");
            Console.WriteLine("\n 7. The player with the highest Total Score after 3 rounds wins the game.");
            Console.WriteLine("\n 8. In The event of a tie, the player whole rolled the most 6's will be declared the winner.");
            Console.WriteLine("\n 9. In the unlikely event that both players have tied on both score and 6's rolled the game will restart.");
            Console.WriteLine("\n\n GOOD LUCK....\tHAVE FUN!....\tAND MAY THE ROLLS BE EVER IN YOUR FAVOUR");
            Console.WriteLine("\n\n\n PRESS ANY KEY TO START THE GAME...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
