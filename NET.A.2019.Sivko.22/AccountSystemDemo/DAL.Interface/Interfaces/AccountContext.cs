using System.Data.Entity;

namespace DAL.Interface.Interfaces 
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
