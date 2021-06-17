using System;
using System.Collections.Generic;

#nullable disable

namespace Project0Context
{
    public partial class OrderDetail
    {
        public int DetailsId { get; set; }
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
