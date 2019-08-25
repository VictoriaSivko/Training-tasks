using System;

namespace Bank
{
    /// <summary>
    /// Gold account type
    /// </summary>
    public class GoldAccount: BankAccount
    {
        private const double BalancePercent = 9;
        private const double ChangePercent = 15;

        public GoldAccount(string id, AccountOwner owner, double balance, int bonus = 0) : base(id, owner, balance, bonus)
        {

        }

        public override int CalculateBonus(double money)
        {
            return (int)Math.Round(money * ChangePercent / 100 + Balance * BalancePercent / 100);
        }
    }
}
