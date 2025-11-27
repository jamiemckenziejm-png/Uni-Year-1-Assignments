using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class WriteToLog
    {
        private int RoundNumber;
        private int PlayerA_RoundScore;
        private int PlayerB_RoundScore;
        private string Player_choice;
        private int PlayerA_Die1;
        private int PlayerA_Die2;
        private int PlayerA_Die3;
        private int PlayerB_Die1;
        private int PlayerB_Die2;
        private int PlayerB_Die3;
        private int PlayerA_Sixes;
        private int PlayerB_Sixes;

        public WriteToLog(int pRoundNumber, int pPlayerA_RoundScore, int pPlayerB_RoundScore, string pPlayer_choice,
       int pPlayerA_Die1, int pPlayerA_Die2, int pPlayerA_Die3,
       int pPlayerB_Die1, int pPlayerB_Die2, int pPlayerB_Die3,
       int pPlayerA_Sixes, int pPlayerB_Sixes)
        {
            RoundNumber = pRoundNumber;
            PlayerA_RoundScore = pPlayerA_RoundScore;
            PlayerB_RoundScore = pPlayerB_RoundScore;
            Player_choice = pPlayer_choice;
            PlayerA_Die1 = pPlayerA_Die1;
            PlayerA_Die2 = pPlayerA_Die2;
            PlayerA_Die3 = pPlayerA_Die3;
            PlayerB_Die1 = pPlayerB_Die1;
            PlayerB_Die2 = pPlayerB_Die2;
            PlayerB_Die3 = pPlayerB_Die3;
            PlayerA_Sixes = pPlayerA_Sixes;
            PlayerB_Sixes = pPlayerB_Sixes;
        }

        public WriteToLog(Round_Object round)
        {
            RoundNumber = round.GetRoundNumber();
            PlayerA_RoundScore = round.GetPlayerA_RoundScore();
            PlayerB_RoundScore = round.GetPlayerB_RoundScore();
            //Player_choice = pPlayer_choice;
            //PlayerA_Die1 = pPlayerA_Die1;
            //PlayerA_Die2 = pPlayerA_Die2;
            //PlayerA_Die3 = pPlayerA_Die3;
            //PlayerB_Die1 = pPlayerB_Die1;
            //PlayerB_Die2 = pPlayerB_Die2;
            //PlayerB_Die3 = pPlayerB_Die3;
            //PlayerA_Sixes = pPlayerA_Sixes;
            //PlayerB_Sixes = pPlayerB_Sixes;
        }
    }

}
