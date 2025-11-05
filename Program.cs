using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET1004_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> choices = new List<int>();
            //Call Retrieve_Name method from Player_name class
            Player_name.Retrieve_Name();
            //Display Game Rules from GameRules class
            GameRules.DisplayGameRules();
            //Start Game   
            DiceGame();
        }
       
        static void DiceGame()
        {
            // Initialize total scores for both players
            int TotalScoreA = 0, TotalScoreB = 0;

            // Loop through 3 rounds
            for (int round = 1; round <= 3; round++)
            {
                Console.WriteLine("\t\t\t----------------------------");
                Console.WriteLine($"\t\t\t\tRound {round}      ");
                Console.WriteLine("\t\t\t----------------------------");                
                Console.WriteLine("\n\n\nPress any key to roll the Dice!!");

                // Wait for user input and then clear console before continuing
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\t\t\t----------------------------");
                Console.WriteLine($"\t\t\t\tRound {round}      ");
                Console.WriteLine("\t\t\t----------------------------");

                // create random diceroll object and generate dice rolls for both players
                Random_DiceRoll die1A = new Random_DiceRoll();
                Random_DiceRoll die2A = new Random_DiceRoll();
                Random_DiceRoll die1B = new Random_DiceRoll();
                Random_DiceRoll die2B = new Random_DiceRoll();

                // display initial dice rolls
                Console.WriteLine("\n\n\nPlayer A rolled: " + die1A.GetDiceRoll() + " and " + die2A.GetDiceRoll() + "\t\t\t\tPlayer B rolled: " + die1B.GetDiceRoll() + " and " + die2B.GetDiceRoll());
                Console.WriteLine();

                // calculate round scores and store to new variables
                int roundScoreA = die1A.GetDiceRoll() + die2A.GetDiceRoll();
                int roundScoreB = die1B.GetDiceRoll() + die2B.GetDiceRoll();

                // players choice to stick or re-roll with input validation
                bool validChoice = false;
                int choiceA;
                
                while (!validChoice)
                {
                    Console.Write("Would you like to: \n 1:Stick \n 2:Re-roll \n\nYou selected option: ");
                    validChoice = int.TryParse(Console.ReadLine(), out choiceA);
                    
                    if (validChoice)
                    {
                        if (!(choiceA == 1 || choiceA == 2))
                        {
                            validChoice = false;
                        }

                        if (choiceA == 2)
                        {
                            if (die1A.GetDiceRoll() < die2A.GetDiceRoll())
                            {
                                die1A = new Random_DiceRoll();
                            }
                            else
                            {
                                die2A = new Random_DiceRoll();
                            }
                            Console.WriteLine("Player A re-rolled: " + die1A.GetDiceRoll() + " and " + die2A.GetDiceRoll());
                            roundScoreA = die1A.GetDiceRoll() + die2A.GetDiceRoll();
                        }
                    }
                }
                // Player B logic to re-roll if score is less than 6
                if (roundScoreB < 6)
                {
                    if (die1B.GetDiceRoll() < die2B.GetDiceRoll())
                    {
                        die1B = new Random_DiceRoll(); 
                    }
                    else
                    {
                        die2B = new Random_DiceRoll();
                    }
                    Console.WriteLine("\t\t\t\t\t\t\tPlayer B re-rolled: " + die1B.GetDiceRoll() + " and " + die2B.GetDiceRoll());
                    roundScoreB = die1B.GetDiceRoll() + die2B.GetDiceRoll();
                }
                Console.WriteLine();
                Console.WriteLine("Player A's round score: " + roundScoreA + "\t\t\t\tPlayer B's round score: " + roundScoreB);
                Console.WriteLine("\n\nPRESS ANY KEY TO CONTINUE");
                Console.ReadKey();
                Console.WriteLine();

                TotalScoreA += roundScoreA;
                TotalScoreB += roundScoreB;
                Console.WriteLine();
                Console.WriteLine("Player A's total score: " + TotalScoreA + "\t\t\t\tPlayer B's total score: " + TotalScoreB);
                Console.WriteLine("\nPRESS ANY KEY TO MOVE TO CONTINUE");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
