using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int SellerID { get; set; }

        public virtual AuthModel Seller { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
