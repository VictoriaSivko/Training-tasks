using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
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

        public BaseAccount(AccountOwner owner, double balance, IAccountNumberCreateService createNumber, int bonus = 0, bool open = true) : base(owner, balance, createNumber, bonus, open)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent/100 + Balance * BalancePercent/100);
        }
    }
}
