using System;

namespace Bank
{
    /// <summary>
    /// Platinum account type
    /// </summary>
    public class PlatinumAccount: BankAccount
    {
        private const double BalancePercent = 14;
        private const double ChangePercent = 21;

        public PlatinumAccount(string id, AccountOwner owner, double balance, int bonus = 0) : base(id, owner, balance, bonus)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent / 100 + Balance * BalancePercent / 100);
        }
    }
}
