using System;

namespace RockPaperScissors
{
    class Program
    {
        const int ROCK = 1;
        const int PAPER = 2;
        const int SCISSORS = 3;

        static void Main(string[] args)
        {
           
            Console.WriteLine("Let's play rock paper scissors!");
            Random r = new Random();
            int pcScore = 0;
            int playerScore = 0;

            while(true)
            {
                int pcChoice = r.Next (1,3);

                Console.WriteLine("-----------------------");
                Console.WriteLine("Current score:");
                Console.WriteLine("Player: {0}", playerScore);
                Console.WriteLine("PC: {0}", pcScore);
                Console.WriteLine("-----------------------");
                
                Console.WriteLine("Make your choice!");
                Console.WriteLine("1 - Rock; 2 - Paper; 3 - Scissors; 0 - Quit");

                int playerChoice;
                if (!int.TryParse(Console.ReadLine(), out playerChoice))
                {
                    Console.WriteLine("That's not a number!");
                }
                else if (playerChoice >= 4 || playerChoice < 0)
                {
                    Console.WriteLine("That's not a valid option!");
                } 
                else if ( playerChoice == 0)
                {
                    Console.WriteLine("Bye!");
                    return;
                }
                else
                {
                    string winner = CheckWinner(pcChoice, playerChoice);
                    Console.WriteLine("PC choice was {0}", ChoiceToText(pcChoice));
                    Console.WriteLine("Player choice was {0}", ChoiceToText(playerChoice));
                    
                    if (winner == "PC")
                    {
                        Console.WriteLine("I won! :D");
                        pcScore++;
                    }
                    else if  (winner == "Player")
                    {
                        Console.WriteLine("You won! :/");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine("It's a draw!");
                    }
                }  
            }          
        }

        static string CheckWinner(int pcChoice, int playerChoice)
        {
            // PC	Player  Result
            // R	P	    Player
            // R	S	    PC
            // P	R	    PC
            // P	S	    Player
            // S	R	    Player
            // S	P	    PC
   
            if (playerChoice == pcChoice)
            {
                return "Draw";   
            }
            else if (pcChoice == ROCK && playerChoice == PAPER )
            {
                return "Player";
            } 
            else if (pcChoice == ROCK && playerChoice == SCISSORS)
            {
                return "PC";
            }
            else if (pcChoice == PAPER && playerChoice == ROCK)
            {
                return "PC";
            }
            else if (pcChoice == PAPER && playerChoice == SCISSORS)
            {
                return "Player";
            }
            else if (pcChoice == SCISSORS && playerChoice == ROCK)
            {
                return "Player";
            } 
            else if (pcChoice == SCISSORS && playerChoice == PAPER)
            {
                return "PC";
            }

            return "Unknown";

        }

        static string ChoiceToText(int choice)
        {
            switch(choice)
            {
                case ROCK:
                    return "Rock";
                case PAPER:
                    return "Paper";
                case SCISSORS:
                    return "Scissors";
                default:
                    return "Unknown";                    
            }
        }
    }
}
