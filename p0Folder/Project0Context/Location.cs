using System;
using System.Collections.Generic;

#nullable disable

namespace Project0Context
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
