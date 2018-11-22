﻿using BLL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Factory for <see cref="AccountDTO"/>
    /// </summary>
    public interface IBankAccountFactory
    {
        /// <summary>
        /// Gets account
        /// </summary>
        /// <param name="id">The account id</param>
        /// <param name="name">Holder name</param>
        /// <param name="surname">Holder surname</param>
        /// <param name="amount">Current amount</param>
        /// <param name="bonus">The account bonus</param>
        /// <param name="type">Type of account</param>
        /// <returns>New account <see cref="AccountDTO"/></returns>
        AccountDTO GetAccount(int id, string name, string surname, decimal amount, int bonus, AccountType type);
    }
}