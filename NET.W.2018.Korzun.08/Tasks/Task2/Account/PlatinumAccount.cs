using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Task2.Bonus;

namespace Tasks
{
    /// <summary>
    /// Gold Account inherit to Account and changes properties
    /// </summary>
    public class PlatinumAccount : Account
    {
        /// <summary>
        /// Initialization entities by constructor
        /// </summary>
        /// <param name="id">The id of bank account</param>
        /// <param name="name">The name of holder account</param>
        /// <param name="surname">The surname of holder account</param>
        /// <param name="amount">The balance of account</param>
        /// <param name="bonus">Bonus points</param>
        public PlatinumAccount(int id, string name, string surname, decimal amount, int bonus) : base(id, name, surname, amount, bonus)
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
        public PlatinumAccount(int id, string name, string surname, decimal amount, int bonus, IBonus bonusToWithdraw, IBonus bonusToReplenishment)
            : base(id, name, surname, amount, bonus, bonusToWithdraw, bonusToReplenishment)
        {
        }

        /// <summary>
        /// Default bonus value for withdraw
        /// </summary>
        public override int BonusPointToWithdraw { get; set; } = 3;

        /// <summary>
        /// Default bonus value for replenishment
        /// </summary>
        public override int BonusPointToReplenishment { get; set; } = 3;

        /// <summary>
        /// Set type pf account
        /// </summary>
        public override AccountType AccountType { get; } = AccountType.Platinum;
    }
}
