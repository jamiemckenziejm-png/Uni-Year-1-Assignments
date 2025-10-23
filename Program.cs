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
            //Dice Battle Game - Introduction
            GetUserName();
            DisplayGameRules();
            //Start Game   
            DiceGame();
        }
        static void GetUserName()
        {
            Console.Write("Please enter your name: ");

            // Create Player Object
            Player_name Player1 = new Player_name(Console.ReadLine());
            Console.WriteLine();

            // Welcome Message calling player name from Player Object
            Console.WriteLine("Hello " + Player1.GetPlayerName() + ", Welcome to the DICE BATTLE GAME!! ");
            Console.WriteLine();

            // obtain input from user before clering the console and moving to the next method
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void DisplayGameRules()
        {
            Console.WriteLine("GAME RULES:");
            Console.WriteLine("\n 1. The game is played between two players (Player A = you : Player B = the computer) over 3 rounds");
            Console.WriteLine("\n 2. Each player takes turns to roll two dice.");
            Console.WriteLine("\n 3. Player A will choose each round to 'STICK' with the score they have or to 'RE-ROLL' the dice with the lowest value.");
            Console.WriteLine("\n 4. Player B will always 'RE-ROLL' if there score is less than 6 and always 'STICK' if higher.");
            Console.WriteLine("\n 5. Each roll for both players will be recorded inlcuding a Total Score.");
            Console.WriteLine("\n 6. Results will be displaed at the end of the game.");
            Console.WriteLine("\n 7. The player with the highest Total Score after 3 rounds wins the game.");
            Console.WriteLine("\n 8. In The event of a tie, the player whole rolled the most 6's will be declared the winner.");
            Console.WriteLine("\n\n\n PRESS ANY KEY TO START THE GAME...");
            Console.ReadKey();
            Console.Clear();
        }
        static void DiceGame()
        {
            int TotalScoreA = 0, TotalScoreB = 0;
            for (int round = 1; round <= 3; round++)
            {
                Console.WriteLine("                                    -----------------------------");
                Console.WriteLine($"                                             Round {round}      ");
                Console.WriteLine("                                    -----------------------------");
                Console.WriteLine();
                Console.WriteLine();

                
                Random rand = new Random();
                Console.WriteLine("Press any key to roll the Dice!!");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("                                    -----------------------------");
                Console.WriteLine($"                                             Round {round}      ");
                Console.WriteLine("                                    -----------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                // roll dice for both players
                int die1A = rand.Next(1, 7);
                int die2A = rand.Next(1, 7);
                int die1B = rand.Next(1, 7);
                int die2B = rand.Next(1, 7);
                Console.WriteLine("Player A rolled: " + die1A + " and " + die2A + "                                   Player B rolled: " + die1B + " and " + die2B);
                Console.WriteLine();
                int roundScoreB = die1B + die2B;
                int roundScoreA = die1A + die2A;
              

                if (roundScoreB < 6)
                {
                    if (die1B < die2B)
                    {
                        die1B = rand.Next(1, 7);
                    }
                    else
                    {
                        die2B = rand.Next(1, 7);
                    }
                    Console.WriteLine("                                                           Player B re-rolled: " + die1B + " and " + die2B);
                    roundScoreB = die1B + die2B;
                }
                Console.WriteLine();
                Console.WriteLine("Player A's round score: " + roundScoreA + "                                  Player B's round score: " + roundScoreB);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                Console.ReadKey();
                Console.WriteLine();
                // players choice to stick or re-roll

                bool validChoice = false;
                int choiceA = 0;

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
                            if (die1A < die2A)
                            {
                                die1A = rand.Next(1, 7);
                            }
                            else
                            {
                                die2A = rand.Next(1, 7);
                            }
                            Console.WriteLine("Player A re-rolled: " + die1A + " and " + die2A);
                            roundScoreA = die1A + die2A;
                        }
                    }
                }
                TotalScoreA += roundScoreA;
                TotalScoreB += roundScoreB;
                Console.WriteLine();
                Console.WriteLine("Player A's total score: " + TotalScoreA + "                                  Player B's total score: " + TotalScoreB);
                Console.WriteLine();
                Console.WriteLine("PRESS ANY KEY TO MOVE TO THE NEXT ROUND");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
