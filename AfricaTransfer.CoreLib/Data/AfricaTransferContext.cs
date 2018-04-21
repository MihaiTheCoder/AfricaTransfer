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
    }
}
