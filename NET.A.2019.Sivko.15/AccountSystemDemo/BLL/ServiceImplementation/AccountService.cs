using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Represents a collection of Bank accounts.
    /// </summary>
    public class AccountService: IAccountService<BankAccount>
    {
        public List<BankAccount> AccountList { get; private set; }

        /// <summary>
        /// Initializes the list of accounts.
        /// </summary>
        public AccountService()
        {
            AccountList = new List<BankAccount> { };
        }

        /// <summary>
        /// Adds a new account to the AccountList.
        /// </summary>
        public void AddNewAccount(BankAccount bankAccount)
        {
            foreach(BankAccount account in AccountList)
                if(bankAccount.ID.Equals(account.ID))
                    throw new Exception("Attempt to add an existing object");

            AccountList.Add(bankAccount);
        }

        /// <summary>
        /// Removes an account from the AccountList.
        /// </summary>
        public void RemoveAccount(BankAccount bankAccount)
        {
            if (!AccountList.Contains(bankAccount))
                throw new Exception("Attempt to delete a non-existing object");

            AccountList.Remove(bankAccount);
        }

        /// <summary>
        /// Saves a list of accounts to a file.
        /// </summary>
        /// <param name="storage">Storage type.</param>
        public void WriteToFile(IRepository<BankAccount> storage)
        {
            storage.WriteFile(AccountList);
        }

        /// <summary>
        /// Reads accounts from a file.
        /// </summary>
        /// <param name="storage">Storage type.</param>
        public void ReadFromFile(IRepository<BankAccount> storage)
        {
            AccountList = storage.ReadFile(AccountList);
        }

        /// <summary>
        /// Returns list of accounts.
        /// </summary>
        /// <returns>List of accounts.</returns>
        public List<BankAccount> GetAllAccounts()
        {
            return AccountList;
        }

        /// <summary>
        /// Deposits money into the relevant account.
        /// </summary>
        /// <param name="id">Account id.</param>
        /// <param name="cash">Deposit amount.</param>
        public void DepositAccount(string id, double cash)
        {
            for (int i = 0; i < AccountList.Count; i++)
                if (AccountList[i].ID.Equals(id))
                {
                    AccountList[i].Deposit(cash);
                    return;
                }

            throw new Exception("Account with matching ID not found");
        }

        /// <summary>
        /// Withdraws money from the relevant account.
        /// </summary>
        /// <param name="id">Account id.</param>
        /// <param name="cash">Withdraw amount.</param>
        public void WithdrawAccount(string id, double cash)
        {
            for (int i = 0; i < AccountList.Count; i++)
                if (AccountList[i].ID.Equals(id))
                {
                    AccountList[i].Withdraw(cash);
                    return;
                }

            throw new Exception("Account with matching ID not found");
        }
    }
}
