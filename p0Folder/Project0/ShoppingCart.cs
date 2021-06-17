using System.Collections.Generic;
using System.Linq;

namespace Project0
{
    public class ShoppingCart {
        /// <summary>
        /// List holding the product names of the contents of users cart
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        public List<string> shoppingCartListProductNames = new List<string>();
        
        /// <summary>
        /// List holding the product prices of the contents of users cart
        /// </summary>
        /// <typeparam name="decimal"></typeparam>
        /// <returns></returns>
        public List<decimal> shoppingCartListPrices = new List<decimal>();

        /// <summary>
        /// List holding the product ids of the contents of users cart
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <returns></returns>
        public List<int> shoppingCartListProductIds = new List<int>();

        /// <summary>
        /// List holding the location ids of the contents of users cart
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <returns></returns>
        public List<int> shoppingCartListLocationIds = new List<int>();

        /// <summary>
        /// Displays current cart contents
        /// </summary>
        public void DisplayCart(){
            System.Console.WriteLine("*****************************************************************");
            System.Console.WriteLine("Your current cart contains:");
            shoppingCartListProductNames.ForEach(System.Console.WriteLine);
            System.Console.WriteLine($"Your total cart price is ${TotalCartPrice()}");
            System.Console.WriteLine("*****************************************************************");
  
        }

        /// <summary>
        /// Sums the prices of the products in the users cart and returns its total price
        /// </summary>
        public decimal TotalCartPrice(){ 
            decimal total = shoppingCartListPrices.Sum();
            return total;
        }

        /// <summary>
        /// Resets the cart to empty
        /// </summary>
        public void ResetCart() {
            int listSize = shoppingCartListProductIds.Count();
            shoppingCartListProductNames.RemoveRange(0,listSize);
            shoppingCartListPrices.RemoveRange(0,listSize);
            shoppingCartListProductIds.RemoveRange(0,listSize);
            shoppingCartListLocationIds.RemoveRange(0,listSize);
        }

    }
}
