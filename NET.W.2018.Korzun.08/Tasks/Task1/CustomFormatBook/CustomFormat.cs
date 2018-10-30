using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tasks.Task1
{
    public class CustomFormat : IFormatProvider, ICustomFormatter
    {
        IFormatProvider parent;

        public CustomFormat()
            : this(CultureInfo.CurrentCulture)
        {
        }

        public CustomFormat(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null; ;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is Book))
            {
                throw new Exception(nameof(arg));
            }

            if (format != "CustomFormat")
            {
                throw new Exception(nameof(format));
            }

            var book = arg as Book;

            switch (format.ToUpperInvariant())
            {
                case "CustomFormat": return $"{book.ISBN}. {book.Author} - {book.Title}, {book.Publishing}, {book.YearOfPublishing}, {book.CountOfPages} pages, {book.Price.ToString("C", formatProvider)}.";
            }

            throw new FormatException(nameof(format));

        }
        
    }
}
