﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    public interface IBonus
    {
        /// <summary>
        /// Сalculation of bonus points for deposit
        /// </summary>
        /// <param name="account">Current account</param>
        /// <param name="amount">Current amount of money</param>
        /// <returns>Bonus amount</returns>
        decimal DepositBonus(BankAccountDTO account, decimal amount);

        /// <summary>
        /// Сalculation of bonus points for withdraw
        /// </summary>
        /// <param name="account">Current account</param>
        /// <param name="amount">Current amount of money</param>
        /// <returns>Bonus amount</returns>
        decimal WithdrawBonus(BankAccountDTO account, decimal amount);
    }
}
