using BLL.Interface.Entities;
using BLL.Interface.Entities.Helper;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.Repositories
{
    /// <summary>
    /// Binary representation of a Bank account.
    /// </summary>
    public class AccountBinaryRepository: IRepository<AccountContext>
    {
        public string Path { get; set; }

        public AccountBinaryRepository(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Saves a list of accounts to a bin file
        /// </summary>
        /// <param name="path">File path</param>
        public void WriteFile(AccountContext accounts)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (Account account in accounts.Accounts)
                {
                    binaryWriter.Write(account.GetType().FullName);
                    binaryWriter.Write(account.ID);
                    binaryWriter.Write(account.PersonID);
                    binaryWriter.Write(account.Balance);
                    binaryWriter.Write(account.Bonus);
                    binaryWriter.Write(account.Open);
                }
            }
        }

        /// <summary>
        /// Retrieves accounts from a bin file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of bank accounts</returns>
        public AccountContext ReadFile(AccountContext accounts)
        {
            AccountContext temp = new AccountContext();

            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string fullName = reader.ReadString();

                    string id = reader.ReadString();
                    string name = reader.ReadString();
                    string surname = reader.ReadString();
                    double balance = reader.ReadDouble();
                    int bonus = reader.ReadInt32();
                    bool open = reader.ReadBoolean();

                    var type = Type.GetType(fullName);
                    var obj = (Account)Activator.CreateInstance(type, new Account());

                    temp.Accounts.Add(obj);
                }
            }

            return temp;
        }
    }
}
