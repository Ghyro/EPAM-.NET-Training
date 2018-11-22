using BLL.BusinessModels;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankFactory
{
    public class BankAccountFactory : IBankAccountFactory
    {
        /// <summary>
        /// Determine the initial type of account
        /// </summary>
        /// <param name="id">The id of bank account</param>
        /// <param name="name">The name of holder account</param>
        /// <param name="surname">The surname of holder account</param>
        /// <param name="amount">The balance of account</param>
        /// <param name="bonus">Bonus points</param>
        /// <param name="accountType">Type of account</param>
        /// <returns
        /// <see cref="AccountType.Base"/> is type = base,
        /// <see cref="AccountType.Gold"/> is type = gold,
        /// <see cref="AccountType.Platinum"/> is type = platinum.
        /// <else>
        /// <return><see cref="AccountType.Base"/></return>
        /// </else>
        /// </returns>
        public AccountDTO GetAccount(int id, string name, string surname, decimal amount, int bonus, AccountType type)
        {
            if (type == AccountType.Base)
            {
                return new BaseAccount(id, name, surname, amount, bonus, this.Withdraw, this.Replenishment);
            }
            else if (type == AccountType.Gold)
            {
                return new GoldAccount(id, name, surname, amount, bonus, this.Withdraw, this.Replenishment);
            }
            else if (type == AccountType.Platinum)
            {
                return new PlatinumAccount(id, name, surname, amount, bonus, this.Withdraw, this.Replenishment);
            }
            else
            {
                return new BaseAccount(id, name, surname, amount, bonus, this.Withdraw, this.Replenishment);
            }
        }

        /// <summary>
        /// Create new object <see cref="IBonus"/> type of <see cref="BonusWithdraw"/>
        /// </summary>
        public IBonus Withdraw { get; set; } = new BonusWithdraw();

        /// <summary>
        /// Create new object <see cref="IBonus"/> type of <see cref="BonusReplenishment"/>
        /// </summary>
        public IBonus Replenishment { get; set; } = new BonusReplenishment();
    }
}
