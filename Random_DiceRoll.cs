using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CET1004_Assignment1
{
    internal class Random_DiceRoll
    {
        //=========================================
        // Static Random object to generate random numbers
        //=========================================
        private static Random rand = new Random();
        private int DiceNumber;

        //=========================================
        // Constructor to roll the dice 
        //=========================================
        public Random_DiceRoll()
        {
            DiceNumber = rand.Next(1, 7);
        }

        //=========================================
        // Getter for the dice number rolled 
        //=========================================
        public int GetDiceRoll()
        {
            return DiceNumber;
        }

    }
}
