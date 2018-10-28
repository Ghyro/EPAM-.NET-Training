using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks;

namespace Task
{
    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService : IBankService
    {
        /// <summary>
        /// Current list
        /// </summary>
        private List<Account> listAccounts;

        /// <summary>
        /// Object of <see cref="IBankAccountFact"/>
        /// </summary>
        private IBankAccountFact bankStorage;

        /// <summary>
        /// Initialization entities, load list.
        /// </summary>
        /// <param name="bankStorage">Object of <see cref="IBankAccountFact"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="bankStorage"/>is null.
        /// </exception>
        public AccountService(IBankAccountFact bankStorage)
        {
            if (bankStorage is null)
            {
                throw new ArgumentNullException(nameof(bankStorage));
            }

            this.bankStorage = bankStorage;
            listAccounts = bankStorage.GetAccount().Load().ToList();
        }


        /// <summary>
        /// Add new account
        /// </summary>
        /// <param name="account">object of <see cref="Account"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="account"/>is null.
        /// </exception>
        public void Add(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            listAccounts.Add(account);
        }

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="account">Object of <see cref="Account"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="account"/>is null.
        /// </exception>
        public void Remove(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            listAccounts.Remove(account);
        }

        /// <summary>
        /// Save accounts list
        /// </summary>
        public void Save()
        {
            bankStorage.GetAccount().Save(listAccounts);
        }
    }
}
