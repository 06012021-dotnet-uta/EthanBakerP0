using System.Threading.Tasks;
using System;

namespace AsyncAwait
{
    class AsyncMethodsClass 
    {
        public  async Task<string> Method1(){


            System.Console.WriteLine("Method1 before task ");
            Task task = Task.Delay(5000);
            string userInput = "yo";
            // string userInput = Console.ReadLine();
            await task;
            System.Console.WriteLine("Method1 after task ");
            return userInput;
        }

        // public  async Task<int> Method2(){

        //     Task task = Task.Delay(2000);

        //     System.Console.WriteLine("Please enter a number");
        //     int userInput = Int32.TryParse(Console.ReadLine());
        //     await task;
        //     return userInput;
        // }

    }
}
