using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.Models
{
    public class MobileTransaction
    {
        public int ID { get; set; }

        public int SourceAuthModelID { get; set; }

        public virtual AuthModel SourceAuthModel { get; set; }

        public int DestinationAuthModelID { get; set; }

        public  virtual AuthModel DestinationModelAuthModel { get; set; }

        public float Ammount { get; set; }


    }
}
