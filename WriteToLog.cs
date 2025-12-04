using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class WriteToLog
    {
       // private int RoundNumber;
       // private int PlayerA_RoundScore;
       // private int PlayerB_RoundScore;
       // private string Player_choice;
       // private int PlayerA_Die1;
       // private int PlayerA_Die2;
       // private int PlayerA_Die3;
       // private int PlayerB_Die1;
       // private int PlayerB_Die2;
       // private int PlayerB_Die3;
       // private int PlayerA_Sixes;
       // private int PlayerB_Sixes;
       //// private Round_Object _round;

       // public WriteToLog(int pRoundNumber, int pPlayerA_RoundScore, int pPlayerB_RoundScore, string pPlayer_choice,
       //int pPlayerA_Die1, int pPlayerA_Die2, int pPlayerA_Die3,
       //int pPlayerB_Die1, int pPlayerB_Die2, int pPlayerB_Die3,
       //int pPlayerA_Sixes, int pPlayerB_Sixes)
       // {
       //     RoundNumber = pRoundNumber;
       //     PlayerA_RoundScore = pPlayerA_RoundScore;
       //     PlayerB_RoundScore = pPlayerB_RoundScore;
       //     Player_choice = pPlayer_choice;
       //     PlayerA_Die1 = pPlayerA_Die1;
       //     PlayerA_Die2 = pPlayerA_Die2;
       //     PlayerA_Die3 = pPlayerA_Die3;
       //     PlayerB_Die1 = pPlayerB_Die1;
       //     PlayerB_Die2 = pPlayerB_Die2;
       //     PlayerB_Die3 = pPlayerB_Die3;
       //     PlayerA_Sixes = pPlayerA_Sixes;
       //     PlayerB_Sixes = pPlayerB_Sixes;
       // }
      
        static public void WriteFile(List<Round_Object> rounds)
        {
            //RoundNumber = round.GetRoundNumber();
            //PlayerA_RoundScore = round.GetPlayerA_RoundScore();
            //PlayerB_RoundScore = round.GetPlayerB_RoundScore();
            //Player_choice = pPlayer_choice;
            //PlayerA_Die1 = pPlayerA_Die1;
            //PlayerA_Die2 = pPlayerA_Die2;
            //PlayerA_Die3 = pPlayerA_Die3;
            //PlayerB_Die1 = pPlayerB_Die1;
            //PlayerB_Die2 = pPlayerB_Die2;
            //PlayerB_Die3 = pPlayerB_Die3;
            //PlayerA_Sixes = pPlayerA_Sixes;
            //PlayerB_Sixes = pPlayerB_Sixes;
            // _round = round;
            // write results from each round to log file using the roundresultslist
            
            GameTitle.LogGameTitle();
            Player_name.LogPlayerName();
            StreamWriter sw = new StreamWriter("Log.txt", true);
            for (int i = 0; i < rounds.Count; i++)

            {
                sw.WriteLine($"\n--- Round {rounds[i].GetRoundNumber()} Summary ---");
                sw.WriteLine($"\nPlayer A Initial Dice Rolls Were : {rounds[i].GetPlayerA_Die1()} and {rounds[i].GetPlayerA_Die2()}");
                sw.WriteLine($"Player A Chose to {rounds[i].GetPlayer_choice()}");
                if (rounds[i].GetPlayerA_Die3() != 0)
                {
                    if (rounds[i].GetPlayerA_Die1() < rounds[i].GetPlayerA_Die2())
                    {
                        sw.WriteLine($"Player A's New rolls are: {rounds[i].GetPlayerA_Die2()}, {rounds[i].GetPlayerA_Die3()}");
                    }
                    else
                    {
                        sw.WriteLine($"Player A's New rolls are: {rounds[i].GetPlayerA_Die1()}, {rounds[i].GetPlayerA_Die3()}");
                    }
                }

                sw.WriteLine($"\nPlayer A Rolled {rounds[i].GetPlayerA_Sixes()} six's");
                sw.WriteLine($"\nPLAYER A ROUND SCORE: {rounds[i].GetPlayerA_RoundScore()}");


                sw.WriteLine($"\n\nPlayer B Dice: {rounds[i].GetPlayerB_Die1()}, {rounds[i].GetPlayerB_Die2()}");
                if (rounds[i].GetPlayerB_Die3() != 0 && rounds[i].GetPlayerB_Die1() <= rounds[i].GetPlayerB_Die2())
                {
                    sw.WriteLine($"However, Player B scored less than six, Dice Rerolled into: {rounds[i].GetPlayerB_Die2()}, {rounds[i].GetPlayerB_Die3()}");
                }
                if (rounds[i].GetPlayerB_Die3() != 0 && rounds[i].GetPlayerB_Die2() < rounds[i].GetPlayerB_Die1())
                {
                    sw.WriteLine($"However, Player B scored less than six,Dice Re-Rolled into: {rounds[i].GetPlayerB_Die1()}, {rounds[i].GetPlayerB_Die3()}");
                }
                if (rounds[i].GetPlayerB_Die3() == 0 && rounds[i].GetPlayerB_RoundScore() > 5)
                {
                    sw.WriteLine("Player B rolled higher than 5, score Kept.");
                }

                sw.WriteLine($"Player B Rolled {rounds[i].GetPlayerB_Sixes()} six's");
                sw.WriteLine($"PLAYER B ROUND SCORE: {rounds[i].GetPlayerB_RoundScore()}");
                sw.WriteLine("------------------------------\n");

                if (rounds[i].GetPlayerA_RoundScore() > rounds[i].GetPlayerB_RoundScore())
                {
                    sw.WriteLine("PLAYER A WINS THIS ROUND!");
                    sw.WriteLine("------------------------------\n");

                }
                else if (rounds[i].GetPlayerB_RoundScore() > rounds[i].GetPlayerA_RoundScore())
                {
                    sw.WriteLine("PLAYER B WINS THIS ROUND!");
                    sw.WriteLine("------------------------------\n");

                }
                else
                {
                    sw.WriteLine("THIS ROUND IS A TIE!");
                    sw.WriteLine("------------------------------\n");

                }
            }
            sw.Close();
        }

    }

}
