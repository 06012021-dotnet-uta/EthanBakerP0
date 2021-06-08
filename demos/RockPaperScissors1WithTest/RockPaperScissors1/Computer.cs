using System;

namespace RockPaperScissors1
{
    public class Computer : Player
    {   
        public int computerChoice;

        /// <summary>
        /// uses System.Random.Next to generate random number between 1-3 to determine the computers rock, paper, scissors choice for the round. 
        /// </summary>
        public void GetChoice(){                  
        Random rand = new Random();
        computerChoice = rand.Next(1, 4);
        }
    }
}