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
    public interface IBankService : IEnumerable<AccountDTO>
    {
        /// <summary>
        /// Add new account
        /// </summary>
        /// <param name="account">object of <see cref="Account"/></param>
        void Add(AccountDTO account);

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="account">object of <see cref="Account"/></param>
        void Remove(AccountDTO account);

        /// <summary>
        /// Save list to the file
        /// </summary>
        void Save();
    }
}
