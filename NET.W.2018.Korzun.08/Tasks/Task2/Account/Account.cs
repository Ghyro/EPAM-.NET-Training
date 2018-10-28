using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Task2.Bonus;

namespace Tasks
{
    /// <summary>
    /// Develop a type system for describing work with a bank account. The state of the account is determined by its number,
    /// data on the account holder (name, surname), the amount on the account and some bonus points that increase / 
    /// decrease each time the account is refilled / debited from the account for values
    /// different for replenishment and withdrawal and are calculated
    /// depending on some the values of the "value" of the balance and the "cost" of replenishment
    /// </summary>
    public abstract class Account : IEquatable<Account> //Some bank account
    {

        #region Entities
        private int _Id;
        private string _Name;
        private string _Surname;
        private decimal _Amount; //balance
        private int _Bonus;        
        public abstract AccountType AccountType { get; }

        private IBonus _BonusToWithdraw = new BonusWithdraw();
        private IBonus _BonusToReplenishment = new BonusReplenishment();
        public abstract int BonusPointToWithdraw { get; set; }
        public abstract int BonusPointToReplenishment { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Initialization entities by constructor
        /// </summary>
        /// <param name="id">The id of bank account</param>
        /// <param name="name">The name of holder account</param>
        /// <param name="surname">The surname of holder account</param>
        /// <param name="amount">The balance of account</param>
        /// <param name="bonus">Bonus points</param>
        public Account(int id, string name, string surname, decimal amount, int bonus)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Amount = amount;
            this.Bonus = bonus;

        }

        /// <summary>
        /// Initialization entities by constructor
        /// </summary>
        /// <param name="id">The id of bank account</param>
        /// <param name="name">The name of holder account</param>
        /// <param name="surname">The surname of holder account</param>
        /// <param name="amount">The balance of account</param>
        /// <param name="bonus">Bonus points</param>
        /// <param name="bonusToWithdraw">Bonus by withdraw</param>
        /// <param name="bonusToReplenishment">Bonus by replenishment</param>
        public Account(int id, string name, string surname, decimal amount, int bonus, IBonus bonusToWithdraw, IBonus bonusToReplenishment)
            : this (id, name, surname, amount, bonus)
        {
            this.BonusToWithdraw = bonusToWithdraw;
            this.BonusToReplenishment = bonusToReplenishment;
        }
        #endregion

        #region PropertiesLogic
        /// <summary>
        /// The id of account
        /// </summary>
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must not be less than 0.");
                }

                _Id = value;
            }
        }

        /// <summary>
        /// The name of holder account
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _Name = value;
            }
        }

        /// <summary>
        /// The surname of holder account
        /// </summary>
        public string Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _Surname = value;
            }
        }

        /// <summary>
        /// The balance of account
        /// </summary>
        public decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must not be less than 0.");
                }

                _Amount = value;
            }
        }

        /// <summary>
        /// Bonus points
        /// </summary>
        public int Bonus
        {
            get
            {
                return _Bonus;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must not be less than 0.");
                }

                _Bonus = value;
            }
        }

        /// <summary>
        /// Bonus by withdraw
        /// </summary>
        public IBonus BonusToWithdraw
        {
            get
            {
                return _BonusToWithdraw;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _BonusToWithdraw = value;
            }
        }

        /// <summary>
        /// Bonus by replenishment
        /// </summary>
        public IBonus BonusToReplenishment
        {
            get
            {
                return _BonusToReplenishment;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _BonusToReplenishment = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculation of bonuses for deducting funds
        /// </summary>
        /// <param name="money">Input money</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="money"/>is < 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="money"/>is > balance (amount).
        /// </exception>
        public void WithdrawMoney(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException(nameof(money));
            }

            if (money > Amount)
            {
                throw new ArgumentException(nameof(money));
            }

            Amount -= money;

            int bonusBalance = Bonus - BonusToReplenishment.GetBonusPoints(this, money);

            Bonus = bonusBalance > 0 ? bonusBalance : 0;
        }

        /// <summary>
        /// Calculation of bonuses for depositing funds
        /// </summary>
        /// <param name="money">Input money</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="money"/>is < 0.
        /// </exception>
        public void ReplenishmentMoney(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException(nameof(money));
            }

            Amount += money;

            Bonus = Bonus + BonusToReplenishment.GetBonusPoints(this, money);
        }

        /// <summary>
        /// Override object method ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, name: {this.Name}, surname: {this.Surname}, amount: {this.Amount}, bonus points: {this.Bonus}, account type: {this.AccountType}";
        }

        /// <summary>
        /// Get hash code ToString()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Equivalence relation
        /// </summary>
        /// <param name="account">Object of <see cref="Account"/></param>
        /// <returns>true or false</returns>
        public bool Equals(Account account)
        {
            if (account is null)
            {
                return false;
            }

            if (ReferenceEquals(this, account))
            {
                return true;
            }

            if (this.GetType() != account.GetType())
            {
                return false;
            }

            if (this.Id == account.Id)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
