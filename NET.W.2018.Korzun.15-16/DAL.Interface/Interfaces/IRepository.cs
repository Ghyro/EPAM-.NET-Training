using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
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
        void Create(Account account);

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account">Object of<see cref="Account"/></param>
        void Update(Account account);

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="id">Id of <see cref="Account"/></param>
        void Remove(int id);

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id">Id of <see cref="Account"/></param>
        /// <returns>Found account</returns>
        Account Get(int id);

        /// <summary>
        /// Get accounts list
        /// </summary>
        /// <returns>The list of <see cref="Account"/></returns>
        IEnumerable<Account> GetAll();

        /// <summary>
        /// Search concrete account
        /// </summary>
        /// <param name="predicate">Parameteres for seach</param>
        /// <returns>Bool</returns>
        IEnumerable<Account> FindConcrete(Func<Account, bool> predicate);

        /// <summary>
        /// Get all types of account
        /// </summary>
        /// <returns>List of types</returns>
        IEnumerable<AccountType> GetTypesAccount();

        /// <summary>
        /// Save accounts
        /// </summary>
        void Save();
    }
}
