using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AfricaTransfer.CoreLib.Models
{
    public class AuthModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
    }
}
