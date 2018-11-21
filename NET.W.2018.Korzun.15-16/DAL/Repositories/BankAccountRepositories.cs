using DAL.Context;
using DAL.Interface.Interfaces;
using DAL.Interface.Intities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BankAccountRepositories : IRepository
    {
        private BankContext bankContext;

        public BankAccountRepositories(BankContext dbContext)
        {
            this.bankContext = dbContext;
        }

        public void CreateAccount(Account account)
        {
            bankContext.Accounts.Add(account);
        }

        public void RemoveAccount(int id)
        {
            var account = this.bankContext.Accounts.FirstOrDefault(b => b.Id == id);
            bankContext.Accounts.Remove(account);
        }

        public void SaveAccount()
        {
            this.bankContext.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            bankContext.Entry(account).State = EntityState.Modified;
        }

        public Account GetAccount(int id)
        {
            var account = this.bankContext.Accounts.FirstOrDefault(b => b.Id == id);
            return account;
        }

        public IEnumerable<Account> GetAccountList()
        {
            return this.bankContext.Accounts;
        }

        public IEnumerable<Account> GetAllList()
        {
            return this.bankContext.Accounts;
        }
    }
}
