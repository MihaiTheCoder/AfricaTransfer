using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.Models
{
    public class OrderLine
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public float ProductPrice { get; set; }

        public float Quantity { get; set; }

        public int OrderID { get; set; }
    }
}
