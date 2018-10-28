using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    /// <summary>
    /// Implements <see cref="IBankAccount"/>
    /// </summary>
    public class BankAccount : IBankAccount
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
        public Account GetAccount(int id, string name, string surname, decimal amount, int bonus, AccountType accountType)
        {
            if (accountType == AccountType.Base)
            {
                return new BaseAccount(id, name, surname, amount, bonus);
            }
            else if (accountType == AccountType.Gold)
            {
                return new GoldAccount(id, name, surname, amount, bonus);
            }
            else if (accountType == AccountType.Platinum)
            {
                return new PlatinumAccount(id, name, surname, amount, bonus);
            }
            else
            {
                return new BaseAccount(id, name, surname, amount, bonus);
            }
        }
    }
}
