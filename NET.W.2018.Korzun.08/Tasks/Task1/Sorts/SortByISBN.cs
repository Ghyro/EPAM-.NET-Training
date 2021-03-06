﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task1.Sorts
{
    /// <summary>
    /// Method which to compare two objects of the <see cref="Book"> by <see cref="Book.ISBN"/>/>
    /// </summary>
    public class SortByISBN : IComparer<Book>
    {
        /// <summary>
        /// Compare two object of the <see cref="Book"/> by <see cref="Book.ISBN"/>.
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>Result to compare two objects</returns>
        public int Compare(Book x, Book y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }

            if (y is null)
            {
                throw new ArgumentNullException(nameof(x));
            }

            return x.ISBN.CompareTo(y.YearOfPublishing);
        }
    }
}
