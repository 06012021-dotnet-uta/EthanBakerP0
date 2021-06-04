using System;

namespace RockPaperScissors1
{
    public class RPSGame
    {
        public int roundNumber = 1;
        public int playerWins = 0;
        public int computerWins = 0;
    
        public string playerChoice;
        bool successfulConversion = false;
        int playAgainInt;
       

       public void testWinConditions(string playerName,int playerChoiceInt, int computerChoice){

                if(playerChoiceInt == computerChoice){
                    Console.WriteLine("Tie");
                }
                else if((playerChoiceInt == 1 && computerChoice == 2 )|| (playerChoiceInt == 2 && computerChoice == 3) || (playerChoiceInt == 3 && computerChoice == 1)){
                    Console.WriteLine($"The computer wins the round!");
                    ++computerWins;
                }
                else{   
                    Console.WriteLine($"{playerName} wins the round!");
                    playerWins++;
                } 
                Console.WriteLine($"The score is - {playerName}: {playerWins} Computer: {computerWins}");
                roundNumber++;
       }


        public void matchWinner(string playerName){
            if(playerWins == 2){ 
                Console.WriteLine($"{playerName} wins the match!!");
            }
            else if (computerWins == 2){
                Console.WriteLine($"The computer wins the match!!");
            }
        }


        public int playAgain(){

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

            playerWins = 0;
            computerWins = 0;
            roundNumber = 1;
            
            return playAgainInt;

        }   
    }
}