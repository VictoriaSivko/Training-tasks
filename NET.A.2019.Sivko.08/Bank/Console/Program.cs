using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseAccount baseAccount = new BaseAccount("base1", new AccountOwner("name1", "surname1"), 4);
            GoldAccount goldAccount = new GoldAccount("gold1", new AccountOwner("name2", "surname2"), 4);
            PlatinumAccount platinumAccount = new PlatinumAccount("platinum1", new AccountOwner("name2", "surname2"), 4);
            baseAccount.Deposit(25);
            goldAccount.Deposit(25);
            platinumAccount.Deposit(25);

            Console.WriteLine(baseAccount.ToString());
            Console.WriteLine(goldAccount.ToString());
            Console.WriteLine(platinumAccount.ToString());

            List<BankAccount> bankAccountsList = new List<BankAccount>();
            bankAccountsList.Add(baseAccount);
            bankAccountsList.Add(goldAccount);
            bankAccountsList.Add(platinumAccount);

            AccountService accounts = new AccountService(bankAccountsList);

            accounts.AddNewAccount(new BaseAccount("base2", new AccountOwner("name2", "surname2"), 6));

            try
            {
                accounts.AddNewAccount(new BaseAccount("base2", new AccountOwner("name2", "surname2"), 6));
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            Console.WriteLine("\nAdded new account:");
            View(accounts.AccountList);

            accounts.RemoveAccount(accounts.AccountList[3]);

            accounts.WriteToFile(new BinAccountStorage(@"D:\AccountListStorage.bin"));

            Console.WriteLine("\nWithdrawals from accounts in the bin storage:");
            accounts.ReadFromFile(new BinAccountStorage(@"D:\AccountListStorage.bin"));
            accounts.AccountList[0].Withdraw(20);
            accounts.AccountList[1].Withdraw(20);
            accounts.AccountList[2].Withdraw(20);

            View(accounts.AccountList);

            Console.WriteLine("\nThe closure of the account");
            accounts.AccountList[0].ToClose();
            Console.WriteLine(accounts.AccountList[0].ToString());

            Console.ReadKey();
        }

        private static void View(List<BankAccount> temp)
        {
            foreach (BankAccount account in temp)
                Console.WriteLine(account.ToString());
        }
    }
}
