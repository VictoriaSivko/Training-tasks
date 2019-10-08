using System.Collections.Generic;
using BankAccountService.Domain.Entities;

namespace BankAccountService.Domain.Abstract
{
    public interface IBankAccountRepository
    {
        IEnumerable<BankAccount> BankAccounts { get; }
        void SaveAccount(BankAccount bankAccount);
        BankAccount DeleteAccount(int accID);
    }
}
