﻿using System;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RpsChoice{
            Rock = 1,
            Paper= 2,
            Scissors = 3,
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors\nWhat is your name?");
            string playerName = Console.ReadLine();
              
            bool successfulConversion = false;
            int playerChoiceInt;
            int playAgainInt;

            //loop to replay or exit
            do{
                int playerWins = 0;
                int computerWins = 0;
                int roundNumber = 1;
                Console.WriteLine("This will be a best two out of three match!");

                //loop to make games best of 3
                while(playerWins + computerWins != 2 && playerWins + computerWins <3)
                {
                    
                    Console.WriteLine($"Round {roundNumber} ");
                    //single game
                    do{
                        Console.WriteLine($"Choose your fighter (type number):\n 1) Rock\n 2) Paper\n 3) Scissors\n");
                        string playerChoice = Console.ReadLine();

                        //create int variable to catch choice
                        successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                        //out of bounds number check
                        if(playerChoiceInt > 3 || playerChoiceInt < 1){
                            Console.WriteLine($"{playerChoiceInt} is an inelligible choice");
                        }
                        else if (!successfulConversion){
                            Console.WriteLine($"{playerChoiceInt} is an inelligible choice");
                        }

                    } while (!successfulConversion || playerChoiceInt > 3  || playerChoiceInt < 1);


                    //random nubmer genration for computer choice
                    Random rand = new Random();
                    int computerChoice = rand.Next(1, 4);
                    
                    //displays choices
                    Console.WriteLine($"{playerName}: {(RpsChoice)playerChoiceInt}");
                    Console.WriteLine($"Computer: {(RpsChoice)computerChoice}");
                
                    //test win condtions 
                    if(playerChoiceInt == computerChoice){
                        Console.WriteLine("Tie");
                    }
                    else if((playerChoiceInt == 1 && computerChoice == 2 )|| (playerChoiceInt == 2 && computerChoice == 3) || (playerChoiceInt == 3 && computerChoice == 1)){
                        Console.WriteLine($"The computer wins the round!");
                        ++computerWins;
                    }
                    else{   
                        Console.WriteLine($"{playerName} wins the round!");
                        ++playerWins;
                    } 
                    Console.WriteLine($"The score is - {playerName}: {playerWins} Computer: {computerWins}");
                    ++roundNumber;
                };


                    if(playerWins == 2){ 
                        Console.WriteLine($"{playerName} wins the match!!");
                    }
                    else if (computerWins == 2){
                        Console.WriteLine($"The computer wins the match!!");
                    };

                    //ask player if they want to play agian
                do{ Console.WriteLine($"Do you want to play again? (type number):\n 1) Yes\n 2) No");
                    string playAgain = Console.ReadLine();


                    //create int variable to catch choice
                    successfulConversion = Int32.TryParse(playAgain, out playAgainInt);

                    //out of bounds number check
                    if(playAgainInt > 2 || playAgainInt < 1){
                        Console.WriteLine($"{playAgainInt} is an inelligible choice");
                    }
                    else if (!successfulConversion){
                        Console.WriteLine($"{playAgainInt} is an inelligible choice");
                    }

                } while (!successfulConversion || playAgainInt > 2 || playAgainInt < 1);

            }while(playAgainInt == 1);

        
        Console.WriteLine("Thanks for playing!");
        }
    }
}
