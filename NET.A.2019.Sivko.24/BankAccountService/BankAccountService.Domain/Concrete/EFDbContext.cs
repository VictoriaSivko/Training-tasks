using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountService.Domain.Entities;
using System.Data.Entity;

namespace BankAccountService.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
