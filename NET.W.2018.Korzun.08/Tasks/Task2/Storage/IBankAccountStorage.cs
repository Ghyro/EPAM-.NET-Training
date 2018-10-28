using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    /// <summary>
    /// Interface of account storage (methods)
    /// </summary>
    public interface IBankAccountStorage
    {
        /// <summary>
        /// Input path to file
        /// </summary>
        string Path { get; }

        /// <summary>
        /// List to load
        /// </summary>
        /// <returns>List</returns>
        List<Account> Load();

        /// <summary>
        /// Save list to the file
        /// </summary>
        /// <param name="items">List items</param>
        void Save(List<Account> items);
    }
}
