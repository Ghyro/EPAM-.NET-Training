using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessModels;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IBankService
    {
        private readonly IBonus bonus;
        private readonly IRepository repository;
        private readonly CustomMapper mapper;

        public AccountService(IRepository repository, CustomMapper mapper, IBonus bonus)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (bonus is null)
            {
                throw new ArgumentNullException(nameof(bonus));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this.bonus = bonus;
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="account">New account</param>
        public void AddAccount(BankAccountDTO account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else if (account != null)
            {
                this.repository.Create(mapper.MapAccountToDTO(account));
            }
            else
            {
                throw new Exception(nameof(account));
            }

            SaveAccount();
        }

        /// <summary>
        /// Close some account
        /// </summary>
        /// <param name="account">Input account</param>
        public void CloseAccount(BankAccountDTO account)
        {
            var bankAccount = this.repository.Get(account.Id);

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }
            else if (bankAccount != null)
            {
                bankAccount.AccountStatus = DAL.Interface.Entities.AccountStatus.Closed;
            }
            else
            {
                throw new ArgumentException(nameof(bankAccount));
            }

            SaveAccount();

        }        

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>The list of accounts</returns>
        public IEnumerable<BankAccountDTO> GetAccounts()
        {
            var accounts = this.repository.GetAll();

            return mapper.MapAccounts(accounts);
        }

        public void RemoveAccount(BankAccountDTO account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.repository.Remove(account.Id);

            SaveAccount();
        }

        /// <summary>
        /// Transfer some money to another account
        /// </summary>
        /// <param name="FromAccount">From the account</param>
        /// <param name="ToAccount">To the account</param>
        /// <param name="amount">Input amount of money</param>
        public void Transaction(BankAccountDTO FromAccount, BankAccountDTO ToAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            var fromAccount = repository.Get(FromAccount.Id);

            var toAccount = repository.Get(ToAccount.Id);

            if (FromAccount is null || ToAccount is null)
            {
                throw new ArgumentException($"{nameof(FromAccount)} and {nameof(ToAccount)} don't exist");
            }

            if (FromAccount.AccountStatus == AccountStatus.Closed || ToAccount.AccountStatus == AccountStatus.Closed)
            {
                throw new ArgumentException($"Account is closed.");
            }

            if (FromAccount.Balance < amount)
            {
                throw new ArgumentOutOfRangeException(nameof(FromAccount));
            }

            fromAccount.Balance = fromAccount.Balance - amount;

            toAccount.Balance = toAccount.Balance + amount;

            FromAccount.Balance = fromAccount.Balance;

            ToAccount.Balance = toAccount.Balance;

            SaveAccount();

        }

        /// <summary>
        /// Withdraw some money from account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public void WithdrawMoney(BankAccountDTO account, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            var bankAccount = this.repository.Get(account.Id);

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (bankAccount.AccountStatus == DAL.Interface.Entities.AccountStatus.Closed)
            {
                throw new ArgumentException(nameof(bankAccount));
            }

            bankAccount.Balance = bankAccount.Balance - amount;

            SaveAccount();
        }

        /// <summary>
        /// Deposit some money to account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public void DepositMoney(BankAccountDTO account, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            var bankAccount = this.repository.Get(account.Id);

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (bankAccount.AccountStatus == DAL.Interface.Entities.AccountStatus.Closed)
            {
                throw new ArgumentException(nameof(bankAccount));
            }

            bankAccount.Balance = bankAccount.Balance + amount;

            SaveAccount();
        }

        /// <summary>
        /// Save account
        /// </summary>
        public void SaveAccount()
        {
            this.repository.Save();
        }
    }
}
