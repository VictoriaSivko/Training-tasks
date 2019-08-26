using System;
using System.Collections.Generic;

namespace Bank
{
    public class AccountService
    {
        public List<BankAccount> AccountList { get; private set; }

        public AccountService(List<BankAccount> bankAccounts)
        {
            AccountList = bankAccounts;
        }

        /// <summary>
        /// Adds a new account to the AccountList
        /// </summary>
        public void AddNewAccount(BankAccount bankAccount)
        {
            foreach(BankAccount account in AccountList)
                if(bankAccount.ID.Equals(account.ID))
                    throw new Exception("Attempt to add an existing object");

            AccountList.Add(bankAccount);
        }

        /// <summary>
        /// Removes an account from the AccountList
        /// </summary>
        public void RemoveAccount(BankAccount bankAccount)
        {
            if (!AccountList.Contains(bankAccount))
                throw new Exception("Attempt to delete a non-existing object");

            AccountList.Remove(bankAccount);
        }

        /// <summary>
        /// Saves a list of accounts to a file
        /// </summary>
        /// <param name="storage">Storage type</param>
        public void WriteToFile(IStorage<BankAccount> storage)
        {
            storage.WriteFile(AccountList);
        }

        /// <summary>
        /// Reads accounts from a file
        /// </summary>
        /// <param name="storage">Storage type</param>
        public void ReadFromFile(IStorage<BankAccount> storage)
        {
            AccountList = storage.ReadFile(AccountList);
        }
    }
}
