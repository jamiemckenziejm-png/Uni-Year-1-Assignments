using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Final_Results
    {
        private int TotalScoreA;
        private int TotalScoreB;
        private int Total_SixesA;
        private int Total_SixesB;


        public Final_Results()
        {
           /// TotalScoreA = RoundResultsList[0].GetPlayerA_RoundScore;
            TotalScoreB = 0;
            Total_SixesA = 0;
            Total_SixesB = 0;

            GameTitle.DisplayGameTitle();
            Console.WriteLine("\t\t\t\t----------------------------");
            Console.WriteLine("\t\t\t\t       FINAL RESULTS");
            Console.WriteLine("\t\t\t\t----------------------------\n");
            
        }
    
    }
}
