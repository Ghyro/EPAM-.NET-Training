using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
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
        void Add(Account account);

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="account">object of <see cref="Account"/></param>
        void Remove(Account account);

        /// <summary>
        /// Save list to the file
        /// </summary>
        void Save();
    }
}
