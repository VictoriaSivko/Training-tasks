using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountService.Domain.Entities;
using BankAccountService.Domain.Abstract;

namespace BankAccountService.Domain.Concrete
{
    public class EFBankAccountRepository : IBankAccountRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<BankAccount> BankAccounts
        {
            get { return context.BankAccounts; }
        }

        public void SaveAccount(BankAccount bankAccount)
        {
            if (bankAccount.BankAccountId == 0)
                context.BankAccounts.Add(bankAccount);
            else
            {
                BankAccount dbEntry = context.BankAccounts.Find(bankAccount.BankAccountId);
                if (dbEntry != null)
                {
                    dbEntry.Name = bankAccount.Name;
                    dbEntry.Balance = bankAccount.Balance;
                    dbEntry.Bonus = bankAccount.Bonus;
                    dbEntry.OpenAcc = bankAccount.OpenAcc;
                }
            }
            context.SaveChanges();
        }

        public BankAccount DeleteAccount(int accID)
        {
            BankAccount dbEntry = context.BankAccounts.Find(accID);
            if (dbEntry != null)
            {
                context.BankAccounts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
