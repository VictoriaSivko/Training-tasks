using System;
using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public abstract class BankAccount
    {
        private IAccountNumberCreateService createNumber;
        public Account account;

        /// <summary>
        /// Initializes one Bank account.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="createNumber"></param>
        /// <param name="bonus"></param>
        /// <param name="open"></param>
        public BankAccount(Account account, IAccountNumberCreateService createNumber)
        {
            this.account = account;
            this.createNumber = createNumber;
        }

        /// <summary>
        /// Puts money into account
        /// </summary>
        /// <param name="money">The amount of the Deposit</param>
        public void Deposit(double money)
        {
            if (money < 0)
                throw new Exception("The amount of replenishment of the balance must be positive");

            if (!account.Open)
                throw new Exception("Attempt to Deposit money into a closed account");

            account.Balance += money;

            account.Bonus += CalculateBonus(money);
        }

        /// <summary>
        /// Withdraws money from account
        /// </summary>
        /// <param name="money">The amount of the Withdraw</param>
        public void Withdraw(double money)
        {
            if (money < 0)
                throw new Exception("The amount of write-off must be positive");

            if (!account.Open)
                throw new Exception("Attempt to withdraw money from a closed account");

            if (account.Balance - money < 0)
                throw new Exception("Account has insufficient funds");

            account.Balance -= money;

            account.Bonus -= CalculateBonus(money)/2;
        }

        /// <summary>
        /// Open an account
        /// </summary>
        public void ToOpen()
        {
            account.Open = true;
        }

        /// <summary>
        /// Close an account
        /// </summary>
        public void ToClose()
        {
            account.Open = false;
        }

        /// <summary>
        /// Calculates the bonus after a Deposit or withdrawal
        /// </summary>
        public abstract int CalculateBonus(double money);

        /// <summary>
        /// Returns a string representation of the Bank account.
        /// </summary>
        /// <returns>The string representation of the Bank account.</returns>
        public override string ToString()
        {
            return String.Format($"Тип {this.GetType().Name} {account.ID} Owner {account.PersonID} Balance {account.Balance} Bonus {account.Bonus} Открыт: {account.Open}");
        }
    }
}
