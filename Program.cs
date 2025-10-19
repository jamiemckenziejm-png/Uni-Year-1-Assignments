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
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Hello " + userName + ", Welcome to the DICE BATTLE GAME!! ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void DisplayGameRules()
        {
            Console.WriteLine("GAME RULES:");
            Console.WriteLine("1. The game is played between two players (Player A = you : Player B = the computer) over 3 rounds");
            Console.WriteLine();
            Console.WriteLine("2. Each player takes turns to roll two dice.");
            Console.WriteLine();
            Console.WriteLine("3. Player A will choose each round to 'STICK' with the score they have or to 'RE-ROLL' the dice with the lowest value.");
            Console.WriteLine();
            Console.WriteLine("4. Player B will 'RE-ROLL' if there score is less than 6 and 'STICK' if higher.");
            Console.WriteLine();
            Console.WriteLine("5. Each roll for both players will be recorded inlcuding a Total Score.");
            Console.WriteLine();
            Console.WriteLine("6. Results will be displaed at the end of the game.");
            Console.WriteLine();
            Console.WriteLine("7. The player with the highest Total Score after 3 rounds wins the game.");
            Console.WriteLine();
            Console.WriteLine("8. In The event of a tie, the player whole rolled the most 6's will be declared the winner.");
            Console.WriteLine();
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
            Console.Clear();
        }
        static void DiceGame()
        {
            int TotalScoreA = 0, TotalScoreB = 0;
            for (int round = 1; round <= 3; round++)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"       Round {round}        ");
                Console.WriteLine("-----------------------------");
                //Player A Turn
                Console.WriteLine();
                Console.WriteLine("PLAYER A'S TURN");

                // Random Dice Roll for Player A
                Random rand = new Random();
                Console.WriteLine("Press any key to roll the dice:");
                Console.ReadKey();
                int die1A = rand.Next(1, 7);
                int die2A = rand.Next(1, 7);
                Console.WriteLine("Player A rolled: " + die1A + " and " + die2A);
                Console.Write("Would you like to: \n 1:Stick \n 2:Re-roll \n\nYou selected option: ");
                int choiceA = Convert.ToInt32(Console.ReadLine());

                // Player A choice loop for re-roll or stick input validation
                while (true)
                {
                    if (choiceA == 1)
                    {
                        break;
                    }
                    else if (choiceA == 2)
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
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter '1' or '2'");
                        choiceA = Convert.ToInt32(Console.ReadLine());
                    }
                }
                // total score calculation for player A
                int roundScoreA = die1A + die2A;
                TotalScoreA += roundScoreA;
                Console.WriteLine();
                Console.WriteLine("Player A's round score: " + roundScoreA);
                Console.WriteLine();
                Console.WriteLine("Player A's total score: " + TotalScoreA);
                Console.WriteLine();
                Console.WriteLine("PRESS ANY KEY TO MOVE TO PLAYER B'S TURN");
                Console.ReadKey();
                Console.Clear();

                //Player B Turn
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"       Round {round}        ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                Console.WriteLine("PLAYER B'S TURN");
                Console.WriteLine();
                Console.WriteLine("Press any key to roll the dice:");
                Console.ReadKey();
                Console.WriteLine();
                int die1B = rand.Next(1, 7);
                int die2B = rand.Next(1, 7);
                Console.WriteLine("Player B rolled: " + die1B + " and " + die2B);
                int roundScoreB = die1B + die2B;
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
                    Console.WriteLine("Player B re-rolled: " + die1B + " and " + die2B);
                    roundScoreB = die1B + die2B;
                }
                TotalScoreB += roundScoreB;
                Console.WriteLine("Player B's round score: " + roundScoreB);
                Console.WriteLine();
                Console.WriteLine("Player B's total score: " + TotalScoreB);
                Console.WriteLine();
                Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
