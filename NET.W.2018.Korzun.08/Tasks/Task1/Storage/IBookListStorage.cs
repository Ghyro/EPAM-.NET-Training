using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task1
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Load book
        /// </summary>
        /// <returns>List of book</returns>
        List<Book> LoadBook();

        /// <summary>
        /// Save book in the bin file
        /// </summary>
        /// <param name="items">Current items in list</param>
        void SaveBook(List<Book> items);
    }
}
