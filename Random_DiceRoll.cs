using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Random_DiceRoll
    {
        private static Random rand = new Random();
        private int DiceNumber;

        //constructor to roll the dice 
        public Random_DiceRoll()
        {
            DiceNumber = rand.Next(1, 7);
        }

        // getter for the dice number rolled 
        public int GetDiceRoll()
        {
            return DiceNumber;
        }

    }
}
