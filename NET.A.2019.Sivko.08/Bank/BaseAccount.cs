using System;

namespace Bank
{
    /// <summary>
    /// Base account type
    /// </summary>
    public class BaseAccount : BankAccount
    {
        private const int BalancePercent = 5;
        private const int ChangePercent = 10;

        public BaseAccount(string id, AccountOwner owner, double balance, int bonus = 0, bool open = true) : base(id, owner, balance, bonus, open)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent/100 + Balance * BalancePercent/100);
        }
    }
}
