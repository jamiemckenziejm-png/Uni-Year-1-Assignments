using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Schema;

namespace CET1004_Assignment1
{
    internal class Program
    {
        //=====================================================================
        // Static list to hold round results
        //=====================================================================
        static List<Round_Object> RoundResultsList = new List<Round_Object>();

        static void Main(string[] args)
        {

            // Call Retrieve_Name method from Player_name class
            Player_name.Retrieve_Name();
            // Display Game Rules from GameRules class
            GameRules.DisplayGameRules();
            // Start Game   
            DiceGame();
            // Write Log file using the information contained within the list
            WriteToLog.WriteFile(RoundResultsList);
            // Write final results to log file
            Final_Results.Write_results();
        }

        //=====================================================================
        // DiceGame Method - Main game logic
        //=====================================================================
        public static void DiceGame()
        {
            // Initialize total scores for both players
            int TotalScoreA = 0, TotalScoreB = 0;
            int TotalSixsA = 0, TotalSixsB = 0;

            // Loop through 3 rounds storing results in Round_Object list
            for (int round = 1; round <= 3; round++)
            {
                int sixesA = 0;
                int sixesB = 0;
                
                RoundResultsList.Add(new Round_Object());
                RoundResultsList[round - 1].SetRoundNumber(round);

                //=====================================
                // Display Round Header
                //=====================================
                GameTitle.DisplayGameTitle();
                Console.WriteLine("\t\t\t\t----------------------------");
                Console.WriteLine($"\t\t\t                  Round {round}");
                Console.WriteLine("\t\t\t\t----------------------------");
                Console.WriteLine("\n\n\nPress any key to roll the Dice!!");
                // Wait for user input and then clear console before continuing
                Console.ReadKey();
                Console.Clear();
                GameTitle.DisplayGameTitle();
                Console.WriteLine("\t\t\t\t----------------------------");
                Console.WriteLine($"\t\t\t                  Round {round}");
                Console.WriteLine("\t\t\t\t----------------------------");

                //=======================================================================
                // Create random diceroll object and generate dice rolls for both players
                //=======================================================================
                Random_DiceRoll die1A = new Random_DiceRoll();
                Random_DiceRoll die2A = new Random_DiceRoll();
                Random_DiceRoll die1B = new Random_DiceRoll();
                Random_DiceRoll die2B = new Random_DiceRoll();

                // Store initial dice rolls in RoundResults object
                RoundResultsList[round - 1].SetPlayerA_Die1(die1A.GetDiceRoll());
                RoundResultsList[round - 1].SetPlayerA_Die2(die2A.GetDiceRoll());
                RoundResultsList[round - 1].SetPlayerB_Die1(die1B.GetDiceRoll());
                RoundResultsList[round - 1].SetPlayerB_Die2(die2B.GetDiceRoll());

                //=======================================================================
                // Display initial dice rolls
                //=======================================================================
                Console.Write("\n\n\nPlayer A rolled: " + die1A.GetDiceRoll() + " and " + die2A.GetDiceRoll());
                Console.WriteLine("\t\t\t\t\tPlayer B rolled: " + die1B.GetDiceRoll() + " and " + die2B.GetDiceRoll());
                Console.WriteLine();

                //=======================================================================
                // Calculate round scores and store to new variables
                //=======================================================================
                int roundScoreA = die1A.GetDiceRoll() + die2A.GetDiceRoll();
                int roundScoreB = die1B.GetDiceRoll() + die2B.GetDiceRoll();

                //=======================================================================
                // Players choice to stick or re-roll with input validation
                //=======================================================================
                bool validChoice = false;
                int ichoice;
                string Stick = "STICK";
                string ReRoll = "RE-ROLL";
                //=======================================================================
                // Player A logic to choose to stick or re-roll using input validation
                //=======================================================================
                while (!validChoice)
                {
                    Console.Write("Would you like to: \n 1:Stick \n 2:Re-roll \n\nYou selected option: ");
                    validChoice = int.TryParse(Console.ReadLine(), out ichoice);

                    if (validChoice)
                    {
                        if (!(ichoice == 1 || ichoice == 2))
                        {
                            validChoice = false;
                            Console.WriteLine("\nInvalid input. Please enter 1 to Stick or 2 to Re-roll.\n");
                        }
                        // If player chooses to stick
                        if (ichoice == 1)
                        {
                            Console.WriteLine("Player A chose to " + Stick);
                            string sChoice = Stick;
                            RoundResultsList[round - 1].SetPlayer_choice(sChoice);
                        }

                        // If player chooses to re-roll
                        if (ichoice == 2)
                        {
                            if (die1A.GetDiceRoll() <= die2A.GetDiceRoll())
                            {
                                die1A = new Random_DiceRoll();
                                Console.WriteLine("\nPlayer A chose to " + ReRoll + " Dice 1.");
                                RoundResultsList[round - 1].SetPlayerA_Die3(die1A.GetDiceRoll());
                            }
                            else
                            {
                                die2A = new Random_DiceRoll();
                                Console.WriteLine("\nPlayer A chose to " + ReRoll + " Dice 2.");
                                RoundResultsList[round - 1].SetPlayerA_Die3(die2A.GetDiceRoll());
                            }
                            Console.WriteLine("\nThe new roll results are: " + die1A.GetDiceRoll() + " and " + die2A.GetDiceRoll());
                            roundScoreA = die1A.GetDiceRoll() + die2A.GetDiceRoll();
                            string sChoice = ReRoll;
                            RoundResultsList[round - 1].SetPlayer_choice(sChoice);
                        }
                    }
                }

                //=======================================================================
                // Player B logic to re-roll if score is less than 6
                //=======================================================================
                if (roundScoreB <= 5)
                {
                    if (die1B.GetDiceRoll() < die2B.GetDiceRoll())
                    {
                        die1B = new Random_DiceRoll();
                        RoundResultsList[round - 1].SetPlayerB_Die3(die1B.GetDiceRoll());
                    }
                    else
                    {
                        die2B = new Random_DiceRoll();
                        RoundResultsList[round - 1].SetPlayerB_Die3(die2B.GetDiceRoll());
                    }
                    Console.WriteLine("\t\t\t\t\t\t\t\tPlayer B re-rolled: " + die1B.GetDiceRoll() + " and " + die2B.GetDiceRoll());
                    roundScoreB = die1B.GetDiceRoll() + die2B.GetDiceRoll();
                }

                //=======================================================================
                // Calculate and store the number of sixes rolled by each player
                //=======================================================================
                if (die1A.GetDiceRoll() == 6)
                {
                    sixesA++;
                    TotalSixsA++;
                }
                if (die2A.GetDiceRoll() == 6)
                {
                    sixesA++;
                    TotalSixsA++;
                }
                if (die1B.GetDiceRoll() == 6)
                {
                    sixesB++;
                    TotalSixsB++;
                }
                if (die2B.GetDiceRoll() == 6)
                {
                    sixesB++;
                    TotalSixsB++;
                }
                RoundResultsList[round - 1].SetPlayerA_Sixes(sixesA);
                RoundResultsList[round - 1].SetPlayerB_Sixes(sixesB);

                // Pause before displaying round results
                Console.WriteLine("\nPRESS ANY KEY TO VIEW END OF ROUND RESULTS...");
                Console.ReadKey();
                Console.Clear();

                //=======================================================================
                // Store round scores
                //=======================================================================
                RoundResultsList[round - 1].SetPlayerA_RoundScore(roundScoreA);
                RoundResultsList[round - 1].SetPlayerB_RoundScore(roundScoreB);

                //=======================================================================
                // Display round results from Round_Object
                //=======================================================================
                RoundResultsList[round - 1].DisplayRoundSummary();
                Console.WriteLine("\nPRESS ANY KEY TO MOVE TO NEXT ROUND...");
                Console.ReadKey();
                Console.Clear();            

            }

            //=======================================================================
            // Storing total scores from all rounds
            //=======================================================================
            for (int i = 0; i < RoundResultsList.Count; i++)
            {
                TotalScoreA += RoundResultsList[i].GetPlayerA_RoundScore();
                TotalScoreB += RoundResultsList[i].GetPlayerB_RoundScore();
            }

            //=======================================================================
            // Pass total scores and sixes to Final_Results class
            //=======================================================================            
            Final_Results final = new Final_Results(TotalScoreA, TotalScoreB, TotalSixsA, TotalSixsB);
        }
    }
}
