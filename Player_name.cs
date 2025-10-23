using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Player_name
    {
        private string sPlayerName;
        public Player_name(string psPlayerName)
        {
            sPlayerName = psPlayerName;
        }
        public Player_name()
        {
            sPlayerName = "Player";
        }
        public string GetPlayerName()
        {
            return sPlayerName;
        }
        public void SetPlayerName(string psPlayerName)
        {
            sPlayerName = psPlayerName;
        }
    }
}
