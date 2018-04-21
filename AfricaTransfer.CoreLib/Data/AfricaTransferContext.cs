using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AfricaTransfer.CoreLib.Models;

namespace AfricaTransfer.CoreLib.Models
{
    public class AfricaTransferContext : DbContext
    {
        public AfricaTransferContext (DbContextOptions<AfricaTransferContext> options)
            : base(options)
        {
        }

        public DbSet<AfricaTransfer.CoreLib.Models.AuthModel> AuthModel { get; set; }

        public DbSet<PhoneCredit> PhoneCredit { get; set; }

        public DbSet<MobileTransaction> MobileTransaction { get; set; }

        public DbSet<BankTransaction> BankTransaction { get; set; }
    }
}
