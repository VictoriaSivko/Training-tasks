using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Platinum account type
    /// </summary>
    public class PlatinumAccount: BankAccount
    {
        private const double BalancePercent = 14;
        private const double ChangePercent = 21;

        public PlatinumAccount(Account account, IAccountNumberCreateService createNumber) : base(account, createNumber)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent / 100 + account.Balance * BalancePercent / 100);
        }
    }
}
