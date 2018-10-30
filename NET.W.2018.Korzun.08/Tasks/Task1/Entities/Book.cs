﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Tasks.Task1
{
    /// <summary>
    /// Develop the Book class (ISBN, author, title, publisher, year of publication, number of pages, price),
    /// redefining for it the necessary methods of the class Object. For class objects, implement equivalence and order relations
    /// (using the appropriate interfaces).
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Private entities
        /// <summary>
        /// Entity of book
        /// </summary>
        private string _ISBN;
        private string _Author;
        private string _Title;
        private string _Publishing;
        private int _YearOfPublishing;
        private int _CountOfPages;
        private decimal _Price;
        #endregion      

        #region Constructor
        /// <summary>
        /// Initializes a new entities of the class <see cref="Book">
        /// </summary>
        /// <param name="isbn">International paper or e-book number</param>
        /// <param name="author">The author of book</param>
        /// <param name="title">The title of book</param>
        /// <param name="publishing">The book publisher</param>
        /// <param name="yearOfPublishing">Date of published</param>
        /// <param name="countOfPages">The count of pages in the book</param>
        /// <param name="price">The price of the book</param>
        public Book(string isbn, string author, string title, string publishing, int yearOfPublishing, int countOfPages, decimal price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publishing = publishing;
            YearOfPublishing = yearOfPublishing;
            CountOfPages = countOfPages;
            Price = price;
        }
        #endregion

        #region Entities logic (propertias)
        /// <summary>
        /// International paper or e-book number
        /// </summary>
        public string ISBN
        {
            get
            {
                return _ISBN;
            }
            set
            {
                string isbnPattern = @"[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*"; // ISBN-13

                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                if (!Regex.IsMatch(value, isbnPattern))
                {
                    throw new ArgumentException($"{nameof(value)} must be in the correct form!");
                }

                _ISBN = value;
            }
        }

        /// <summary>
        /// The author of book
        /// </summary>
        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} is empty!");
                }

                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _Author = value;
            }
        }

        /// <summary>
        /// The title of book
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} is empty!");
                }

                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _Title = value;
            }
        }

        /// <summary>
        /// The book publisher
        /// </summary>
        public string Publishing
        {
            get
            {
                return _Publishing;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} is empty!");
                }

                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(value)} is null!");
                }

                _Publishing = value;
            }
        }

        /// <summary>
        /// Date of published
        /// </summary>
        public int YearOfPublishing
        {
            get
            {
                return _YearOfPublishing;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be positive value!");
                }

                _YearOfPublishing = value;
            }
        }

        /// <summary>
        /// The count of pages in the book
        /// </summary>
        public int CountOfPages
        {
            get
            {
                return _CountOfPages;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be positive value!");
                }

                _CountOfPages = value;
            }
        }

        /// <summary>
        /// The price of the book
        /// </summary>
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be positive value!");
                }

                _Price = value;
            }
        }
        #endregion

        #region Object methods
        /// <summary>
        /// Change string representation ToString()
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            string book = $"ISBN: {this.ISBN}, autor: {this.Author}, title: {this.Title}, publishing: {this.Publishing}, year of publishing: {this.YearOfPublishing}," +
                $"count of pages: {this.CountOfPages}, price: {this.Price}";

            return book;
        }

        /// <summary>
        /// For objects <see cref="Book">, whish has properies ISBN,
        /// Title, Author, Publishing, YearOfPublishing,
        /// CountOfPages and Price, impelement the possibility
        /// of a string representation
        /// of a different type./>
        /// </summary>
        /// <param name="format">Current format</param>
        /// <param name="formatProvider">object of interface <see cref="IFormatProvider"/></param>
        /// <returns>
        /// <exception cref="FormatException">
        /// <paramref name="format"/> does not exist.
        /// </exception>
        /// </returns>
        public string FormatToString(string format, IFormatProvider formatProvider)
        {
            if(format is null)
            {
                format = "IATPYCP";
            }

            if (formatProvider is null)
            {
                formatProvider = new CultureInfo("en-US");
            }

            switch (format.ToUpperInvariant())
            {
                case "IATPYCP": return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publishing}, {this.YearOfPublishing}, {this.CountOfPages} pages, {this.Price.ToString("C", formatProvider)}.";
                case "IATPYC": return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publishing}, {this.YearOfPublishing}, {this.CountOfPages} pages.";
                case "IATPY": return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publishing}, {this.YearOfPublishing}.";
                case "IATP": return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publishing}.";
                case "IAT": return $"{this.ISBN}. {this.Author} - {this.Title}.";
                case "AT": return $"{this.Author} - {this.Title}.";
            }

            throw new FormatException(nameof(format));
        }

        /// <summary>
        /// Return numeric representation this book instance.
        /// </summary>
        /// <returns>Hash code of current book</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns a value indicating  wheter this instance is equal to a specified object instance
        /// </summary>
        /// <param name="obj">A object instance to compare with this instance</param>
        /// <returns>true if the specified  object instance is equal to the current object instance; otherwise, return false</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Book)obj);
        }

        /// <summary>
        /// Override IEquatable class <see cref="Book"/> 
        /// </summary>
        /// <param name="other">Object of <see cref="Book"/></param>
        /// <returns>True or false</returns>
        public bool Equals(Book other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.ISBN == ISBN;
        }

        /// <summary>
        /// IComparable<Book>
        /// </summary>
        /// <param name="other">Object of <see cref="Book"/></param>
        /// <returns>0, 1, -1</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return string.Compare(Title, other.Title);
        }

        
        #endregion
    }
}
