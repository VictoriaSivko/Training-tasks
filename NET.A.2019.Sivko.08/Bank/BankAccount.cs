using System;

namespace Bank
{
    public abstract class BankAccount
    {
        private string id;
        private double balance;

        public string ID
        {
            get { return id; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException();
                else
                    id = value;
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

        public BankAccount(string id, AccountOwner owner, double balance, int bonus = 0)
        {
            ID = id;
            Owner = owner;
            Balance = balance;
            Bonus = bonus;
        }

        /// <summary>
        /// Puts money into account
        /// </summary>
        /// <param name="money">The amount of the Deposit</param>
        public void Deposit(double money)
        {
            if (money < 0)
                throw new Exception("The amount of replenishment of the balance must be positive");

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

            if (Balance - money < 0)
                throw new Exception("Account has insufficient funds");

            Balance -= money;

            Bonus -= CalculateBonus(money)/2;
        }

        /// <summary>
        /// Calculates the bonus after a Deposit or withdrawal
        /// </summary>
        public abstract int CalculateBonus(double money);

        public override string ToString()
        {
            return String.Format($"Тип {this.GetType().Name} {id} Owner {Owner.Name} {Owner.Surname} Balance {balance} Bonus {Bonus}");
        }
    }
}
