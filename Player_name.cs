using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Player_name
    {

        // Private playername variable
        private string sPlayerName;

        // Constructor with parameter
        public Player_name(string psPlayerName)
        {
            sPlayerName = psPlayerName;
        }

        // Default constructor
        public Player_name()
        {
            sPlayerName = "Player";
        }

        // Getter and Setter methods
        public string GetPlayerName()
        {
            return sPlayerName;
        }
        public void SetPlayerName(string psPlayerName)
        {
            sPlayerName = psPlayerName;
        }


        public void WelcomePlayer()
        {

            // Welcome Message calling player name from Player Object
            Console.WriteLine("\nHello " + sPlayerName + ", Welcome to the DICE BATTLE GAME!! \n");

            // obtain input from user before clering the console and moving to the next method
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
