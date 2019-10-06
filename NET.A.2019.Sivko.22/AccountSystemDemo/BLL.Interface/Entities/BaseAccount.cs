using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Base account type
    /// </summary>
    public class BaseAccount : BankAccount
    {
        private const int BalancePercent = 5;
        private const int ChangePercent = 10;

        public BaseAccount(Account account, IAccountNumberCreateService createNumber) : base(account, createNumber)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent/100 + account.Balance * BalancePercent/100);
        }
    }
}
