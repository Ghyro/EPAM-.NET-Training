using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Task1
{
    /// <summary>
    /// Storage of <see cref="Book">in the bin file/>
    /// </summary>
    public class BookListToBinary : IBookListStorage
    {
        /// <summary>
        /// Path of file
        /// </summary>
        private string _Path;

        /// <summary>
        /// Initialization a one param
        /// </summary>
        /// <param name="path">Path of file</param>
        public BookListToBinary(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Path of file
        /// </summary>
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _Path = value;
            }
        }

        /// <summary>
        /// Load <see cref="Book"> from the bin file/>
        /// </summary>
        /// <returns></returns>
        public List<Book> LoadBook()
        {
            List<Book> listBookLoad = new List<Book>();

            using(Stream stream = File.Open(Path, FileMode.OpenOrCreate))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        string isbn = binaryReader.ReadString();
                        string author = binaryReader.ReadString();
                        string title = binaryReader.ReadString();
                        string publishing = binaryReader.ReadString();
                        int yearOfPublishing = binaryReader.ReadInt32();
                        int countOfPages = binaryReader.ReadInt32();
                        decimal price = binaryReader.ReadDecimal();

                        Book book = new Book(isbn, author, title, publishing, yearOfPublishing, countOfPages, price);
                        listBookLoad.Add(book);
                    }                 
                }
            }

            return listBookLoad;
        }

        /// <summary>
        /// Save list items of <see cref="Book"> to storage.dat />
        /// </summary>
        /// <param name="items">Items of list</param>
        public void SaveBook(List<Book> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            using (Stream stream = File.Open(Path, FileMode.Truncate))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var book in items)
                    {
                        binaryWriter.Write(book.ISBN);
                        binaryWriter.Write(book.Author);
                        binaryWriter.Write(book.Title);
                        binaryWriter.Write(book.Publishing);
                        binaryWriter.Write(book.YearOfPublishing);
                        binaryWriter.Write(book.CountOfPages);
                        binaryWriter.Write(book.Price);
                    }
                }
            }

        }
    }
}
