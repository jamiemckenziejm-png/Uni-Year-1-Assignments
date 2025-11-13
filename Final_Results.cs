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


        public Final_Results(int pTotalScoreA, int pTotalScoreB, int pTotal_SixesA, int pTotal_SixesB)
        {
            TotalScoreA = pTotalScoreA;
            TotalScoreB = pTotalScoreB;
            Total_SixesA = pTotal_SixesA;
            Total_SixesB = pTotal_SixesB;

            GameTitle.DisplayGameTitle();
            Console.WriteLine("\t\t\t\t----------------------------");
            Console.WriteLine("\t\t\t\t       FINAL RESULTS");
            Console.WriteLine("\t\t\t\t----------------------------\n");
            //Console.WriteLine(Program.GetTotalScoreA());
            Console.WriteLine(TotalScoreA);
        }
    
    }
}
