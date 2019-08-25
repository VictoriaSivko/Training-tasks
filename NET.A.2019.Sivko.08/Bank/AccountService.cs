using System;
using System.Collections.Generic;
using System.IO;

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
        public void OpenNewAccount(BankAccount bankAccount)
        {
            foreach(BankAccount account in AccountList)
                if(bankAccount.ID.Equals(account.ID))
                    throw new Exception("Attempt to add an existing object");

            AccountList.Add(bankAccount);
        }

        /// <summary>
        /// Removes an account from the AccountList
        /// </summary>
        public void CloseAccount(BankAccount bankAccount)
        {
            if (!AccountList.Contains(bankAccount))
                throw new Exception("Attempt to delete a non-existing object");

            AccountList.Remove(bankAccount);
        }

        /// <summary>
        /// Saves a list of accounts to a file
        /// </summary>
        /// <param name="path">File path</param>
        public void WriteToBinFile(string path)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (BankAccount account in AccountList)
                {
                    binaryWriter.Write(account.GetType().FullName);
                    binaryWriter.Write(account.ID);
                    binaryWriter.Write(account.Owner.Name);
                    binaryWriter.Write(account.Owner.Surname);
                    binaryWriter.Write(account.Balance);
                    binaryWriter.Write(account.Bonus);
                }
            }
        }

        /// <summary>
        /// Retrieves accounts from a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of bank accounts</returns>
        public static List<BankAccount> GetAccounts(string path)
        {
            List<BankAccount> temp = new List<BankAccount>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string fullName = reader.ReadString();

                    string id = reader.ReadString();
                    string name = reader.ReadString();
                    string surname = reader.ReadString();
                    double balance = reader.ReadDouble();
                    int bonus = reader.ReadInt32();

                    var type = Type.GetType(fullName);
                    var obj = (BankAccount)Activator.CreateInstance(type, id, new AccountOwner(name, surname), balance, bonus);

                    temp.Add(obj);
                }
            }

            return temp;
        }
    }
}
