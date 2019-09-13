using System;
using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public abstract class BankAccount
    {
        private string id;
        private double balance;
        private IAccountNumberCreateService createNumber;
        public bool Open { get; private set; }

        public string ID
        {
            get { return id; }
            private set
            {
                if (createNumber == null)
                    throw new ArgumentNullException("createNumber");

                id = createNumber.GenerateId(Owner.Surname);
            }
        }
        public AccountOwner Owner { get; private set; }
        public double Balance
        {
            get { return balance; }
            private set
            {
                if (value < 0)
                    throw new Exception("Unable to create account with negative balance");
                balance = value;
            }
        }
        public int Bonus { get; private set; }

        /// <summary>
        /// Initializes one Bank account.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="createNumber"></param>
        /// <param name="bonus"></param>
        /// <param name="open"></param>
        public BankAccount(AccountOwner owner, double balance, IAccountNumberCreateService createNumber, int bonus = 0, bool open = true)
        {
            Owner = owner;
            Balance = balance;
            Bonus = bonus;
            Open = open;

            this.createNumber = createNumber;
            ID = "0";
        }

        /// <summary>
        /// Puts money into account
        /// </summary>
        /// <param name="money">The amount of the Deposit</param>
        public void Deposit(double money)
        {
            if (money < 0)
                throw new Exception("The amount of replenishment of the balance must be positive");

            if (!Open)
                throw new Exception("Attempt to Deposit money into a closed account");

            Balance += money;

            Bonus += CalculateBonus(money);
        }

        /// <summary>
        /// Withdraws money from account
        /// </summary>
        /// <param name="money">The amount of the Withdraw</param>
        public void Withdraw(double money)
        {
            if (money < 0)
                throw new Exception("The amount of write-off must be positive");

            if (!Open)
                throw new Exception("Attempt to withdraw money from a closed account");

            if (Balance - money < 0)
                throw new Exception("Account has insufficient funds");

            Balance -= money;

            Bonus -= CalculateBonus(money)/2;
        }

        /// <summary>
        /// Open an account
        /// </summary>
        public void ToOpen()
        {
            Open = true;
        }

        /// <summary>
        /// Close an account
        /// </summary>
        public void ToClose()
        {
            Open = false;
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
            return String.Format($"Тип {this.GetType().Name} {id} Owner {Owner.Name} {Owner.Surname} Balance {balance} Bonus {Bonus} Открыт: {Open}");
        }
    }
}
