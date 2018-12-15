using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Bank services
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Add new account
        /// </summary>
        /// <param name="account">object of <see cref="Account"/></param>
        void AddAccount(BankAccountDTO account);

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="account">object of <see cref="Account"/></param>
        void RemoveAccount(BankAccountDTO account);

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="account">Current account</param>
        void CloseAccount(BankAccountDTO account);

        /// <summary>
        /// Deposit money to account
        /// </summary>
        /// <param name="account">Current account</param>
        /// <param name="amount">Amount of money</param>
        void DepositMoney(BankAccountDTO account, decimal amount);

        /// <summary>
        /// Withdraw monee from account
        /// </summary>
        /// <param name="account">Current account</param>
        /// <param name="amount">Amount of money</param>
        void WithdrawMoney(BankAccountDTO account, decimal amount);

        /// <summary>
        /// Transfer money to another account
        /// </summary>
        /// <param name="FromAccount">From the account</param>
        /// <param name="ToAccount">To the account</param>
        /// <param name="amount">Amount of money</param>
        void Transaction(BankAccountDTO FromAccount, BankAccountDTO ToAccount, decimal amount);

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>List</returns>
        IEnumerable<BankAccountDTO> GetAccounts();

        /// <summary>
        /// Get account
        /// </summary>
        /// <param name="id">The ID of account</param>
        /// <returns>Account</returns>
        BankAccountDTO GetAccountDTO(int id);

        /// <summary>
        /// Save account
        /// </summary>
        void SaveAccount();
    }
}
