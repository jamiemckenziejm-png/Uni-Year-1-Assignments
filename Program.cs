using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Call Retrieve_Name method from Player_name class
            Player_name.Retrieve_Name();
            //Display Game Rules from GameRules class
            GameRules.DisplayGameRules();
            //Start Game   
            DiceGame();
            // End of Main method
            FinalResults();
        }

        static void DiceGame()
        {
            // Initialize total scores for both players
            int TotalScoreA = 0, TotalScoreB = 0;

            // list to store round results
            List<Round_Object> RoundResultsList = new List<Round_Object>();
            // Loop through 3 rounds
            for (int round = 1; round <= 3; round++)
            {
                // create new Round_Object for each round
                Round_Object RoundResults = new Round_Object();
                RoundResults.SetRoundNumber(round);
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
                RoundResults.SetPlayerA_Die1(die1A.GetDiceRoll());
                RoundResults.SetPlayerA_Die2(die2A.GetDiceRoll());
                RoundResults.SetPlayerB_Die1(die1B.GetDiceRoll());
                RoundResults.SetPlayerB_Die2(die2B.GetDiceRoll());


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
                            RoundResults.SetPlayer_choice(sChoice);
                        }

                        // if player chooses to re-roll
                        if (ichoice == 2)
                        {
                            if (die1A.GetDiceRoll() <= die2A.GetDiceRoll())
                            {
                                die1A = new Random_DiceRoll();
                                Console.WriteLine("\nPlayer A chose to " + ReRoll + " Dice 1.");
                                RoundResults.SetPlayerA_Die3(die1A.GetDiceRoll());
                            }
                            else
                            {
                                die2A = new Random_DiceRoll();
                                Console.WriteLine("\nPlayer A chose to " + ReRoll + " Dice 2.");
                                RoundResults.SetPlayerA_Die3(die2A.GetDiceRoll());
                            }
                            Console.WriteLine("\nThe new roll results are: " + die1A.GetDiceRoll() + " and " + die2A.GetDiceRoll());
                            roundScoreA = die1A.GetDiceRoll() + die2A.GetDiceRoll();
                            string sChoice = ReRoll;
                            RoundResults.SetPlayer_choice(sChoice);
                        }
                    }
                }
                // Player B logic to re-roll if score is less than 6
                if (roundScoreB < 6)
                {
                    if (die1B.GetDiceRoll() < die2B.GetDiceRoll())
                    {
                        die1B = new Random_DiceRoll();
                        RoundResults.SetPlayerB_Die3(die1B.GetDiceRoll());
                    }
                    else
                    {
                        die2B = new Random_DiceRoll();
                        RoundResults.SetPlayerB_Die3(die2B.GetDiceRoll());
                    }
                    Console.WriteLine("\t\t\t\t\t\t\t\tPlayer B re-rolled: " + die1B.GetDiceRoll() + " and " + die2B.GetDiceRoll());
                    roundScoreB = die1B.GetDiceRoll() + die2B.GetDiceRoll();
                }

                // Calculate number of sixes rolled by each player
                int sixesA = 0;
                int sixesB = 0;
                if (die1A.GetDiceRoll() == 6) sixesA++;
                if (die2A.GetDiceRoll() == 6) sixesA++;
                if (die1B.GetDiceRoll() == 6) sixesB++;
                if (die2B.GetDiceRoll() == 6) sixesB++;
                RoundResults.SetPlayerA_TotalSixes(sixesA);
                RoundResults.SetPlayerB_TotalSixes(sixesB);

                // Pause before displaying round results
                Console.WriteLine("\nPRESS ANY KEY TO VIEW END OF ROUND RESULTS...");
                Console.ReadKey();
                Console.Clear();
                RoundResults.SetPlayerA_RoundScore(roundScoreA);
                RoundResults.SetPlayerB_RoundScore(roundScoreB);
                TotalScoreA += roundScoreA;
                TotalScoreB += roundScoreB;
                // Display round results from Round_Object
                Round_Object.DisplayRoundSummary();
                Console.WriteLine("\nPRESS ANY KEY TO MOVE TO NEXT ROUND...");
                Console.ReadKey();
                Console.Clear();

                // Store round results in Round_Object and add to list
                RoundResultsList.Add(RoundResults);
            }
            // End of DiceGame method
            TotalScoreA = RoundResultsList[0].PlayerA_RoundScore;
        }
    }
}
