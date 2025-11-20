using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CET1004_Assignment1
{
    internal class Player_name
    {

        // Private playername variable
        public static string PlayerName;

        // Constructor with parameter
        public Player_name(string psPlayerName)
        {
            PlayerName = psPlayerName;
        }

        // Default constructor
        public Player_name()
        {
            PlayerName = "Player";
        }

        // Getter and Setter methods
        public string GetPlayerName()
        {
            return PlayerName;
        }
        public void SetPlayerName(string psPlayerName)
        {
            PlayerName = psPlayerName;
        }

        // Static method to retrieve player name
        public static void Retrieve_Name()
        {
            GameTitle.DisplayGameTitle();

            // Prompt user to enter name
            Console.Write("Please enter your name: ");

            // Create Player Object and pass user input to constructor
            Player_name Player1 = new Player_name(Console.ReadLine());

            // Call WelcomePlayer method from Player Object
            Player1.WelcomePlayer();

        }
        // Method to welcome player
        public void WelcomePlayer()
        {

            // Welcome Message calling player name from Player Object
            Console.WriteLine("\nHello " + PlayerName + ", Welcome to the DICE BATTLE GAME!! \n");

            // obtain input from user before clering the console and moving to the next method
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
