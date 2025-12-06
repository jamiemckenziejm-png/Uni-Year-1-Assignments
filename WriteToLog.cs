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

        //=========================================
        // WRITE ROUND SUMMARIES TO LOG FILE
        //=========================================
        static public void WriteFile(List<Round_Object> rounds)
        {         
            GameTitle.LogGameTitle();
            Player_name.LogPlayerName();
            StreamWriter sw = new StreamWriter("Log.txt", true);
            for (int i = 0; i < rounds.Count; i++)

            {
                //=======================================
                // WRITE PLAYER ROUND SUMMARY TO LOG FILE
                //=======================================
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
                sw.WriteLine($"Number of times Player A rolled a six: {rounds[i].GetPlayerA_Sixes()}");
                sw.WriteLine($"\nSCORE FOR THIS ROUND: {rounds[i].GetPlayerA_RoundScore()}");

                //=========================================
                // WRITE PLAYER B ROUND SUMMARY TO LOG FILE
                //=========================================
                sw.WriteLine($"\n\nPlayer B Dice: {rounds[i].GetPlayerB_Die1()}, {rounds[i].GetPlayerB_Die2()}");
                if (rounds[i].GetPlayerB_Die3() != 0 && rounds[i].GetPlayerB_Die1() <= rounds[i].GetPlayerB_Die2())
                {
                    sw.WriteLine($"Player B scored less than six. Dice Rerolled into: {rounds[i].GetPlayerB_Die2()}, {rounds[i].GetPlayerB_Die3()}");
                }
                if (rounds[i].GetPlayerB_Die3() != 0 && rounds[i].GetPlayerB_Die2() < rounds[i].GetPlayerB_Die1())
                {
                    sw.WriteLine($"Player B scored less than six. Dice Re-Rolled into: {rounds[i].GetPlayerB_Die1()}, {rounds[i].GetPlayerB_Die3()}");
                }
                if (rounds[i].GetPlayerB_Die3() == 0 && rounds[i].GetPlayerB_RoundScore() > 5)
                {
                    sw.WriteLine("Player B rolled higher than 5, score Kept.");
                }
                sw.WriteLine($"Number of times Player B rolled a six: {rounds[i].GetPlayerB_Sixes()}");
                sw.WriteLine($"\nSCORE FOR THIS ROUND: {rounds[i].GetPlayerB_RoundScore()}");
                sw.WriteLine("\n------------------------------");

                //=============================================
                // DETERMINE AND WRITE ROUND WINNER TO LOG FILE
                //=============================================
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

