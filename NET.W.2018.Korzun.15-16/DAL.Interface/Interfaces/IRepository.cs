﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Intities;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// The intefrace <see cref="IRepository"/> for work with entities
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="account">Object of<see cref="Account"/></param>
        void CreateAccount(Account item);

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account">Object of<see cref="Account"/></param>
        void UpdateAccount(Account item);

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="id">Current account id</param>
        void DeleteAccount(int id);

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="id">Id of <see cref="Account"/></param>
        void RemoveAccount(int id);

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id">Id of <see cref="Account"/></param>
        /// <returns>Found account</returns>
        Account GetAccount(int id);

        /// <summary>
        /// Get accounts list
        /// </summary>
        /// <returns>The list of <see cref="Account"/></returns>
        IEnumerable<Account> GetAllAccounts();

        /// <summary>
        /// Search concrete account
        /// </summary>
        /// <param name="predicate">Parameteres for seach</param>
        /// <returns>Bool</returns>
        IEnumerable<Account> FindConcrete(Func<Account, bool> predicate);

        /// <summary>
        /// Save accounts
        /// </summary>
        void SaveAccount();
    }
}
