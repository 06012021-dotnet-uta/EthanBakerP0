using System;
using System.Collections.Generic;

#nullable disable

namespace Project0Context
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
