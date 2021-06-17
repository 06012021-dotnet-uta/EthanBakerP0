using System;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();

            //loops application
            do
            {
                methods.MenuSelector = methods.IntroPrompt();
                methods.IntroMenu(methods.MenuSelector);
                
                while(methods.customer == null){ //reprompts intro menu if invalid user id
                    System.Console.WriteLine($"That is an invalid id. Try again with a valid id or create a new account.");
                    methods.MenuSelector = methods.IntroPrompt();
                    methods.IntroMenu(methods.MenuSelector);     
                }

                methods.shoppingCart = new ShoppingCart(); //creates new user shopping cart 

                if(methods.MenuSelector == 3){
                    break; //exits app
                }
                else{
                //loops main menu for user
                    do{
                        methods.MenuSelector = methods.MainPrompt();
                        methods.MainMenu(methods.MenuSelector);
                    }while(methods.MenuSelector !=6);
                }

            } while (methods.MenuSelector != 3);
        }
    }
}
