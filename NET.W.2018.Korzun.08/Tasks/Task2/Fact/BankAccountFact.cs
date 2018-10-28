using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    /// <summary>
    /// Implements <see cref="IBankAccountFact"/>
    /// </summary>
    public class BankAccountFact : IBankAccountFact
    {
        /// <summary>
        /// Transmits path and account
        /// </summary>
        /// <returns></returns>
        public IBankAccountStorage GetAccount()
        {
            return new BankStorage("storage.dat", new BankAccount());
        }
    }
}
