using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.DTO
{
    /// <summary>
    /// Base Account inherit to Account and changes properties
    /// </summary>
    public class BaseAccount : AccountDTO
    {
        /// <summary>
        /// Initialization entities by constructor
        /// </summary>
        /// <param name="id">The id of bank account</param>
        /// <param name="name">The name of holder account</param>
        /// <param name="surname">The surname of holder account</param>
        /// <param name="amount">The balance of account</param>
        /// <param name="bonus">Bonus points</param>
        public BaseAccount(int id, string name, string surname, decimal amount, int bonus) : base(id, name, surname, amount, bonus)
        {
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
        public BaseAccount(int id, string name, string surname, decimal amount, int bonus, IBonus bonusToWithdraw, IBonus bonusToReplenishment)
            : base(id, name, surname, amount, bonus, bonusToWithdraw, bonusToReplenishment)
        {
        }

        /// <summary>
        /// Default bonus value for withdraw
        /// </summary>
        public override int BonusPointToWithdraw { get; set; } = 2;

        /// <summary>
        /// Default bonus value for replenishment
        /// </summary>
        public override int BonusPointToReplenishment { get; set; } = 2;

        /// <summary>
        /// Set type pf account
        /// </summary>
        public override AccountType AccountType { get; } = AccountType.Base;
    }
}
