using System;
using System.Linq;

namespace Project0
{
    public class Methods
    {
        Project0Context.project0Context context = new Project0Context.project0Context();
        Project0Context.Product product = new Project0Context.Product();
        Project0Context.Location location = new Project0Context.Location();
        Project0Context.Inventory inventory = new Project0Context.Inventory();
        public Project0Context.Customer customer = new Project0Context.Customer();
        public ShoppingCart shoppingCart = new ShoppingCart();

        private int menuSelector; 
        /// <summary>
        /// stores users menu selction 
        /// </summary>
        /// <value></value>
        
        public int MenuSelector {
            get => menuSelector;
            set {menuSelector = value;}
        }    

        /// <summary>
        /// Takes an input of a string containg a menu and an int of the number of menu options. Prints the menu and forces user input to be valid. 
        /// </summary>
        /// <param name="menuMessage"></param>
        /// <param name="numberOfMenuOptions"></param>
        /// <returns></returns>
        
        private int Menu(string menuMessage, int numberOfMenuOptions){

            bool successfulConversion = false;
            int userChoiceInt;
            do
            {
                Console.WriteLine(menuMessage);
                string userChoice = Console.ReadLine();

                //create int variable to catch choice
                successfulConversion = Int32.TryParse(userChoice, out userChoiceInt);

                //out of bounds number check
                if (userChoiceInt > numberOfMenuOptions || userChoiceInt < 1)
                {
                    Console.WriteLine($"{userChoiceInt} is an inelligible choice");
                }
                else if (!successfulConversion)
                {
                    Console.WriteLine($"{userChoiceInt} is an inelligible choice");
                }

            }while (!successfulConversion || userChoiceInt > numberOfMenuOptions || userChoiceInt < 1);

            return userChoiceInt;
        }

        /// <summary>
        /// Prints intro menu and gets user input
        /// </summary>
        /// <returns></returns>
        public int IntroPrompt(){

            string introMenuMessage = $"Welcome to the store application (type number to navigate):\n 1) Login\n 2) Create New Account\n 3) Exit";
            int introMenuOptions = 3;
            return Menu(introMenuMessage, introMenuOptions);
        }  

        /// <summary>
        /// Takes user's choice from the intro menu and navigates user to selected area
        /// </summary>
        /// <param name="userChoiceInt"></param>
        public void IntroMenu(int userChoiceInt){
            if(userChoiceInt == 1){

                Login();
            }
            else if(userChoiceInt == 2){

                AddNewCustomer();
            }
            else{

                System.Console.WriteLine("Thanks for shopping with us!");
            }
        }

        /// <summary>
        /// Prints main menu and gets user input
        /// </summary>
        /// <returns></returns>
        public int MainPrompt(){            
            string mainMenuMessage = $"Welcome to the main menu {customer.CustomerFirstName} {customer.CustomerLastName} ID#{customer.CustomerId} (type number to navigate):\n 1) Stores\n 2) Cart\n 3) User Order History\n 4) Location Order History\n 5) Checkout (Selecting this will finalize your order so only select this option if you want to checkout now)\n 6) Logout";
            int mainMenuOptions = 6;
            return Menu(mainMenuMessage, mainMenuOptions);    
        }

        /// <summary>
        /// Collect of the different areas the user can navigate
        /// </summary>
        /// <param name="userChoiceInt"></param>
        public void MainMenu(int userChoiceInt){
            if(userChoiceInt == 1){

                Shop();
            }
            else if(userChoiceInt == 2){

                shoppingCart.DisplayCart();
            }
            else if(userChoiceInt == 3){
                
                DisplayUserOrderHistory();
            }
            else if(userChoiceInt == 4){

                DisplayLocationOrderHistory();
            }
            else if(userChoiceInt == 5){
                
                Checkout();
                }
            else{
                System.Console.WriteLine("*****************************************************************");
                System.Console.WriteLine("Successfully logged out!");
                System.Console.WriteLine("*****************************************************************");
            }   
        }

        /// <summary>
        /// Prompts user to enter id, looks up that id in database, and then assigns that customer as the current app user
        /// </summary>
        public void Login(){
            //ask for user ID
            System.Console.WriteLine("Please enter your id to login:");
            int customerId = Convert.ToInt32(Console.ReadLine()); 
            
            //Finds user with coresponding ID in database
            var user = context.Customers.Find(customerId);

            //assigns class customer object to one found in database
            customer = user;  
        }
        
        /// <summary>
        /// Creates new customer, adds them to the database, and assigns the new customer as the current app user
        /// </summary>
        public void AddNewCustomer(){

        //Creates new customer object
        Project0Context.Customer newCustomer = new Project0Context.Customer(); 

        //Gets user info
        System.Console.WriteLine("What is your first name?");
        newCustomer.CustomerFirstName = Console.ReadLine();
        System.Console.WriteLine("What is your last name?");
        newCustomer.CustomerLastName = Console.ReadLine();

        //adds and saves user to database
        context.Customers.Add(newCustomer);
        context.SaveChanges();

        //assigns class customer object to newly created customer
        customer = newCustomer;
        }
        
        /// <summary>
        /// Displays store locations then the products at a chosen location and allows the user to add products to their cart
        /// </summary>
        public void Shop(){
            System.Console.WriteLine("Choose a store location:");

            //display store locations for user to choose from
            int numberOfLocations = context.Locations.Count();
            for(int i=1; i <= numberOfLocations; i++){
                var locationByKey = context.Locations.Find(i);
                System.Console.WriteLine($"{i}) {locationByKey.LocationName}");

            }
            int locationChoice =  Menu("",numberOfLocations);
            
            // display products from user chosen location 
            int numberOfProducts = context.Inventories.Count(x => x.LocationId == locationChoice);
            int [] productsAtLocation = context.Inventories.Where(x => x.LocationId == locationChoice).Select(x => x.ProductId).ToArray(); //array of productIDs from user chosen location
            for(int i=1; i <= numberOfProducts; i++){
                int productId = productsAtLocation[i-1]; 
                var productsByKey = context.Products.Find(productId);
                System.Console.WriteLine($"{i}) {productsByKey.ProductName}\n   ProductID #{productsByKey.ProductId}\n   Price ${productsByKey.ProductPrice}\n   Description - {productsByKey.ProductDescription}\n");
            }

            //add items to cart
            string moreItemsCheck;
            do{
                int productChoice = Menu("Input number to add one unit of the coresponding product to your shopping cart",numberOfProducts);
                int userChoiceProductId =  productsAtLocation[productChoice-1];
                var userChoiceProductsByKey = context.Products.Find(userChoiceProductId);
                shoppingCart.shoppingCartListProductNames.Add(userChoiceProductsByKey.ProductName); //List of product names in user cart
                shoppingCart.shoppingCartListPrices.Add(userChoiceProductsByKey.ProductPrice); //List of product prices in user cart
                shoppingCart.shoppingCartListProductIds.Add(userChoiceProductsByKey.ProductId);//List of product ids in user cart
                shoppingCart.shoppingCartListLocationIds.Add(locationChoice);//List of location ids of products in user cart
                System.Console.WriteLine("*****************************************************************");
                System.Console.WriteLine($"One {userChoiceProductsByKey.ProductName} added to your cart\nDo you want to add more products from this location to your cart?\n1) Yes\n2) No");
                System.Console.WriteLine("*****************************************************************");
                moreItemsCheck = Console.ReadLine();
            }while (moreItemsCheck != "2");
        }
        
        /// <summary>
        /// //displays user order history
        /// </summary>
        public void DisplayUserOrderHistory(){
            
        System.Console.WriteLine("*****************************************************************");
        System.Console.WriteLine("Your order history:");
        var userOrders = from u in context.Orders
                            where u.CustomerId.Equals(customer.CustomerId)
                            select u;
        foreach (var item in userOrders){
            System.Console.WriteLine($"Order#{item.OrderId} {item.OrderTime}");
        }
        System.Console.WriteLine("*****************************************************************");

        }
        
        /// <summary>
        /// Displays a menu of locations with  for the user to choose from which displays chosen locations order history
        /// </summary>
        public void DisplayLocationOrderHistory(){
            System.Console.WriteLine("Choose a location to view its order history:");

            //displays locations for user to look at those location's order history
            int numberOfLocations = context.Locations.Count();
            for(int i=1; i <= numberOfLocations; i++){
                var locationByKey = context.Locations.Find(i);
                System.Console.WriteLine($"{i}) {locationByKey.LocationName}");

            }
            int locationChoice =  Menu("",numberOfLocations);

            //queries database to find the orders and order products associated with a location id and prints to console
            var locationOrders = from u in context.OrderDetails
                                where u.LocationId.Equals(locationChoice)
                                select u;
            System.Console.WriteLine("*****************************************************************");
            System.Console.WriteLine($"OrderID | Product Sold (by ID) ");
            foreach (var item in locationOrders){
                System.Console.WriteLine($"  {item.OrderId}      {item.ProductId}");
            }
            System.Console.WriteLine("*****************************************************************");
        }
        
        /// <summary>
        /// checks user out by adding new order and order details to the database then empties cart 
        /// </summary>
        public void Checkout(){
            //adds new order to order table in database
            Project0Context.Order newOrder = new Project0Context.Order();
            newOrder.CustomerId = customer.CustomerId;
            DateTime orderDate = DateTime.Now;
            newOrder.OrderTime = orderDate;
            context.Orders.Add(newOrder);
            context.SaveChanges();

            //adds orderID, locationID, and productID to orderDetails table in db
            int sizeOfCart = shoppingCart.shoppingCartListProductIds.Count();
            for(int i=0; i < sizeOfCart; i++){
                Project0Context.OrderDetail orderDetails = new Project0Context.OrderDetail();
                orderDetails.OrderId = newOrder.OrderId;
                orderDetails.LocationId = shoppingCart.shoppingCartListLocationIds[i];
                orderDetails.ProductId = shoppingCart.shoppingCartListProductIds[i];
                context.OrderDetails.Add(orderDetails);
                context.SaveChanges();
            }

            //alerts user they have completed checkout
            System.Console.WriteLine("*****************************************************************");
            System.Console.WriteLine($"Checkout completed for a total of ${shoppingCart.TotalCartPrice()}!");
            System.Console.WriteLine("*****************************************************************");

            //empties shopping cart
            shoppingCart.ResetCart();

        }

    }

}
