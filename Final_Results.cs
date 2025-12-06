using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CET1004_Assignment1
{
    internal class Final_Results
    {
        //=========================================
        // Private static variables to hold final scores and sixes count
        //=========================================
        static int TotalScoreA;
        static int TotalScoreB;
        static int Total_SixesA;
        static int Total_SixesB;

        //=========================================
        // Method to display final results and determine the winner
        //=========================================
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

            // Determine winner based on total scores
            if (TotalScoreA > TotalScoreB)
            {
                Console.WriteLine("\nThe Final scores are :");
                Console.WriteLine($"\nPlayer A : {TotalScoreA} rolling 6 :{Total_SixesA} times \t\tVS  \t\t\tPlayer B : {TotalScoreB} rolling 6 :{Total_SixesB} times");
                Console.WriteLine("==============================================");
                Console.WriteLine("CONGRATULATIONS PLAYER A, YOU ARE THE WINNER!!");
                Console.WriteLine("==============================================");
            }
            else if (TotalScoreB > TotalScoreA)
            {
                Console.WriteLine("\nThe Final scores are :");
                Console.WriteLine($"\nPlayer A : {TotalScoreA} rolling 6 :{Total_SixesA} times \t\tVS  \t\t\tPlayer B : {TotalScoreB} rolling 6 :{Total_SixesB} times");
                Console.WriteLine("\n==============================================");
                Console.WriteLine("\tPLAYER B WINS...... YOU LOSE!!");
                Console.WriteLine("==============================================");
            }
            else
            {
                Console.WriteLine("\nThe Final scores are :");
                Console.WriteLine($"\nPlayer A : {TotalScoreA} rolling 6 :{Total_SixesA} times \t\tVS  \t\t\tPlayer B : {TotalScoreB} rolling 6 :{Total_SixesB} times");
                Console.WriteLine("==============================================");
                Console.WriteLine("\t\t\t\tIT'S A TIE!!");
                Console.WriteLine("==============================================");
                Console.WriteLine("\nNOW TO DETERMINE THE WINNER BY THE NUMBER OF 6's ROLLED...");
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                // Check number of sixes rolled to determine winner
                if (Total_SixesA > Total_SixesB)
                {
                    Console.WriteLine("\n==================================================");
                    Console.WriteLine("BUT... AS PLAYER A ROLLED THE MOST 6's!!");
                    Console.WriteLine("\n CONGRATULATIONS... YOU ARE THE WINNER!!");
                    Console.WriteLine("==================================================");
                    Console.WriteLine("\n THANK YOU FOR PLAYING THE DICE BATTLE GAME!!");
                    Console.WriteLine("press any key to exit...");
                    Console.ReadKey();
                }
                else if (Total_SixesB > Total_SixesA)
                {
                    Console.WriteLine("\n==============================================");
                    Console.WriteLine("BUT... AS PLAYER B ROLLED THE MOST 6's!!");
                    Console.WriteLine("\n PLAYER B WINS...... YOU LOSE!!");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("\n THANK YOU FOR PLAYING THE DICE BATTLE GAME!!");
                    Console.WriteLine("press any key to exit...");
                    Console.ReadKey();

                }
                // If sixes are also tied, restart the game
                else
                {
                    Console.WriteLine("==============================================");
                    Console.WriteLine("EVEN THE NUMBER OF 6's ROLLED ARE TIED!! WHAT A MATCH!!");
                    Console.WriteLine("\t\t THERE MUST BE A WINNER, SO LET'S GO AGAIN!!");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("\n Press any key to START A NEW GAME...");
                    Console.ReadKey();
                    Program.DiceGame();

                }

            }
        }
        //=================================================
        // Static method to write final results to log file
        //=================================================
        static public void Write_results()
        {
            StreamWriter sw = new StreamWriter("Log.txt", true);
            sw.WriteLine("\t\t\t\t----------------------------");
            sw.WriteLine("\t\t\t\t       FINAL RESULTS");
            sw.WriteLine("\t\t\t\t----------------------------\n");
            if (TotalScoreA > TotalScoreB)
            {
                sw.WriteLine("\nThe Final scores are :");
                sw.WriteLine($"\nPlayer A : {TotalScoreA} rolling 6 :{Total_SixesA} times \t\tVS  \t\t\tPlayer B : {TotalScoreB} rolling 6 :{Total_SixesB} times");
                sw.WriteLine("==============================================");
                sw.WriteLine("CONGRATULATIONS PLAYER A, YOU ARE THE WINNER!!");
                sw.WriteLine("==============================================");
            }
            else if (TotalScoreB > TotalScoreA)
            {
                sw.WriteLine("\nThe Final scores are :");
                sw.WriteLine($"\nPlayer A : {TotalScoreA} rolling 6 :{Total_SixesA} times \t\tVS  \t\t\tPlayer B : {TotalScoreB} rolling 6 :{Total_SixesB} times");
                sw.WriteLine("\n==============================================");
                sw.WriteLine("\tPLAYER B WINS...... YOU LOSE!!");
                sw.WriteLine("==============================================");
            }
            else
            {
                sw.WriteLine("\nThe Final scores are :");
                sw.WriteLine($"\nPlayer A : {TotalScoreA} rolling 6 :{Total_SixesA} times \t\tVS  \t\t\tPlayer B : {TotalScoreB} rolling 6 :{Total_SixesB} times");
                sw.WriteLine("==============================================");
                sw.WriteLine("\t\t\t\tIT'S A TIE!!");
                sw.WriteLine("==============================================");
                sw.WriteLine("\nNOW TO DETERMINE THE WINNER BY THE NUMBER OF 6's ROLLED...");

                if (Total_SixesA > Total_SixesB)
                {
                    sw.WriteLine("\n==================================================");
                    sw.WriteLine("BUT... AS PLAYER A ROLLED THE MOST 6's!!");
                    sw.WriteLine("\n CONGRATULATIONS... YOU ARE THE WINNER!!");
                    sw.WriteLine("==================================================");
                    sw.WriteLine("\n THANK YOU FOR PLAYING THE DICE BATTLE GAME!!");
                }
                else if (Total_SixesB > Total_SixesA)
                {
                    sw.WriteLine("\n==============================================");
                    sw.WriteLine("BUT... AS PLAYER B ROLLED THE MOST 6's!!");
                    sw.WriteLine("\n PLAYER B WINS...... YOU LOSE!!");
                    sw.WriteLine("==============================================");
                    sw.WriteLine("\n THANK YOU FOR PLAYING THE DICE BATTLE GAME!!");
                }
                else
                {
                    sw.WriteLine("==============================================");
                    sw.WriteLine("EVEN THE NUMBER OF 6's ROLLED ARE TIED!! WHAT A MATCH!!");
                    sw.WriteLine("\t\t THERE MUST BE A WINNER, SO LET'S GO AGAIN!!");
                    sw.WriteLine("==============================================");
                }

            }
            sw.Close(); 
        }
    }

}
