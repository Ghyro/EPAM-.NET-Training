using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;

namespace BLL.BusinessModels
{
    /// <summary>
    /// Implementation <see cref="IBonus"/>
    /// </summary>
    public class BonusReplenishment : IBonus
    {
        /// <summary>
        /// Returns Current bonus for a specific <see cref="AccountDTO"/>
        /// </summary>
        /// <param name="account">Object of <see cref="AccountDTO"/></param>
        /// <param name="amount">Current <see cref="AccountDTO.Amount"/></param>
        /// <returns>Current bonus for a specific account</returns>
        public int GetBonusPoints(AccountDTO account, decimal amount)
        {
            return account.BonusPointToReplenishment;
        }
    }
}
