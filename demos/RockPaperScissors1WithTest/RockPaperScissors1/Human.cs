using System;
namespace RockPaperScissors1
{
    public class Human : Player
    {
        public string playerName;
        bool successfulConversion = false;
        public int playerChoiceInt;

        /// <summary>
        /// assigns player name to player-human object
        /// </summary>
        /// <param name="name"></param>        
        public void GetName(string name){
            playerName = name;
        }
        /// <summary>
        /// gets player's choice between Rock, Paper, Scissors and makes sure option is an elligible choice
        /// </summary>
        public void GetChoice(){
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

            } while (!successfulConversion || playerChoiceInt > 3  || playerChoiceInt < 1); //repropmts user if inelligilbe choice
        }
    }   
}