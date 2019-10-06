using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Gold account type
    /// </summary>
    public class GoldAccount: BankAccount
    {
        private const double BalancePercent = 9;
        private const double ChangePercent = 15;

        public GoldAccount(Account account, IAccountNumberCreateService createNumber) : base(account, createNumber)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent / 100 + account.Balance * BalancePercent / 100);
        }
    }
}
