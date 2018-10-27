using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task1
{
    /// <summary>
    /// Interface (service of book)
    /// </summary>
    public interface IBookListService
    {
        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">Object of <see cref="Book"/></param>
        void AddBook(Book book);

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="book">Object of <see cref="Book"/></param>
        void RemoveBook(Book book);

        /// <summary>
        /// Find of book by string
        /// </summary>
        /// <param name="title">Input string</param>
        /// <returns>Null</returns>
        Book FindBookByTag(string title);

        /// <summary>
        /// Sort book bt ISBN, Price, Title
        /// </summary>
        /// <param name="comparer">object of <see cref="Book"/></param>
        void SortBooksByTag(IComparer<Book> comparer);

        /// <summary>
        /// Save book in the bin file
        /// </summary>
        void SaveBooskInStorage();

        /// <summary>
        /// Load bin file
        /// </summary>
        /// <returns></returns>
        List<Book> GetListBooks();
    }
}
