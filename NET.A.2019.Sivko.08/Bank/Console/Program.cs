using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseAccount baseAccount = new BaseAccount("base1", new AccountOwner("name1", "surname1"), 4);
            baseAccount.Deposit(25);

            GoldAccount goldAccount = new GoldAccount("gold1", new AccountOwner("name2", "surname2"), 4);
            goldAccount.Deposit(25);

            PlatinumAccount platinumAccount = new PlatinumAccount("platinum1", new AccountOwner("name2", "surname2"), 4);
            platinumAccount.Deposit(25);

            Console.WriteLine(baseAccount.ToString());
            Console.WriteLine(goldAccount.ToString());
            Console.WriteLine(platinumAccount.ToString());

            List<BankAccount> bankAccountsList = new List<BankAccount>();
            bankAccountsList.Add(baseAccount);
            bankAccountsList.Add(goldAccount);
            bankAccountsList.Add(platinumAccount);

            AccountService accounts = new AccountService(bankAccountsList);

            accounts.WriteToBinFile(@"D:\AccountListStorage.txt");

            accounts = new AccountService(AccountService.GetAccounts(@"D:\AccountListStorage.txt"));
            accounts.AccountList[0].Deposit(25);
            accounts.AccountList[1].Deposit(25);
            accounts.AccountList[2].Deposit(25);

            Console.WriteLine("\n" + accounts.AccountList[0].ToString());
            Console.WriteLine(accounts.AccountList[1].ToString());
            Console.WriteLine(accounts.AccountList[2].ToString());

            Console.ReadKey();
        }
    }
}
