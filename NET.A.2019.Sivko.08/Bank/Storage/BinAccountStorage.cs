using System;
using System.Collections.Generic;
using System.IO;

namespace Bank
{
    public class BinAccountStorage: IStorage<BankAccount>
    {
        public string Path { get; set; }

        public BinAccountStorage(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Saves a list of accounts to a bin file
        /// </summary>
        /// <param name="path">File path</param>
        public void WriteFile(List<BankAccount> accounts)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (BankAccount account in accounts)
                {
                    binaryWriter.Write(account.GetType().FullName);
                    binaryWriter.Write(account.ID);
                    binaryWriter.Write(account.Owner.Name);
                    binaryWriter.Write(account.Owner.Surname);
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
        public List<BankAccount> ReadFile(List<BankAccount> accounts)
        {
            List<BankAccount> temp = new List<BankAccount>();
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
                    var obj = (BankAccount)Activator.CreateInstance(type, id, new AccountOwner(name, surname), balance, bonus, open);

                    temp.Add(obj);
                }
            }

            return temp;
        }
    }
}
