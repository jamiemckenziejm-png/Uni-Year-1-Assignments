using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CET1004_Assignment1
{
    internal class Program
    {
        //static int TotalScoreA = 0, TotalScoreB = 0;
        //static int TotalSixsA = 0, TotalSixsB = 0;

        //public static int GetTotalScoreA()
        //{
        //    return TotalScoreA;
        //}
        static List<Round_Object> RoundResultsList = new List<Round_Object>();

        static void Main(string[] args)
        {

            //Call Retrieve_Name method from Player_name class
            Player_name.Retrieve_Name();
            //Display Game Rules from GameRules class
            GameRules.DisplayGameRules();
            //Start Game   
            DiceGame();
            // write Log file using the WriteToLog class
            WriteToLog.WriteFile(RoundResultsList);

        }

        public static void DiceGame()
        {
            // Initialize total scores for both players
            int TotalScoreA = 0, TotalScoreB = 0;
            int TotalSixsA = 0, TotalSixsB = 0;



            // list to store round results
            //List<Round_Object> RoundResultsList = new List<Round_Object>();
            // Loop through 3 rounds
            for (int round = 1; round <= 3; round++)
            {
                int sixesA = 0;
                int sixesB = 0;
                // create new Round_Object for each round
                //Round_Object RoundResults = new Round_Object();
                RoundResultsList.Add(new Round_Object());
                RoundResultsList[round - 1].SetRoundNumber(round);
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

                // create random diceroll object and generate dice rolls for both players
                Random_DiceRoll die1A = new Random_DiceRoll();
                Random_DiceRoll die2A = new Random_DiceRoll();
                Random_DiceRoll die1B = new Random_DiceRoll();
                Random_DiceRoll die2B = new Random_DiceRoll();
                // store initial dice rolls in RoundResults object
                RoundResultsList[round - 1].SetPlayerA_Die1(die1A.GetDiceRoll());
                RoundResultsList[round - 1].SetPlayerA_Die2(die2A.GetDiceRoll());
                RoundResultsList[round - 1].SetPlayerB_Die1(die1B.GetDiceRoll());
                RoundResultsList[round - 1].SetPlayerB_Die2(die2B.GetDiceRoll());


                // display initial dice rolls
                Console.Write("\n\n\nPlayer A rolled: " + die1A.GetDiceRoll() + " and " + die2A.GetDiceRoll());
                Console.WriteLine("\t\t\t\t\tPlayer B rolled: " + die1B.GetDiceRoll() + " and " + die2B.GetDiceRoll());
                Console.WriteLine();

                // calculate round scores and store to new variables
                int roundScoreA = die1A.GetDiceRoll() + die2A.GetDiceRoll();
                int roundScoreB = die1B.GetDiceRoll() + die2B.GetDiceRoll();

                // players choice to stick or re-roll with input validation
                bool validChoice = false;
                int ichoice;
                string Stick = "STICK";
                string ReRoll = "RE-ROLL";
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
                        // if player chooses to stick
                        if (ichoice == 1)
                        {
                            Console.WriteLine("Player A chose to " + Stick);
                            string sChoice = Stick;
                            RoundResultsList[round - 1].SetPlayer_choice(sChoice);
                        }

                        // if player chooses to re-roll
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
                // Player B logic to re-roll if score is less than 6
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

                // Calculate number of sixes rolled by each player
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
                RoundResultsList[round - 1].SetPlayerA_RoundScore(roundScoreA);
                RoundResultsList[round - 1].SetPlayerB_RoundScore(roundScoreB);
                //TotalScoreA += roundScoreA;
                //TotalScoreB += roundScoreB;
                // Display round results from Round_Object
                RoundResultsList[round - 1].DisplayRoundSummary();
                Console.WriteLine("\nPRESS ANY KEY TO MOVE TO NEXT ROUND...");
                Console.ReadKey();
                Console.Clear();

                // Store round results in Round_Object and add to list
                //RoundResultsList.Add(RoundResultsList[round - 1]);

            }
            // storing total scores from all rounds
            for (int i = 0; i < RoundResultsList.Count; i++)
            {
                TotalScoreA += RoundResultsList[i].GetPlayerA_RoundScore();
                TotalScoreB += RoundResultsList[i].GetPlayerB_RoundScore();
                // WriteToLog newlog = new WriteToLog(RoundResultsList);
            }
            // TotalScoreA = RoundResultsList[0].GetPlayerA_RoundScore() + RoundResultsList[1].GetPlayerA_RoundScore() + RoundResultsList[2].GetPlayerA_RoundScore();
            // TotalScoreB = RoundResultsList[0].GetPlayerB_RoundScore() + RoundResultsList[1].GetPlayerB_RoundScore() + RoundResultsList[2].GetPlayerB_RoundScore();
            // TotalSixsA = RoundResultsList[0].GetPlayerA_Sixes() + RoundResultsList[1].GetPlayerA_Sixes() + RoundResultsList[2].GetPlayerA_Sixes();
            // = RoundResultsList[0].GetPlayerB_Sixes() + RoundResultsList[1].GetPlayerB_Sixes() + RoundResultsList[2].GetPlayerB_Sixes();

            Final_Results final = new Final_Results(TotalScoreA, TotalScoreB, TotalSixsA, TotalSixsB);

        }
    }
}
