using DAL.Interface.Interfaces;
using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Account Service Interface. 
    /// </summary>
    /// <typeparam name="T">Type of account.</typeparam>
    public interface IAccountService<T>
    {
        List<T> GetAllAccounts();
        void DepositAccount(string id, double cash);
        void WithdrawAccount(string id, double cash);
        void AddNewAccount(T account);
        void RemoveAccount(T account);
        void WriteToFile(IRepository<T> repository);
        void ReadFromFile(IRepository<T> repository);
    }
}
