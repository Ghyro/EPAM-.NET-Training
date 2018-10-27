using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Task1
{
    /// <summary>
    /// Book service
    /// </summary>
    public class BookService : IBookListService
    {
        /// <summary>
        /// List book
        /// </summary>
        private List<Book> listBooks = new List<Book>();

        /// <summary>
        /// Load and save file
        /// </summary>
        private IBookListStorage bookStorage;

        /// <summary>
        /// Constructor of book
        /// </summary>
        /// <param name="bookStorage">object of <see cref="IBookListStorage"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="bookStorage"/>if it is null.
        /// </exception>
        public BookService(IBookListStorage bookStorage)
        {
            if (bookStorage is null)
            {
                throw new ArgumentNullException(nameof(bookStorage));
            }

            this.bookStorage = bookStorage;
            listBooks = this.bookStorage.LoadBook().ToList();
        }

        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="book">object of <see cref="Book"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="book"/>if it is null.
        /// </exception>
        public void AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)} is null.");
            }

            listBooks.Add(book);
        }

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="book">object of <see cref="Book"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="book"/>if it is null;
        /// </exception>
        public void RemoveBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)} is null.");
            }

            listBooks.Remove(book);
        }

        /// <summary>
        /// Find book by title
        /// </summary>
        /// <param name="title">Input string</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="title"/>if it is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="title"/>if it = empty.
        /// </exception>
        /// <returns>Null</returns>
        public Book FindBookByTag(string title)
        {
            if (title is null)
            {
                throw new ArgumentNullException($"{nameof(title)} is null.");
            }

            if (title == string.Empty)
            {
                throw new ArgumentException($"{nameof(title)} is empty.");
            }

            foreach (var book in listBooks)
            {
                if (string.Compare(book.Title, title, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// Sort books by ISBN, Price, Title
        /// </summary>
        /// <param name="comparer">Implement <see cref="IComparer{Book}"/></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="comparer"/>if it is null.
        /// </exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} is null.");
            }

            listBooks.Sort(comparer);
        }

        /// <summary>
        /// Save book in the bin file
        /// </summary>
        public void SaveBooskInStorage()
        {
            bookStorage.SaveBook(listBooks);
        }

        /// <summary>
        /// Load storage.dat file
        /// </summary>
        /// <returns></returns>
        public List<Book> GetListBooks()
        {
            return bookStorage.LoadBook();
        }
    }
}
