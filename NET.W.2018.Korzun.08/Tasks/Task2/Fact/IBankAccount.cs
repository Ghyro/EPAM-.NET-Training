using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public interface IBankAccount
    {
        /// <summary>
        /// Set type of account
        /// </summary>
        /// <param name="id">The id of bank account</param>
        /// <param name="name">The name of holder account</param>
        /// <param name="surname">The surname of holder account</param>
        /// <param name="amount">The balance of account</param>
        /// <param name="bonus">Bonus points</param>
        /// <param name="accountType">Type of account</param>
        /// <returns>Account</returns>
        Account GetAccount(int id, string name, string surname, decimal amount, int bonus, AccountType accountType);
    }
}
