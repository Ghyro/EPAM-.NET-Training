﻿using System;
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
        private BankContext db;

        public BankAccountRepositories(BankContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Adds new <see cref="Account"/>
        /// </summary>
        /// <param name="account">The <see cref="Account"/> to add</param>
        public void CreateAccount(Account account)
        {
            db.Accounts.Add(account);
        }

        /// <summary>
        /// Removes <see cref="Account"/>
        /// </summary>
        /// <param name="id">The id of <see cref="Account"/> which need to remove</param>
        public void RemoveAccount(int id)
        {
            var account = this.db.Accounts.FirstOrDefault(b => b.Id == id);
            db.Accounts.Remove(account);
        }

        /// <summary>
        /// Save <see cref="Account"/> to list
        /// </summary>
        public void SaveAccount()
        {
            this.db.SaveChanges();
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account">The object of <see cref="Account"/></param>
        public void UpdateAccount(Account account)
        {
            db.Entry(account).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets <see cref="Account"/> by its id
        /// </summary>
        /// <param name="id">Input id</param>
        /// <returns>Account</returns>
        public Account GetAccount(int id)
        {
            var account = this.db.Accounts.FirstOrDefault(b => b.Id == id);
            return account;
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="id">Account id</param>
        public void DeleteAccount(int id)
        {
            var account = db.Accounts.Find(id);

            if (account != null)
            {
                db.Accounts.Remove(account);
            }
        }

        /// <summary>
        /// Get list of accounts
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return db.Accounts;
        }

        /// <summary>
        /// Get concrete account
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Account</returns>
        public IEnumerable<Account> FindConcrete(Func<Account, bool> predicate)
        {
            return db.Accounts.Where(predicate).ToList();
        }
    }
}
