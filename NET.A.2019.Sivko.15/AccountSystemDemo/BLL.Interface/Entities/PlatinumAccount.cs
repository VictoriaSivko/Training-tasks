using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
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

        public PlatinumAccount(AccountOwner owner, double balance, IAccountNumberCreateService createNumber, int bonus = 0, bool open = true) : base(owner, balance, createNumber, bonus, open)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent / 100 + Balance * BalancePercent / 100);
        }
    }
}
