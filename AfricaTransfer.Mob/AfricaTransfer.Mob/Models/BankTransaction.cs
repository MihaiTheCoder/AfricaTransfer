using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.Models
{
    public class BankTransaction
    {
        public int ID { get; set; }

        public int? SourceBankID { get; set; }
        
        public float Ammount { get; set; }

        public int DestinationAuthModelID { get; set; }

        public virtual AuthModel DestinationAuthModel { get; set; }
    }
}
