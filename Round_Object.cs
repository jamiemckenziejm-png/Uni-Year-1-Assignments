using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Round_Object
    {
        // Private variables
        public int RoundNumber; // done
        public int PlayerA_RoundScore; //done
        public int PlayerB_RoundScore; // done
        public string Player_choice; // done
        public int PlayerA_Die1; // done
        public int PlayerA_Die2;// done
        public int PlayerA_Die3;
        public int PlayerB_Die1;
        public int PlayerB_Die2;
        public int PlayerB_Die3;
        public int PlayerA_Sixes;
        public int PlayerB_Sixes;

        //// Constructor
        //public Round_Object(int iroundNumber, int iplayerA_RoundScore, int iplayerB_RoundScore, string splayer_choice, int iplayer_Die1, int iplayer_Die2, int iplayers_Reroll, int iplayerB_Die1, int iplayerB_Die2, int iplayerBs_Reroll, int iplayerA_Sixes, int iplayerB_Sixes)
        //{
        //    RoundNumber = iroundNumber;
        //    PlayerA_RoundScore = iplayerA_RoundScore;
        //    PlayerB_RoundScore = iplayerB_RoundScore;
        //    Player_choice = splayer_choice;
        //    Player_Die1 = iplayer_Die1;
        //    Player_Die2 = iplayer_Die2;
        //    Players_Reroll = iplayers_Reroll;
        //    PlayerB_Die1 = iplayerB_Die1;
        //    PlayerB_Die2 = iplayerB_Die2;
        //    PlayerBs_Reroll = iplayerBs_Reroll;
        //    PlayerA_Sixes = iplayerA_Sixes;
        //    PlayerB_Sixes = iplayerB_Sixes;
        //}
        // Default constructor
        public Round_Object()
        {
            RoundNumber = 0;
            PlayerA_RoundScore = 0;
            PlayerB_RoundScore = 0;
            Player_choice = "";
            PlayerA_Die1 = 0;
            PlayerA_Die2 = 0;
            PlayerA_Die3 = 0;
            PlayerB_Die1 = 0;
            PlayerB_Die2 = 0;
            PlayerB_Die3 = 0;
            PlayerA_Sixes = 0;
            PlayerB_Sixes = 0;
        }

        // Getter methods
        public int GetRoundNumber() 
        {
            return RoundNumber; 
        }
        public int GetPlayerA_RoundScore() 
        { 
            return PlayerA_RoundScore;
        }
        public int GetPlayerB_RoundScore() 
        {
            return PlayerB_RoundScore;
        }
        public string GetPlayer_choice() 
        {
            return Player_choice;
        }
        public int GetPlayerADie1() 
        {
            return PlayerA_Die1;
        }
        public int GetPlayerA_Die2() 
        {
            return PlayerA_Die2;
        }
        public int GetPlayerA_Die3()
        {
            return PlayerA_Die3;
        }
        public int GetPlayerB_Die1()
        {
            return PlayerB_Die1;
        }
        public int GetPlayerB_Die2()
        {
            return PlayerB_Die2; 
        }
        public int GetPlayerB_Die3() 
        {
            return PlayerB_Die3;
        }
        public int GetPlayerA_Sixes()
        {
            return PlayerA_Sixes;
        }
        public int GetPlayerB_Sixes()
        {
            return PlayerB_Sixes;
        }

        // Setter methods
        public void SetRoundNumber(int iroundNumber) 
        {
            RoundNumber = iroundNumber;
        }
        public void SetPlayerA_RoundScore(int iplayerA_RoundScore) 
        {
            PlayerA_RoundScore = iplayerA_RoundScore;
        }
        public void SetPlayerB_RoundScore(int iplayerB_RoundScore) 
        {
            PlayerB_RoundScore = iplayerB_RoundScore;
        }
        public void SetPlayer_choice(string splayer_choice) 
        {
            Player_choice = splayer_choice;
        }
        public void SetPlayerA_Die1(int iplayerA_Die1) 
        {
            PlayerA_Die1 = iplayerA_Die1;
        }
        public void SetPlayerA_Die2(int iplayerA_Die2) 
        {
            PlayerA_Die2 = iplayerA_Die2;
        }
        public void SetPlayerA_Die3(int iplayerA_Die3) 
        {
            PlayerA_Die3 = iplayerA_Die3;
        }
        public void SetPlayerB_Die1(int iplayerB_Die1) 
        {
            PlayerB_Die1 = iplayerB_Die1;
        }
        public void SetPlayerB_Die2(int iplayerB_Die2) 
        {
            PlayerB_Die2 = iplayerB_Die2;
        }
        public void SetPlayerB_Die3(int iplayerB_Die3) 
        {
            PlayerB_Die3 = iplayerB_Die3;
        }
        public void SetPlayerA_TotalSixes(int iplayerA_Sixes) 
        {
            PlayerA_Sixes = iplayerA_Sixes;
        }
        public void SetPlayerB_TotalSixes(int iplayerB_Sixes) 
        {
            PlayerB_Sixes = iplayerB_Sixes;
        }

        // Method to display round summary
        public void DisplayRoundSummary()
        {
            Console.WriteLine($"\n--- Round {RoundNumber} Summary ---");
            Console.WriteLine($"\nPlayer A Dice Rolls: {PlayerA_Die1}, {PlayerA_Die2}");
            Console.WriteLine($"Player A Chose to {Player_choice} in this round");
            if (PlayerA_Die3 != 0 && PlayerA_Die1 < PlayerA_Die2)
            {
                Console.WriteLine($"Player A Re-Rolled and got: {PlayerA_Die2}, {PlayerA_Die3}");
            }
            if (PlayerA_Die3 != 0 && PlayerA_Die2 < PlayerA_Die1)
            {
                Console.WriteLine($"Player A Re-Rolled and got: {PlayerA_Die1}, {PlayerA_Die3}");
            }
                
            Console.WriteLine($"Player A Rolled {PlayerA_Sixes} six's");
            Console.WriteLine($"\nPlayer A's Round Score: {PlayerA_RoundScore}");
            Console.WriteLine($"Player B Dice: {PlayerB_Die1}, {PlayerB_Die2}");
            if (PlayerB_RoundScore < 6 && PlayerB_Die1 < PlayerB_Die2)
            {
                Console.WriteLine($"However, Player B scored less than six and therefore Re-Rolled and got: {PlayerB_Die2}, {PlayerB_Die3}");
            }
            if (PlayerB_RoundScore < 6 && PlayerB_Die2 < PlayerB_Die1)
            {
                Console.WriteLine($"However, Player B scored less than six and therefore Re-Rolled and got: {PlayerB_Die1}, {PlayerB_Die3}");
            }

            Console.WriteLine($"Player B Rolled {PlayerB_Sixes} six's");
            Console.WriteLine($"\nPlayer B's Round Score: {PlayerB_RoundScore}");
            Console.WriteLine("------------------------------\n");
        }
    }
}
