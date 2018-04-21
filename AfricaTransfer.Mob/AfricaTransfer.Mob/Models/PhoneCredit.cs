using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.Models
{
    public class PhoneCredit
    {
        public int ID { get; set; }

        public int AuthModelID { get; set; }

        public virtual AuthModel AuthModel { get; set; }

        public float Credit { get; set; }
    }
}
