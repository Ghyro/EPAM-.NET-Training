using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Interface.Interfaces;
using DAL.Interface.Intities;

namespace DAL.Repositories
{
    /// <summary>
    /// Methods to work with <see cref="IRepository"/>
    /// </summary>
    public class BankAccountRepositories : IRepository
    {
        private BankContext bankContext;

        public BankAccountRepositories(BankContext context)
        {
            this.bankContext = context;
        }

        /// <summary>
        /// Adds new <see cref="Account"/>
        /// </summary>
        /// <param name="account">The <see cref="Account"/> to add</param>
        public void CreateAccount(Account account)
        {
            bankContext.Accounts.Add(account);
        }

        /// <summary>
        /// Removes <see cref="Account"/>
        /// </summary>
        /// <param name="id">The id of <see cref="Account"/> which need to remove</param>
        public void RemoveAccount(int id)
        {
            var account = this.bankContext.Accounts.FirstOrDefault(b => b.Id == id);
            bankContext.Accounts.Remove(account);
        }

        /// <summary>
        /// Save <see cref="Account"/> to list
        /// </summary>
        public void SaveAccount()
        {
            this.bankContext.SaveChanges();
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account">The object of <see cref="Account"/></param>
        public void UpdateAccount(Account account)
        {
            bankContext.Entry(account).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets <see cref="Account"/> by its id
        /// </summary>
        /// <param name="id">Input id</param>
        /// <returns>Account</returns>
        public Account GetAccount(int id)
        {
            var account = this.bankContext.Accounts.FirstOrDefault(b => b.Id == id);
            return account;
        }

        /// <summary>
        /// Gets a whole list of accounts
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<Account> GetAccountList()
        {
            return this.bankContext.Accounts;
        }
    }
}
