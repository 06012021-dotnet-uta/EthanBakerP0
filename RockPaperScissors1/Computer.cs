using System;

namespace RockPaperScissors1
{
    public class Computer : Player
    {   
        public int computerChoice;
        public void getChoice(){                  
        Random rand = new Random();
        computerChoice = rand.Next(1, 4);
        }
    }
}