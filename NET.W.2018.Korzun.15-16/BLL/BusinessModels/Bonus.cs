using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    /// <summary>
    /// Calculation of bonus points
    /// </summary>
    public class Bonus : IBonus
    {
        /// <summary>
        /// Сalculation of bonus points for deposit
        /// </summary>
        /// <param name="account">Current account</param>
        /// <param name="amount">Current amount of money</param>
        /// <returns>Bonus amount</returns>
        public decimal DepositBonus(BankAccountDTO account, decimal amount)
        {
            return amount + account.AccountType.CoefDeposit;
        }

        /// <summary>
        /// Сalculation of bonus points for withdraw
        /// </summary>
        /// <param name="account">Current account</param>
        /// <param name="amount">Current amount of money</param>
        /// <returns>Bonus amount</returns>
        public decimal WithdrawBonus(BankAccountDTO account, decimal amount)
        {
            return amount - account.AccountType.CoefWithdraw;
        }
    }
}
