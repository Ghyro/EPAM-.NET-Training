using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.DTO
{
    public abstract class AccountDTO : IEquatable<AccountDTO>
    {
        #region Entities
        private int _id;
        private string _name;
        private string _surname;
        private decimal _amount; // balance
        private int _bonus;
        private IBonus _bonusToWithdraw;
        private IBonus _bonusToReplenishment;
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
        public AccountDTO(int id, string name, string surname, decimal amount, int bonus)
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
        public AccountDTO(int id, string name, string surname, decimal amount, int bonus, IBonus bonusToWithdraw, IBonus bonusToReplenishment)
            : this(id, name, surname, amount, bonus)

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
                return this._id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must not be less than 0.");
                }

                _id = value;
            }
        }

        /// <summary>
        /// The name of holder account
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _name = value;
            }
        }

        /// <summary>
        /// The surname of holder account
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _surname = value;
            }
        }

        /// <summary>
        /// The balance of account
        /// </summary>
        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must not be less than 0.");
                }

                _amount = value;
            }
        }

        /// <summary>
        /// Bonus points
        /// </summary>
        public int Bonus
        {
            get
            {
                return _bonus;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} must not be less than 0.");
                }

                _bonus = value;
            }
        }

        /// <summary>
        /// Bonus by withdraw
        /// </summary>
        public IBonus BonusToWithdraw
        {
            get
            {
                return _bonusToWithdraw;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _bonusToWithdraw = value;
            }
        }

        /// <summary>
        /// Bonus by replenishment
        /// </summary>
        public IBonus BonusToReplenishment
        {
            get
            {
                return _bonusToReplenishment;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _bonusToReplenishment = value;
            }
        }

        public abstract AccountType AccountType { get; }

        public abstract int BonusPointToWithdraw { get; set; }

        public abstract int BonusPointToReplenishment { get; set; }
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

            if (money > this.Amount)
            {
                throw new ArgumentException(nameof(money));
            }

            this.Amount -= money;

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

            this.Amount += money;

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
        public bool Equals(AccountDTO account)
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
